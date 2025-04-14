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
    public class MenuItemModelTests
    {
        private MenuItem _menuItem;

        [SetUp]
        public void Setup()
        {
            _menuItem = new MenuItem
            {
                Id = Guid.NewGuid(),
                Photo = "photo.jpg",
                RestaurantId = Guid.NewGuid(),
                Order = 1
            };
        }

        [Test]
        public void MenuItem_WithValidData_ShouldPassValidation()
        {
            var validationContext = new ValidationContext(_menuItem);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(_menuItem, validationContext, validationResults, true);

            Assert.That(isValid, Is.True);
            Assert.That(validationResults, Is.Empty);
        }

        [Test]
        public void MenuItem_ShouldSetPropertiesCorrectly()
        {
            var id = Guid.NewGuid();
            var photo = "dish.jpg";
            var restaurantId = Guid.NewGuid();
            var order = 2;

            var menuItem = new MenuItem
            {
                Id = id,
                Photo = photo,
                RestaurantId = restaurantId,
                Order = order
            };

            Assert.That(menuItem.Id, Is.EqualTo(id));
            Assert.That(menuItem.Photo, Is.EqualTo(photo));
            Assert.That(menuItem.RestaurantId, Is.EqualTo(restaurantId));
            Assert.That(menuItem.Order, Is.EqualTo(order));
        }

        [Test]
        public void MenuItem_ImageFile_ShouldAllowNull()
        {
            _menuItem.ImageFile = null;
            Assert.That(_menuItem.ImageFile, Is.Null);
        }
    }
}
