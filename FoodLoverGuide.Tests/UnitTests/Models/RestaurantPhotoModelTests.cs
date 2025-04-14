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
    public class RestaurantPhotoModelTests
    {
        private RestaurantPhoto _restaurantPhoto;

        [SetUp]
        public void Setup()
        {
            _restaurantPhoto = new RestaurantPhoto
            {
                Id = Guid.NewGuid(),
                Photo = "photo1.jpg",
                RestaurantId = Guid.NewGuid(),
                Order = 1
            };
        }

        [Test]
        public void RestaurantPhoto_WithValidData_ShouldPassValidation()
        {
            var validationContext = new ValidationContext(_restaurantPhoto);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(_restaurantPhoto, validationContext, validationResults, true);

            Assert.That(isValid, Is.True);
            Assert.That(validationResults, Is.Empty);
        }

        [Test]
        public void RestaurantPhoto_ShouldSetPropertiesCorrectly()
        {
            var id = Guid.NewGuid();
            var photo = "dish1.jpg";
            var restaurantId = Guid.NewGuid();
            var order = 2;

            var rp = new RestaurantPhoto
            {
                Id = id,
                Photo = photo,
                RestaurantId = restaurantId,
                Order = order
            };

            Assert.That(rp.Id, Is.EqualTo(id));
            Assert.That(rp.Photo, Is.EqualTo(photo));
            Assert.That(rp.RestaurantId, Is.EqualTo(restaurantId));
            Assert.That(rp.Order, Is.EqualTo(order));
        }

        [Test]
        public void RestaurantPhoto_ImageFile_ShouldAllowNull()
        {
            _restaurantPhoto.ImageFile = null;
            Assert.That(_restaurantPhoto.ImageFile, Is.Null);
        }
    }
}
