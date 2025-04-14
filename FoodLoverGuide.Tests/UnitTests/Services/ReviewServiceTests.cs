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
    public class ReviewServiceTests
    {
        private Mock<IRepository> _mockRepository;
        private ReviewService _service;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IRepository>();
            _service = new ReviewService(_mockRepository.Object);
        }

        [Test]
        public async Task Add_ShouldCallAddAsync()
        {
            var entity = new Review { Id = Guid.NewGuid(), Description = "Great!", Rating = 5.0 };
            await _service.Add(entity);
            _mockRepository.Verify(r => r.AddAsync(entity), Times.Once);
        }

        [Test]
        public async Task Delete_ShouldCallDeleteAsync()
        {
            var id = Guid.NewGuid();
            await _service.Delete(id);
            _mockRepository.Verify(r => r.DeleteAsync<Review>(id), Times.Once);
        }

        [Test]
        public async Task Find_ShouldReturnMatchingReviews()
        {
            Expression<Func<Review, bool>> filter = r => r.Rating >= 4;
            var expected = new List<Review> { new Review { Rating = 4.5 } };
            _mockRepository.Setup(r => r.FindAsync(filter)).ReturnsAsync(expected);

            var result = await _service.Find(filter);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetAll_ShouldReturnQueryable()
        {
            var data = new List<Review>().AsQueryable();
            _mockRepository.Setup(r => r.GetAllAsync<Review>()).Returns(data);

            var result = _service.GetAll();
            Assert.That(result, Is.EqualTo(data));
        }

        [Test]
        public async Task GetById_ShouldReturnCorrectEntity()
        {
            var id = Guid.NewGuid();
            var review = new Review { Id = id, Description = "Awesome!" };
            _mockRepository.Setup(r => r.GetByIdAsync<Review>(id)).ReturnsAsync(review);

            var result = await _service.GetById(id);
            Assert.That(result, Is.EqualTo(review));
        }

        [Test]
        public async Task Update_ShouldCallUpdateAsync()
        {
            var review = new Review { Id = Guid.NewGuid(), Description = "Updated review" };
            await _service.Update(review);
            _mockRepository.Verify(r => r.UpdateAsync(review), Times.Once);
        }
    }
}
