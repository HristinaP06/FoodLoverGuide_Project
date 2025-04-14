using FoodLoverGuide.Core.Services;
using FoodLoverGuide.Core.ViewModels.Restaurant;
using FoodLoverGuide.DataAccess.Repository;
using FoodLoverGuide.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FoodLoverGuide.Tests.UnitTests.Services
{

    [TestFixture]
    public class WorkTimeScheduleServiceTests
    {
        private Mock<IRepository> _mockRepository;
        private WorkTimeScheduleService _service;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IRepository>();
            _service = new WorkTimeScheduleService(_mockRepository.Object);
        }

        [Test]
        public async Task Add_ShouldCallAddAsync()
        {
            var entity = new WorkTimeSchedule { Id = Guid.NewGuid(), Day = DayOfWeek.Monday };
            await _service.Add(entity);
            _mockRepository.Verify(r => r.AddAsync(entity), Times.Once);
        }

        [Test]
        public async Task Delete_ShouldCallDeleteAsync()
        {
            var id = Guid.NewGuid();
            await _service.Delete(id);
            _mockRepository.Verify(r => r.DeleteAsync<WorkTimeSchedule>(id), Times.Once);
        }

        [Test]
        public async Task Find_ShouldReturnMatchingSchedules()
        {
            Expression<Func<WorkTimeSchedule, bool>> filter = w => w.Day == DayOfWeek.Tuesday;
            var expected = new List<WorkTimeSchedule> { new WorkTimeSchedule { Day = DayOfWeek.Tuesday } };
            _mockRepository.Setup(r => r.FindAsync(filter)).ReturnsAsync(expected);

            var result = await _service.Find(filter);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetAll_ShouldReturnQueryable()
        {
            var data = new List<WorkTimeSchedule>().AsQueryable();
            _mockRepository.Setup(r => r.GetAllAsync<WorkTimeSchedule>()).Returns(data);

            var result = _service.GetAll();
            Assert.That(result, Is.EqualTo(data));
        }

        [Test]
        public async Task GetById_ShouldReturnEntity()
        {
            var id = Guid.NewGuid();
            var schedule = new WorkTimeSchedule { Id = id };
            _mockRepository.Setup(r => r.GetByIdAsync<WorkTimeSchedule>(id)).ReturnsAsync(schedule);

            var result = await _service.GetById(id);
            Assert.That(result, Is.EqualTo(schedule));
        }

        [Test]
        public async Task Update_ShouldCallUpdateAsync()
        {
            var entity = new WorkTimeSchedule { Id = Guid.NewGuid() };
            await _service.Update(entity);
            _mockRepository.Verify(r => r.UpdateAsync(entity), Times.Once);
        }

        [Test]
        public async Task AddWorkTimeToRestaurant_ShouldAddAllDays()
        {
            var model = new WeeklyWorkTimeVM
            {
                RestaurantId = Guid.NewGuid(),
                WorkTimeSchedules = new List<WorkTimeScheduleViewModel>
        {
            new WorkTimeScheduleViewModel
            {
                Day = DayOfWeek.Monday,
                OpeningTime = TimeSpan.FromHours(10),
                ClosingTime = TimeSpan.FromHours(22),
                IsClosed = false
            },
            new WorkTimeScheduleViewModel
            {
                Day = DayOfWeek.Tuesday,
                IsClosed = true
            }
        }
            };

            var result = await _service.AddWorkTimeToRestaurant(model);

            _mockRepository.Verify(r => r.AddAsync(It.IsAny<WorkTimeSchedule>()), Times.Exactly(model.WorkTimeSchedules.Count));
            Assert.That(result, Is.EqualTo(model.RestaurantId));
        }


        [Test]
        public async Task UpdateWorkTimeForRestaurantAsync_ShouldRemoveAndAddAll()
        {
            var restaurantId = Guid.NewGuid();
            var existing = new List<WorkTimeSchedule>
            {
                new WorkTimeSchedule { RestaurantId = restaurantId, Day = DayOfWeek.Monday },
                new WorkTimeSchedule { RestaurantId = restaurantId, Day = DayOfWeek.Tuesday }
            };

            var model = new WeeklyWorkTimeVM
            {
                RestaurantId = restaurantId,
                WorkTimeSchedules = new List<WorkTimeScheduleViewModel>
    {
        new WorkTimeScheduleViewModel { Day = DayOfWeek.Wednesday, OpeningTime = TimeSpan.FromHours(10), ClosingTime = TimeSpan.FromHours(20) },
        new WorkTimeScheduleViewModel { Day = DayOfWeek.Thursday, IsClosed = true }
    }
            };


            _mockRepository.Setup(r => r.GetAllAsync<WorkTimeSchedule>()).Returns(existing.AsQueryable());

            var result = await _service.UpdateWorkTimeForRestaurantAsync(model);

            _mockRepository.Verify(r => r.DeleteAsync(It.IsAny<WorkTimeSchedule>()), Times.Exactly(existing.Count));
            _mockRepository.Verify(r => r.AddAsync(It.IsAny<WorkTimeSchedule>()), Times.Exactly(model.WorkTimeSchedules.Count));
            Assert.That(result, Is.EqualTo(model.RestaurantId));
        }
    }

}
