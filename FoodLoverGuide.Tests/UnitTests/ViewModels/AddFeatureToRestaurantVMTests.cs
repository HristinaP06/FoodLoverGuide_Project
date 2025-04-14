using FoodLoverGuide.Core.ViewModels.Restaurant;
using FoodLoverGuide.Models;
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
    public class AddFeatureToRestaurantVM_Tests
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
            var model = new AddFeatureToRestaurantVM
            {
                RestaurantId = Guid.NewGuid(),
                SelectedFeaturesIds = new List<Guid>
                {
                    Guid.NewGuid(), Guid.NewGuid()
                },
                FeaturesList = new List<Feature>
                {
                    new Feature { Id = Guid.NewGuid(), Name = "Паркинг" }
                },
                NextAction = "CreateWorkTimeSchedule"
            };

            var isValid = TryValidateModel(model, out var results);

            Assert.That(isValid, Is.True);
            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Model_WithEmptySelectedFeatures_ShouldBeValid()
        {
            var model = new AddFeatureToRestaurantVM
            {
                RestaurantId = Guid.NewGuid(),
                SelectedFeaturesIds = new List<Guid>(), // празен списък
                FeaturesList = new List<Feature>(),
                NextAction = "NextStep"
            };

            var isValid = TryValidateModel(model, out var results);

            Assert.That(isValid, Is.True);
            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Model_WithMissingNextAction_ShouldStillBeValid()
        {
            var model = new AddFeatureToRestaurantVM
            {
                RestaurantId = Guid.NewGuid(),
                SelectedFeaturesIds = new List<Guid> { Guid.NewGuid() },
                FeaturesList = new List<Feature>()
                // NextAction = null
            };

            var isValid = TryValidateModel(model, out var results);

            Assert.That(isValid, Is.True);
        }
    }
}
