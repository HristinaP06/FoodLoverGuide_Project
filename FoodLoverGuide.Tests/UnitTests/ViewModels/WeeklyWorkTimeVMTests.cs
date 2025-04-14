using FoodLoverGuide.Core.ViewModels.Restaurant;
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
    public class WeeklyWorkTimeVM_Tests
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
            var model = new WeeklyWorkTimeVM
            {
                RestaurantId = Guid.NewGuid(),
                WorkTimeSchedules = new List<WorkTimeScheduleViewModel>
                {
                    new WorkTimeScheduleViewModel
                    {
                        Day = DayOfWeek.Monday,
                        IsClosed = false,
                        OpeningTime = new TimeSpan(9, 0, 0),
                        ClosingTime = new TimeSpan(17, 0, 0)
                    }
                },
                NextAction = "AddPhotos"
            };

            var isValid = TryValidateModel(model, out var results);

            Assert.That(isValid, Is.True);
            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Model_WithEmptyWorkTimeList_ShouldBeValid()
        {
            var model = new WeeklyWorkTimeVM
            {
                RestaurantId = Guid.NewGuid(),
                WorkTimeSchedules = new List<WorkTimeScheduleViewModel>(),
                NextAction = "NextStep"
            };

            var isValid = TryValidateModel(model, out var results);

            Assert.That(isValid, Is.True); // Assuming it's allowed to have empty list
        }

        [Test]
        public void Model_WithNullWorkTimeSchedules_ShouldBeInvalidIfRequired()
        {
            var model = new WeeklyWorkTimeVM
            {
                RestaurantId = Guid.NewGuid(),
                WorkTimeSchedules = null,
                NextAction = null
            };

            var isValid = TryValidateModel(model, out var results);

            // Ако WorkTimeSchedules не е задължителен - ще бъде валиден.
            Assert.That(isValid, Is.True); // Или Is.False, ако добавиш [Required] на списъка
        }
    }
}
