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
    public class RestaurantFeatureModelTests
    {
        private RestaurantFeature _restaurantFeature;

        [SetUp]
        public void Setup()
        {
            _restaurantFeature = new RestaurantFeature
            {
                FeatureId = Guid.NewGuid(),
                RestaurantId = Guid.NewGuid()
            };
        }

        [Test]
        public void RestaurantFeature_WithValidData_ShouldPassValidation()
        {
            var validationContext = new ValidationContext(_restaurantFeature);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(_restaurantFeature, validationContext, validationResults, true);

            Assert.That(isValid, Is.True);
            Assert.That(validationResults, Is.Empty);
        }

        [Test]
        public void RestaurantFeature_ShouldSetPropertiesCorrectly()
        {
            var featureId = Guid.NewGuid();
            var restaurantId = Guid.NewGuid();

            var rf = new RestaurantFeature
            {
                FeatureId = featureId,
                RestaurantId = restaurantId
            };

            Assert.That(rf.FeatureId, Is.EqualTo(featureId));
            Assert.That(rf.RestaurantId, Is.EqualTo(restaurantId));
        }
    }
}
