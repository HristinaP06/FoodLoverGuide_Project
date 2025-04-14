using FoodLoverGuide.Core.ViewModels.Category;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodLoverGuide.Tests.UnitTests.ViewModels
{
    [TestFixture]
    public class NewCategoryVM_Tests
    {
        private bool TryValidateModel(object model, out List<ValidationResult> results)
        {
            var context = new ValidationContext(model, null, null);
            results = new List<ValidationResult>();
            return Validator.TryValidateObject(model, context, results, true);
        }

        [Test]
        public void Model_WithValidName_ShouldBeValid()
        {
            var model = new NewCategoryVM
            {
                Name = "Италианска кухня"
            };

            var isValid = TryValidateModel(model, out var results);

            Assert.That(isValid, Is.True);
            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Model_WithNullName_ShouldBeInvalid()
        {
            var model = new NewCategoryVM
            {
                Name = null
            };

            var isValid = TryValidateModel(model, out var results);

            Assert.That(isValid, Is.False);
            Assert.That(results, Has.Some.Matches<ValidationResult>(
                r => r.ErrorMessage != null && r.ErrorMessage.Contains("задължително")));
        }

        [Test]
        public void Model_WithTooLongName_ShouldBeInvalid()
        {
            var model = new NewCategoryVM
            {
                Name = new string('a', 301) // над лимита
            };

            var isValid = TryValidateModel(model, out var results);

            Assert.That(isValid, Is.False);
            Assert.That(results, Has.Some.Matches<ValidationResult>(
                r => r.ErrorMessage != null && r.ErrorMessage.Contains("максимум 300 знака")));
        }
    }
}
