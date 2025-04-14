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
    public class ReservationModelTests
    {
        private Reservation _reservation;

        [SetUp]
        public void Setup()
        {
            _reservation = new Reservation
            {
                Id = Guid.NewGuid(),
                RestaurantId = Guid.NewGuid(),
                Date = DateTime.Today,
                UserId = "user123",
                Adults = 2,
                Children = 1
            };
        }

        [Test]
        public void Reservation_WithValidData_ShouldPassValidation()
        {
            var validationContext = new ValidationContext(_reservation);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(_reservation, validationContext, validationResults, true);

            Assert.That(isValid, Is.True);
            Assert.That(validationResults, Is.Empty);
        }

        [Test]
        public void Reservation_ShouldSetPropertiesCorrectly()
        {
            var id = Guid.NewGuid();
            var restaurantId = Guid.NewGuid();
            var date = DateTime.Today.AddDays(1);
            var userId = "user456";
            var adults = 3;
            var children = 2;

            var reservation = new Reservation
            {
                Id = id,
                RestaurantId = restaurantId,
                Date = date,
                UserId = userId,
                Adults = adults,
                Children = children
            };

            Assert.That(reservation.Id, Is.EqualTo(id));
            Assert.That(reservation.RestaurantId, Is.EqualTo(restaurantId));
            Assert.That(reservation.Date, Is.EqualTo(date));
            Assert.That(reservation.UserId, Is.EqualTo(userId));
            Assert.That(reservation.Adults, Is.EqualTo(adults));
            Assert.That(reservation.Children, Is.EqualTo(children));
        }

        [Test]
        public void Reservation_WithoutUserId_ShouldFailValidation()
        {
            _reservation.UserId = null;

            var validationContext = new ValidationContext(_reservation);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(_reservation, validationContext, validationResults, true);

            Assert.That(isValid, Is.False);
            Assert.That(validationResults, Is.Not.Empty);
        }
    }
}
