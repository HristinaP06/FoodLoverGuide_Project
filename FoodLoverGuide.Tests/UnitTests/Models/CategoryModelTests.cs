using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FoodLoverGuide.Models;
using NUnit.Framework;

namespace FoodLoverGuide.Tests.UnitTests.Models
{
    [TestFixture]
    public class CategoryModelTests
    {
        private Category _category;

        [SetUp]
        public void Setup()
        {
            _category = new Category
            {
                Id = Guid.NewGuid(),
                CategoryName = "Traditional"
            };
        }

        [Test]
        public void Category_WhenCreated_ShouldHaveEmptyRestaurantCategoriesList()
        {
            var category = new Category();

            Assert.That(category.RestaurantCategoriesList, Is.Not.Null);
            Assert.That(category.RestaurantCategoriesList, Is.Empty);
        }

        [Test]
        public void Category_WithValidData_ShouldPassValidation()
        {
            var validationContext = new ValidationContext(_category);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(_category, validationContext, validationResults, true);

            Assert.That(isValid, Is.True);
            Assert.That(validationResults, Is.Empty);
        }

        [Test]
        public void Category_WithoutCategoryName_ShouldFailValidation()
        {
            _category.CategoryName = null;

            var validationContext = new ValidationContext(_category);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(_category, validationContext, validationResults, true);

            Assert.That(isValid, Is.False);
            Assert.That(validationResults, Is.Not.Empty);
        }

        [Test]
        public void Category_CategoryNameExceedsMaxLength_ShouldFailValidation()
        {
            _category.CategoryName = new string('a', 301);

            var validationContext = new ValidationContext(_category);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(_category, validationContext, validationResults, true);

            Assert.That(isValid, Is.False);
            Assert.That(validationResults, Is.Not.Empty);
        }

        [Test]
        public void Category_ShouldSetPropertiesCorrectly()
        {
            var id = Guid.NewGuid();
            var name = "Seafood";

            var category = new Category { Id = id, CategoryName = name };

            Assert.That(category.Id, Is.EqualTo(id));
            Assert.That(category.CategoryName, Is.EqualTo(name));
        }
    }
}

