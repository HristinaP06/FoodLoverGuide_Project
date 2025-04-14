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
    public class WorkTimeScheduleModelTests
    {
        private WorkTimeSchedule _schedule;

        [SetUp]
        public void Setup()
        {
            _schedule = new WorkTimeSchedule
            {
                Id = Guid.NewGuid(),
                RestaurantId = Guid.NewGuid(),
                Day = DayOfWeek.Monday,
                OpeningTime = new TimeSpan(10, 0, 0),
                ClosingTime = new TimeSpan(22, 0, 0),
                IsClosed = false
            };
        }

        [Test]
        public void WorkTimeSchedule_WithValidData_ShouldPassValidation()
        {
            var validationContext = new ValidationContext(_schedule);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(_schedule, validationContext, validationResults, true);

            Assert.That(isValid, Is.True);
            Assert.That(validationResults, Is.Empty);
        }

        [Test]
        public void WorkTimeSchedule_ShouldSetPropertiesCorrectly()
        {
            var id = Guid.NewGuid();
            var restaurantId = Guid.NewGuid();
            var day = DayOfWeek.Sunday;
            var opening = new TimeSpan(11, 30, 0);
            var closing = new TimeSpan(20, 0, 0);

            var schedule = new WorkTimeSchedule
            {
                Id = id,
                RestaurantId = restaurantId,
                Day = day,
                OpeningTime = opening,
                ClosingTime = closing
            };

            Assert.That(schedule.Id, Is.EqualTo(id));
            Assert.That(schedule.RestaurantId, Is.EqualTo(restaurantId));
            Assert.That(schedule.Day, Is.EqualTo(day));
            Assert.That(schedule.OpeningTime, Is.EqualTo(opening));
            Assert.That(schedule.ClosingTime, Is.EqualTo(closing));
        }

        [Test]
        public void WorkTimeSchedule_IsClosed_ShouldBeFalseByDefault()
        {
            var schedule = new WorkTimeSchedule();
            Assert.That(schedule.IsClosed, Is.False);
        }
    }
}
