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
    public class RestaurantIndexVM_Tests
    {
        [Test]
        public void Model_WithValidData_ShouldBeValid()
        {
            // Arrange
            var restaurants = new List<Restaurant>
            {
                new Restaurant { Id = Guid.NewGuid(), Name = "Test Restaurant" }
            };

            var categories = new List<Category>
            {
                new Category { Id = Guid.NewGuid(), CategoryName = "Италианска кухня" }
            };

            var features = new List<Feature>
            {
                new Feature { Id = Guid.NewGuid(), Name = "Градина" }
            };

            var model = new RestaurantIndexVM
            {
                Restaurants = restaurants,
                Categories = categories,
                Features = features
            };

            // Act & Assert
            Assert.That(model.Restaurants, Is.Not.Null);
            Assert.That(model.Restaurants.Count, Is.EqualTo(1));
            Assert.That(model.Categories, Is.Not.Null);
            Assert.That(model.Categories.Count, Is.EqualTo(1));
            Assert.That(model.Features, Is.Not.Null);
            Assert.That(model.Features.Count, Is.EqualTo(1));
        }

        [Test]
        public void Model_WithEmptyLists_ShouldBeValid()
        {
            var model = new RestaurantIndexVM
            {
                Restaurants = new List<Restaurant>(),
                Categories = new List<Category>(),
                Features = new List<Feature>()
            };

            Assert.That(model.Restaurants, Is.Empty);
            Assert.That(model.Categories, Is.Empty);
            Assert.That(model.Features, Is.Empty);
        }

        [Test]
        public void Model_WithNullLists_ShouldNotThrow()
        {
            var model = new RestaurantIndexVM();

            Assert.That(model.Restaurants, Is.Null);
            Assert.That(model.Categories, Is.Null);
            Assert.That(model.Features, Is.Null);
        }
    }
}
