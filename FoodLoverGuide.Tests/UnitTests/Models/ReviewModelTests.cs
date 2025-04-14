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
    public class ReviewModelTests
    {
        private Review _review;

        [SetUp]
        public void Setup()
        {
            _review = new Review
            {
                Id = Guid.NewGuid(),
                Rating = 4.5,
                Description = "Great experience",
                RestaurantId = Guid.NewGuid(),
                UserId = "user123"
            };
        }

        [Test]
        public void Review_WithValidData_ShouldPassValidation()
        {
            var validationContext = new ValidationContext(_review);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(_review, validationContext, validationResults, true);

            Assert.That(isValid, Is.True);
            Assert.That(validationResults, Is.Empty);
        }

        [Test]
        public void Review_ShouldSetPropertiesCorrectly()
        {
            var id = Guid.NewGuid();
            var rating = 5.0;
            var description = "Amazing food and service";
            var restaurantId = Guid.NewGuid();
            var userId = "user456";

            var review = new Review
            {
                Id = id,
                Rating = rating,
                Description = description,
                RestaurantId = restaurantId,
                UserId = userId
            };

            Assert.That(review.Id, Is.EqualTo(id));
            Assert.That(review.Rating, Is.EqualTo(rating));
            Assert.That(review.Description, Is.EqualTo(description));
            Assert.That(review.RestaurantId, Is.EqualTo(restaurantId));
            Assert.That(review.UserId, Is.EqualTo(userId));
        }

        [Test]
        public void Review_DescriptionExceedsMaxLength_ShouldFailValidation()
        {
            _review.Description = new string('a', 1001);

            var validationContext = new ValidationContext(_review);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(_review, validationContext, validationResults, true);

            Assert.That(isValid, Is.False);
            Assert.That(validationResults, Is.Not.Empty);
        }
    }
}
