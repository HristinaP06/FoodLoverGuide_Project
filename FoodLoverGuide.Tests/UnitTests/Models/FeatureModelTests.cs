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
    public class FeatureModelTests
    {
        private Feature _feature;

        [SetUp]
        public void Setup()
        {
            _feature = new Feature
            {
                Id = Guid.NewGuid(),
                Name = "Wi-Fi"
            };
        }

        [Test]
        public void Feature_WhenCreated_ShouldHaveEmptyRestaurantsList()
        {
            var feature = new Feature();

            Assert.That(feature.RestaurantsList, Is.Not.Null);
            Assert.That(feature.RestaurantsList, Is.Empty);
        }

        [Test]
        public void Feature_WithValidData_ShouldPassValidation()
        {
            var validationContext = new ValidationContext(_feature);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(_feature, validationContext, validationResults, true);

            Assert.That(isValid, Is.True);
            Assert.That(validationResults, Is.Empty);
        }

        [Test]
        public void Feature_WithoutName_ShouldFailValidation()
        {
            _feature.Name = null;

            var validationContext = new ValidationContext(_feature);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(_feature, validationContext, validationResults, true);

            Assert.That(isValid, Is.False);
            Assert.That(validationResults, Is.Not.Empty);
        }

        [Test]
        public void Feature_NameExceedsMaxLength_ShouldFailValidation()
        {
            _feature.Name = new string('x', 301);

            var validationContext = new ValidationContext(_feature);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(_feature, validationContext, validationResults, true);

            Assert.That(isValid, Is.False);
            Assert.That(validationResults, Is.Not.Empty);
        }

        [Test]
        public void Feature_ShouldSetPropertiesCorrectly()
        {
            var id = Guid.NewGuid();
            var name = "Parking";

            var feature = new Feature { Id = id, Name = name };

            Assert.That(feature.Id, Is.EqualTo(id));
            Assert.That(feature.Name, Is.EqualTo(name));
        }
    }
}
