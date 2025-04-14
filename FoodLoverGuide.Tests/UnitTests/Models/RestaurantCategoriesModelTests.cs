using FoodLoverGuide.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodLoverGuide.Tests.UnitTests.Models
{
    [TestFixture]
    public class RestaurantCategoriesModelTests
    {
        private RestaurantCategories _restaurantCategories;

        [SetUp]
        public void Setup()
        {
            _restaurantCategories = new RestaurantCategories
            {
                CategoryId = Guid.NewGuid(),
                RestaurantId = Guid.NewGuid()
            };
        }

        [Test]
        public void RestaurantCategories_WithValidData_ShouldPassValidation()
        {
            var validationContext = new ValidationContext(_restaurantCategories);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(_restaurantCategories, validationContext, validationResults, true);

            Assert.That(isValid, Is.True);
            Assert.That(validationResults, Is.Empty);
        }

        [Test]
        public void RestaurantCategories_ShouldSetPropertiesCorrectly()
        {
            var categoryId = Guid.NewGuid();
            var restaurantId = Guid.NewGuid();

            var rc = new RestaurantCategories
            {
                CategoryId = categoryId,
                RestaurantId = restaurantId
            };

            Assert.That(rc.CategoryId, Is.EqualTo(categoryId));
            Assert.That(rc.RestaurantId, Is.EqualTo(restaurantId));
        }
    }
}
