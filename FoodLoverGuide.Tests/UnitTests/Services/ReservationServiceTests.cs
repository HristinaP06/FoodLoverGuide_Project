using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Core.Services;
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
    public class ReservationServiceTests
    {
        private Mock<IRepository> _mockRepository;
        private Mock<IWorkTimeScheduleService> _mockScheduleService;
        private Mock<IRestaurantService> _mockRestaurantService;
        private ReservationService _service;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IRepository>();
            _mockScheduleService = new Mock<IWorkTimeScheduleService>();
            _mockRestaurantService = new Mock<IRestaurantService>();
            _service = new ReservationService(_mockRepository.Object, _mockScheduleService.Object, _mockRestaurantService.Object);
        }

        [Test]
        public async Task Add_ShouldCallAddAsync()
        {
            var reservation = new Reservation { Id = Guid.NewGuid() };
            await _service.Add(reservation);
            _mockRepository.Verify(r => r.AddAsync(reservation), Times.Once);
        }

        [Test]
        public async Task Delete_ShouldCallDeleteAsync()
        {
            var id = Guid.NewGuid();
            await _service.Delete(id);
            _mockRepository.Verify(r => r.DeleteAsync<Reservation>(id), Times.Once);
        }

        [Test]
        public async Task Find_ShouldCallFindAsync()
        {
            Expression<Func<Reservation, bool>> filter = r => r.UserId == "user1";
            var expected = new List<Reservation>();
            _mockRepository.Setup(r => r.FindAsync(filter)).ReturnsAsync(expected);

            var result = await _service.Find(filter);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetAll_ShouldCallGetAllAsync()
        {
            var data = new List<Reservation>().AsQueryable();
            _mockRepository.Setup(r => r.GetAllAsync<Reservation>()).Returns(data);

            var result = _service.GetAll();
            Assert.That(result, Is.EqualTo(data));
        }

        [Test]
        public async Task GetById_ShouldReturnReservation()
        {
            var id = Guid.NewGuid();
            var reservation = new Reservation { Id = id };
            _mockRepository.Setup(r => r.GetByIdAsync<Reservation>(id)).ReturnsAsync(reservation);

            var result = await _service.GetById(id);
            Assert.That(result, Is.EqualTo(reservation));
        }

        [Test]
        public async Task Update_ShouldCallUpdateAsync()
        {
            var reservation = new Reservation { Id = Guid.NewGuid() };
            await _service.Update(reservation);
            _mockRepository.Verify(r => r.UpdateAsync(reservation), Times.Once);
        }

        [Test]
        public async Task IsRestaurantOpen_WhenScheduleIsNullOrClosed_ReturnsFalse()
        {
            _mockScheduleService.Setup(s => s.Find(It.IsAny<Expression<Func<WorkTimeSchedule, bool>>>()))
                .ReturnsAsync(new List<WorkTimeSchedule>());

            var result = await _service.IsRestaurantOpen(Guid.NewGuid(), DateTime.Now);
            Assert.That(result, Is.False);
        }

        [Test]
        public async Task IsRestaurantOpen_WhenWithinWorkingHours_ReturnsTrue()
        {
            var now = DateTime.Today.AddHours(12);
            _mockScheduleService.Setup(s => s.Find(It.IsAny<Expression<Func<WorkTimeSchedule, bool>>>()))
                .ReturnsAsync(new List<WorkTimeSchedule>
                {
                    new WorkTimeSchedule
                    {
                        OpeningTime = new TimeSpan(10, 0, 0),
                        ClosingTime = new TimeSpan(22, 0, 0),
                        IsClosed = false
                    }
                });

            var result = await _service.IsRestaurantOpen(Guid.NewGuid(), now);
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task HasAvailableSeats_WhenRestaurantIsNull_ReturnsFalse()
        {
            _mockRestaurantService.Setup(r => r.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Restaurant)null);
            var result = await _service.HasAvailableSeats(Guid.NewGuid(), DateTime.Today, 2);
            Assert.That(result, Is.False);
        }

        [Test]
        public async Task HasAvailableSeats_WhenWithinCapacity_ReturnsTrue()
        {
            var restaurant = new Restaurant { IndoorCapacity = 10, OutdoorCapacity = 10 };
            _mockRestaurantService.Setup(r => r.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(restaurant);
            _mockRepository.Setup(r => r.FindAsync(It.IsAny<Expression<Func<Reservation, bool>>>()))
                .ReturnsAsync(new List<Reservation>
                {
                    new Reservation { Adults = 2, Children = 1 },
                    new Reservation { Adults = 3, Children = 0 }
                });

            var result = await _service.HasAvailableSeats(Guid.NewGuid(), DateTime.Today, 4);
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task IsDuplicateReservation_WhenExists_ReturnsTrue()
        {
            _mockRepository.Setup(r => r.FindAsync(It.IsAny<Expression<Func<Reservation, bool>>>()))
                .ReturnsAsync(new List<Reservation> { new Reservation() });

            var result = await _service.IsDuplicateReservation(Guid.NewGuid(), "user1", DateTime.Today);
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task GetAvailableTimes_WhenClosed_ReturnsEmptyList()
        {
            _mockScheduleService.Setup(s => s.Find(It.IsAny<Expression<Func<WorkTimeSchedule, bool>>>()))
                .ReturnsAsync(new List<WorkTimeSchedule> { new WorkTimeSchedule { IsClosed = true } });

            var result = await _service.GetAvailableTimes(Guid.NewGuid(), DateTime.Today);
            Assert.That(result, Is.Empty);
        }

        [Test]
        public async Task GetAvailableTimes_WhenOpen_ReturnsTimes()
        {
            _mockScheduleService.Setup(s => s.Find(It.IsAny<Expression<Func<WorkTimeSchedule, bool>>>()))
                .ReturnsAsync(new List<WorkTimeSchedule> {
                    new WorkTimeSchedule
                    {
                        IsClosed = false,
                        OpeningTime = new TimeSpan(10, 0, 0),
                        ClosingTime = new TimeSpan(20, 0, 0)
                    }
                });

            var result = await _service.GetAvailableTimes(Guid.NewGuid(), DateTime.Today);
            Assert.That(result, Is.Not.Empty);
        }
    }
}
