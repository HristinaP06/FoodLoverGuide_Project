using FoodLoverGuide.Core.ViewModels.Restaurant;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodLoverGuide.Tests.UnitTests.ViewModels
{
    [TestFixture]
    public class RestaurantCreateVM_Tests
    {
        private bool TryValidateModel(object model, out List<ValidationResult> results)
        {
            var context = new ValidationContext(model, null, null);
            results = new List<ValidationResult>();
            return Validator.TryValidateObject(model, context, results, true);
        }

        [Test]
        public void Model_WithValidData_ShouldBeValid()
        {
            var model = new RestaurantCreateVM
            {
                Name = "Delta",
                Description = "Много хубаво място за хапване.",
                Location = "Казанлък",
                Email = "delta@example.com"
            };

            var isValid = TryValidateModel(model, out var results);

            Assert.That(isValid, Is.True);
            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Model_WithMissingRequiredFields_ShouldBeInvalid()
        {
            var model = new RestaurantCreateVM
            {
                Name = null,
                Description = null,
                Location = null
            };

            var isValid = TryValidateModel(model, out var results);

            Assert.That(isValid, Is.False);
            Assert.That(results.Count, Is.GreaterThanOrEqualTo(3));
            Assert.That(results, Has.Some.Matches<ValidationResult>(r => r.ErrorMessage.Contains("задължително")));
        }

        [Test]
        public void Model_WithTooLongName_ShouldBeInvalid()
        {
            var model = new RestaurantCreateVM
            {
                Name = new string('a', 301),
                Description = "Valid description",
                Location = "Valid location"
            };

            var isValid = TryValidateModel(model, out var results);

            Assert.That(isValid, Is.False);
            Assert.That(results, Has.Some.Matches<ValidationResult>(r => r.ErrorMessage.Contains("максимум 300 знака")));
        }

        [Test]
        public void Model_WithTooLongDescription_ShouldBeInvalid()
        {
            var model = new RestaurantCreateVM
            {
                Name = "Valid",
                Description = new string('a', 3001),
                Location = "Valid"
            };

            var isValid = TryValidateModel(model, out var results);

            Assert.That(isValid, Is.False);
            Assert.That(results, Has.Some.Matches<ValidationResult>(r => r.ErrorMessage.Contains("максимум 3000 знака")));
        }

        [Test]
        public void Model_WithInvalidEmail_ShouldBeInvalid()
        {
            var model = new RestaurantCreateVM
            {
                Name = "Valid",
                Description = "Valid",
                Location = "Valid",
                Email = "notAnEmail"
            };

            var isValid = TryValidateModel(model, out var results);

            Assert.That(isValid, Is.False);
            Assert.That(results, Has.Some.Matches<ValidationResult>(r => r.ErrorMessage.Contains("не е валиден имейл")));
        }
    }
}
