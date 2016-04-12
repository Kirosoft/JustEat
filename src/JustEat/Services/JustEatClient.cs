using System;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Linq;
using JustEat.Models;
using System.Collections.Generic;

namespace JustEat.Services
{
    public class JustEatClient : IRestaurantService
    {
        private HttpClient client = new HttpClient();
        private const string BASE_URL = "https://public.je-apis.com/";
        private ILogger<JustEatClient> _logger = null;

        public JustEatClient(ILogger<JustEatClient> logger = null) 
        {
            _logger = logger;
            _logger.LogInformation("Created JustEat client");

            SetupClientHeaders();
        }

        private void SetupClientHeaders() 
        {
            client.BaseAddress = new Uri(BASE_URL);
            client.DefaultRequestHeaders.Add("Accept-Tenant", "uk");
            client.DefaultRequestHeaders.Add("Accept-Language", "en-GB");
            client.DefaultRequestHeaders.Add("Authorization", "Basic VGVjaFRlc3RBUEk6dXNlcjI=");
            client.DefaultRequestHeaders.Add("Host", "public.je-apis.com");
        }

        public async Task<List<Restaurant>> GetRestaurants(string shortCode)
        {
            using (HttpResponseMessage response = await client.GetAsync("restaurants?q="+shortCode))
            {
	            using (HttpContent content = response.Content)
	            {
	                string result = await content.ReadAsStringAsync();
                    _logger?.LogInformation(result);

                    JObject jsonResponse = JObject.Parse(result);

                    // Convert the dynamically typed json response into a strongly typed 
                    // Code assumes that a restaurant is available only if it is open and available for both delivery and collection
                    var restaurantList =
                        (from restaurant in jsonResponse["Restaurants"]
                            select (new Restaurant {
                                Name = (string)restaurant["Name"],
                                Rating =(double)restaurant["RatingStars"],
                                CuisineTypes = restaurant["CuisineTypes"].Select(x => ((string) x["Name"])).ToArray()
                            })).ToList<Restaurant>();

                    return restaurantList;
	            }
            }
        }   
    }
}
