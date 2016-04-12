using JustEat.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JustEat.Models
{
    /*
     * Simple caching service to store previously received results
     * TODO: Needs an expiration policy to be useful
     */
    public class RestaurantCache
    {
        private Dictionary<string, List<Restaurant>> restaurantCache = new Dictionary<string, List<Restaurant>>();
        private readonly IRestaurantService restaurantService = null;

        public RestaurantCache(IRestaurantService restaurantService)
        {
            this.restaurantService = restaurantService;
        }

        // Asynchronously use the DI restaurant service to load the short code restaurant
        // data and update the local cache
        private async Task UpdateCache(string shortCode)
        {
            List<Restaurant> restaurantList = await restaurantService.GetAvailableRestaurants(shortCode);
            restaurantCache[shortCode] = restaurantList;
        }

        public List<Restaurant> GetRestaurants(string shortCode)
        {
            // Check if the requested shortcode is not in the cache 
            if (!restaurantCache.ContainsKey(shortCode))
                UpdateCache(shortCode).GetAwaiter().GetResult();

            return restaurantCache[shortCode];
        }
    }
}
