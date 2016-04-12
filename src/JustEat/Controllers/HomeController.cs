using Microsoft.AspNet.Mvc;
using JustEat.Services;
using JustEat.Models;
using Microsoft.Extensions.Logging;

namespace JustEat.Controllers
{
    public class HomeController : Controller
    {
        private RestaurantCache restaurantCache = null;
        private ILogger<HomeController> logger = null;
        private string shortCode = "SE19";

        public HomeController(ILogger<HomeController> logger, RestaurantCacheService restaurantCacheService)
        {
            this.logger = logger;
            this.restaurantCache = restaurantCacheService.restaurantCache;
        }

        // GET: /<controller>/
        public IActionResult Index(string id)
        {
            shortCode = id != null ? id.ToUpper() : shortCode;

            // TODO: ViewData method is not suitable for reactive style applications 
            // In a real world application I would probably favour a webservice call
            // to retrieve data
            ViewData["ShortCode"] = shortCode;
            ViewData["Restaurants"] = restaurantCache.GetRestaurants(shortCode);
            return View();
        }
    }
}
