
namespace JustEat.UnitTests.TestData
{
    public class JustEatData
    {
        // Two restaurants, one is open
        public static string twoRestaurants = @"{
  'ShortResultText': 'SE19',
  'Restaurants': [
    {
      'Id': 3600,
      'Name': 'Golden Fish',
      'Address': '293 Northborough Road, Streatham',
      'Postcode': 'SW16 4TR',
      'City': 'London',
      'CuisineTypes': [
        {
          'Id': 33,
          'Name': 'Chinese',
          'SeoName': null
        },
        {
          'Id': 30,
          'Name': 'Thai',
          'SeoName': null
        }
      ],
      'Url': 'http://noodle-hut-sw16.just-eat.co.uk',
      'IsOpenNow': true,
      'IsSponsored': false,
      'IsNew': false,
      'IsTemporarilyOffline': false,
      'ReasonWhyTemporarilyOffline': 'NONE',
      'UniqueName': 'noodle-hut-sw16',
      'IsCloseBy': false,
      'IsHalal': false,
      'DefaultDisplayRank': 2,
      'IsOpenNowForDelivery': true,
      'IsOpenNowForCollection': true,
      'RatingStars': 4.7,
      'Logo': [
        {
          'StandardResolutionURL': 'http://d30v2pzvrfyzpo.cloudfront.net/uk/images/restaurants/3600.gif'
        }
      ],
      'Deals': [],
      'NumberOfRatings': 713
    },
    {
      'Id': 52164,
      'Name': 'Spice Lounge',
      'Address': '564 Streatham High Road',
      'Postcode': 'SW16 3QQ',
      'City': 'London',
      'CuisineTypes': [
        {
          'Id': 31,
          'Name': 'Indian',
          'SeoName': null
        },
        {
          'Id': 85,
          'Name': 'Curry',
          'SeoName': null
        }
      ],
      'Url': 'http://spice-lounge-streatham-common.just-eat.co.uk',
      'IsOpenNow': false,
      'IsSponsored': false,
      'IsNew': false,
      'IsTemporarilyOffline': false,
      'ReasonWhyTemporarilyOffline': 'NONE',
      'UniqueName': 'spice-lounge-streatham-common',
      'IsCloseBy': false,
      'IsHalal': true,
      'DefaultDisplayRank': 1,
      'IsOpenNowForDelivery': true,
      'IsOpenNowForCollection': true,
      'RatingStars': 5.21,
      'Logo': [
        {
          'StandardResolutionURL': 'http://d30v2pzvrfyzpo.cloudfront.net/uk/images/restaurants/52164.gif'
        }
      ],
      'Deals': [
        {
          'Description': '25% off when you spend £30',
          'DiscountPercent': '25',
          'QualifyingPrice': '30.00'
        }
      ],
      'NumberOfRatings': 238
    }
  ]
}";
    }
}
