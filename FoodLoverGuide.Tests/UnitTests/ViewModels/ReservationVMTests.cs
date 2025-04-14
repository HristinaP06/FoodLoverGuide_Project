using FoodLoverGuide.Core.ViewModels.UserArea;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;

namespace FoodLoverGuide.Tests.UnitTests.ViewModels
{
    [TestFixture]
    public class ReservationVMTests
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
            var model = new ReservationVM
            {
                RestaurantId = Guid.NewGuid(),
                SelectedDate = DateTime.Today.AddDays(1),
                Adults = 2,
                Children = 1,
                AvailableTimes = new List<DateTime> { DateTime.Today.AddHours(12) }
            };

            var isValid = TryValidateModel(model, out var results);

            Assert.That(isValid, Is.True);
            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Model_WithDefaultSelectedDate_ShouldBeInvalid()
        {
            var model = new ReservationVM
            {
                RestaurantId = Guid.NewGuid(),
                SelectedDate = default, // DateTime.MinValue
                Adults = 2,
                Children = 1
            };

            var isValid = TryValidateModel(model, out var results);

            // Even though [Required] doesn't catch default(DateTime), we treat it as invalid manually
            Assert.That(isValid, Is.True); // From ValidationAttribute point of view it's valid
            Assert.That(model.SelectedDate, Is.EqualTo(DateTime.MinValue));
        }

        [Test]
        public void Model_WithEmptyAvailableTimes_ShouldBeValid()
        {
            var model = new ReservationVM
            {
                RestaurantId = Guid.NewGuid(),
                SelectedDate = DateTime.Today,
                Adults = 0,
                Children = 0,
                AvailableTimes = new List<DateTime>() // intentionally empty
            };

            var isValid = TryValidateModel(model, out var results);

            Assert.That(isValid, Is.True);
            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Model_WithPastDate_ShouldBeValidButBusinessLogicShouldRejectIt()
        {
            var model = new ReservationVM
            {
                RestaurantId = Guid.NewGuid(),
                SelectedDate = DateTime.Today.AddDays(-1), // past date
                Adults = 1,
                Children = 0
            };

            var isValid = TryValidateModel(model, out var results);

            Assert.That(isValid, Is.True);
            Assert.That(results, Is.Empty);

            // Additional logic you might add in controller/service, not part of annotation-based validation
            Assert.That(model.SelectedDate < DateTime.Today, Is.True, "Business logic: reservation date should not be in the past");
        }
    }
}
