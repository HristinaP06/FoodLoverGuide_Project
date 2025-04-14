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
    public class AddCategoryToRestaurantVM_Tests
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
            var model = new AddCategoryToRestaurantVM
            {
                RestaurantId = Guid.NewGuid(),
                SelectedCategoriesIds = new List<Guid>
                {
                    Guid.NewGuid(), Guid.NewGuid()
                },
                CategoriesList = new List<Category>
                {
                    new Category { Id = Guid.NewGuid(), CategoryName = "Италианска кухня" }
                },
                NextAction = "AssignFeatures"
            };

            var isValid = TryValidateModel(model, out var results);

            Assert.That(isValid, Is.True);
            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Model_WithEmptySelectedCategories_ShouldBeValid()
        {
            var model = new AddCategoryToRestaurantVM
            {
                RestaurantId = Guid.NewGuid(),
                SelectedCategoriesIds = new List<Guid>(), // празен списък
                CategoriesList = new List<Category>(), // също е позволено
                NextAction = "NextStep"
            };

            var isValid = TryValidateModel(model, out var results);

            Assert.That(isValid, Is.True); // няма ограничения за Required
            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Model_WithMissingNextAction_ShouldStillBeValid()
        {
            var model = new AddCategoryToRestaurantVM
            {
                RestaurantId = Guid.NewGuid(),
                SelectedCategoriesIds = new List<Guid> { Guid.NewGuid() },
                CategoriesList = new List<Category>()
                // NextAction = null – позволено
            };

            var isValid = TryValidateModel(model, out var results);

            Assert.That(isValid, Is.True);
        }
    }
}
