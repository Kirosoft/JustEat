using JustEat.Services;
using System.Collections.Generic;

namespace JustEat.Models
{
    public class RestaurantCache
    {
        private Dictionary<string, List<Restaurant>> restaurantCache = new Dictionary<string, List<Restaurant>>();
        private readonly IRestaurantService restaurantService = null;

        public RestaurantCache(IRestaurantService restaurantService)
        {
            this.restaurantService = restaurantService;
            SetupDebugData();
        }

        private async void SetupDebugData()
        {
            List<Restaurant> restaurantList = await this.restaurantService.GetRestaurants("SE19");

            restaurantCache["SE19"] = restaurantList;
        }
    }
}
