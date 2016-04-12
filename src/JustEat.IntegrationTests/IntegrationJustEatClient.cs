using Xunit;
using System.Collections.Generic;
using JustEat.Models;

namespace JustEat.IntegrationTests
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class IntegrationJustEatClient
    {
        public IntegrationJustEatClient()
        {
        }

        [Fact]
        public void TestJustEatClient()
        {
            Services.JustEatClient jeClient = new Services.JustEatClient();
            List<Restaurant> restaurantList = jeClient.GetAvailableRestaurants("SE19").GetAwaiter().GetResult();

            // Just test we reached here without an exception
            Assert.Equal(true, true);

            restaurantList = jeClient.GetAvailableRestaurants("").GetAwaiter().GetResult();
            Assert.Equal(true, true);
        }
    }
}
