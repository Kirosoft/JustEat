using Microsoft.AspNet.Mvc;
using JustEat.Services;
using JustEat.Models;
using Microsoft.Extensions.Logging;

namespace JustEat.Controllers
{
    public class HomeController : Controller
    {
        private RestaurantCache restaurantCache;
        private ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> logger, IRestaurantService restaurantService)
        {
            this.logger = logger;
            restaurantCache = new RestaurantCache(restaurantService);
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
