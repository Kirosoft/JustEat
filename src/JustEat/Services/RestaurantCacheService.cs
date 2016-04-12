using JustEat.Models;

namespace JustEat.Services
{
    // Registered as a singleton service to keep the RestaurantCache for the lifetime of the application
    public class RestaurantCacheService
    {
        public RestaurantCache restaurantCache { get; }

        public RestaurantCacheService(IRestaurantService restaurantService)
        {
            this.restaurantCache = new RestaurantCache(restaurantService);
        }
    }
}
