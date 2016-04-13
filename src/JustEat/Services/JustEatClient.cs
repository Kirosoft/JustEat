using System;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System.Linq;
using JustEat.Models;
using System.Collections.Generic;

namespace JustEat.Services
{
    public class JustEatClient : IRestaurantService
    {
        private HttpClient client;
        // TODO: Move to configuration file
        private const string BASE_URL = "https://public.je-apis.com/";
        private ILogger<JustEatClient> logger;

        public JustEatClient(HttpClient httpClient = null, ILogger<JustEatClient> logger = null) 
        {
            this.logger = logger;
            this.client = httpClient != null ? httpClient : new HttpClient();
            this.logger?.LogInformation("Created JustEat client");
            SetupClientHeaders();
        }

        private void SetupClientHeaders() 
        {
            client.BaseAddress = new Uri(BASE_URL);
            client.DefaultRequestHeaders.Add("Accept-Tenant", "uk");
            client.DefaultRequestHeaders.Add("Accept-Language", "en-GB");
            // TODO: Move auth token into configuration file
            client.DefaultRequestHeaders.Add("Authorization", "Basic VGVjaFRlc3RBUEk6dXNlcjI=");
            // TODO: derive from base URL
            client.DefaultRequestHeaders.Add("Host", "public.je-apis.com");
        }

        public async Task<List<Restaurant>> GetAvailableRestaurants(string shortCode)
        {
            using (HttpResponseMessage response = await client.GetAsync("restaurants?q="+shortCode))
            {
	            using (HttpContent content = response.Content)
	            {
	                string result = await content.ReadAsStringAsync();

                    // Parse the response into dynamically typed objects
                    JObject jsonResponse = JObject.Parse(result);

                    // Logs some usefull information
                    logger?.LogInformation($"Restaurants available({shortCode}): {jsonResponse["Restaurants"].Count()}");
                    logger?.LogInformation($"Restaurants open({shortCode}): {jsonResponse["Restaurants"].Where(x => (bool)x["IsOpenNow"] == true).Count()}");
                    logger?.LogInformation(result);

                    // Convert the dynamically typed json response into a strongly typed restaurant list
                    // with just the needed properties.
                    // Code assumes that a restaurant is available when the "IsOpenNow" attribute is set to true
                    var restaurantList =
                        (from restaurant in jsonResponse["Restaurants"]
                            where (bool) restaurant["IsOpenNow"] == true
                            select (new Restaurant {
                                Name = (string)restaurant["Name"],
                                Rating =(string)restaurant["RatingStars"],
                                CuisineTypes = restaurant["CuisineTypes"].Select(x => ((string) x["Name"])).ToArray()
                            })).ToList<Restaurant>();

                    return restaurantList;
	            }
            }
        }   
    }
}
