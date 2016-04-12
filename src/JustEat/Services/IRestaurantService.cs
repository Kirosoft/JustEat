using System.Threading.Tasks;
using JustEat.Models;
using System.Collections.Generic;

namespace JustEat.Services
{
    public interface IRestaurantService
    {
        Task<List<Restaurant>> GetRestaurants(string shortCode);
    }
}
    