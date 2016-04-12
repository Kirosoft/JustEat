using System.Net.Http;
using Xunit;
using System.Collections.Generic;
using JustEat.Models;
using JustEat.UnitTests.TestData;

namespace JustEat.UnitTests
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class JustEatClient
    {
        public JustEatClient()
        {
        }

        [Fact]
        public void TestJustEatClient()
        {
            var responseMessage = new HttpResponseMessage();
            responseMessage.Content = new FakeHttpContent(JustEatData.twoRestaurants);

            var messageHandler = new FakeHttpMessageHandler(responseMessage);
            var client = new HttpClient(messageHandler);

            Services.JustEatClient jeClient = new Services.JustEatClient(client);
            List<Restaurant> restaurantList = jeClient.GetAvailableRestaurants("SE19").GetAwaiter().GetResult();

            // Two restaurants supplied but only one is open
            Assert.Equal(1, restaurantList.Count);

            // Get the single restaurant 
            Restaurant restaurant = restaurantList[0];

            // Check the properties are set correctly
            Assert.Equal("Golden Fish", restaurant.Name);
            Assert.Equal("4.7", restaurant.Rating);
            string[] expectedCuisine = new string[] { "Chinese", "Thai" };
            Assert.Equal(expectedCuisine, restaurant.CuisineTypes);
        }
    }
}
