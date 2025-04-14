using FoodLoverGuide.Core.ViewModels.UserArea;
using FoodLoverGuide.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodLoverGuide.Tests.UnitTests.ViewModels
{

    [TestFixture]
    public class HomeVM_Tests
    {
        [Test]
        public void HomeVM_Should_Populate_Correctly()
        {
            // Arrange
            var restaurant = new Restaurant { Id = Guid.NewGuid(), Name = "Test Restaurant" };
            var review = new Review { Id = Guid.NewGuid(), Rating = 5 };
            var photo = new RestaurantPhoto { Id = Guid.NewGuid(), Photo = "test.jpg" };

            var viewModel = new HomeVM
            {
                Restaurants = new List<Restaurant> { restaurant },
                RestaurantsCount = 1,
                LatestReviews = new List<Review> { review },
                FeaturedPhotos = new List<RestaurantPhoto> { photo }
            };

            // Assert
            Assert.That(viewModel.Restaurants, Is.Not.Null);
            Assert.That(viewModel.Restaurants.Count, Is.EqualTo(1));
            Assert.That(viewModel.RestaurantsCount, Is.EqualTo(1));
            Assert.That(viewModel.LatestReviews, Is.Not.Null);
            Assert.That(viewModel.LatestReviews.Count, Is.EqualTo(1));
            Assert.That(viewModel.FeaturedPhotos, Is.Not.Null);
            Assert.That(viewModel.FeaturedPhotos.Count, Is.EqualTo(1));
            Assert.That(viewModel.FeaturedPhotos[0].Photo, Is.EqualTo("test.jpg"));
        }
    }
}
