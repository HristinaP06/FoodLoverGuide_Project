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
    public class RestaurantModelTests
    {
        private Restaurant _restaurant;

        [SetUp]
        public void Setup()
        {
            _restaurant = new Restaurant
            {
                Id = Guid.NewGuid(),
                Name = "Test Restaurant",
                Description = "A nice place to dine",
                Location = "Downtown"
            };
        }

        [Test]
        public void Restaurant_WhenCreated_ShouldInitializeCollections()
        {
            var restaurant = new Restaurant();

            Assert.That(restaurant.Reservation, Is.Null);
            Assert.That(restaurant.RestaurantCategoriesList, Is.Null);
            Assert.That(restaurant.WorkTime, Is.Null);
            Assert.That(restaurant.Menu, Is.Null);
            Assert.That(restaurant.Photos, Is.Null);
            Assert.That(restaurant.Features, Is.Null);
            Assert.That(restaurant.Reviews, Is.Null);
        }

        [Test]
        public void Restaurant_WithValidData_ShouldPassValidation()
        {
            var validationContext = new ValidationContext(_restaurant);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(_restaurant, validationContext, validationResults, true);

            Assert.That(isValid, Is.True);
            Assert.That(validationResults, Is.Empty);
        }

        [Test]
        public void Restaurant_WithoutRequiredFields_ShouldFailValidation()
        {
            _restaurant.Name = null;
            _restaurant.Description = null;
            _restaurant.Location = null;

            var validationContext = new ValidationContext(_restaurant);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(_restaurant, validationContext, validationResults, true);

            Assert.That(isValid, Is.False);
            Assert.That(validationResults, Is.Not.Empty);
        }

        [Test]
        public void Restaurant_ShouldSetPropertiesCorrectly()
        {
            var id = Guid.NewGuid();
            var name = "New Place";
            var description = "Great food";
            var location = "Sofia";
            var isActive = true;

            var restaurant = new Restaurant
            {
                Id = id,
                Name = name,
                Description = description,
                Location = location,
                IsActive = isActive
            };

            Assert.That(restaurant.Id, Is.EqualTo(id));
            Assert.That(restaurant.Name, Is.EqualTo(name));
            Assert.That(restaurant.Description, Is.EqualTo(description));
            Assert.That(restaurant.Location, Is.EqualTo(location));
            Assert.That(restaurant.IsActive, Is.True);
        }
    }
}
