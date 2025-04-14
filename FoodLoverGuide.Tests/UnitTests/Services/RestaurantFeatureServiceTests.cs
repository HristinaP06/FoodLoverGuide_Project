using FoodLoverGuide.Core.Services;
using FoodLoverGuide.Core.ViewModels.Restaurant;
using FoodLoverGuide.DataAccess.Repository;
using FoodLoverGuide.Models;
using Microsoft.EntityFrameworkCore;
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
    public class RestaurantFeatureServiceTests
    {
        private Mock<IRepository> _mockRepository;
        private RestaurantFeatureService _service;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IRepository>();
            _service = new RestaurantFeatureService(_mockRepository.Object);
        }

        [Test]
        public async Task Add_ShouldCallAddAsync()
        {
            var entity = new RestaurantFeature { RestaurantId = Guid.NewGuid(), FeatureId = Guid.NewGuid() };
            await _service.Add(entity);
            _mockRepository.Verify(r => r.AddAsync(entity), Times.Once);
        }

        [Test]
        public async Task Delete_ShouldCallDeleteAsync()
        {
            var id = Guid.NewGuid();
            await _service.Delete(id);
            _mockRepository.Verify(r => r.DeleteAsync<RestaurantFeature>(id), Times.Once);
        }

        [Test]
        public async Task Find_ShouldReturnMatchingEntities()
        {
            Expression<Func<RestaurantFeature, bool>> filter = x => x.RestaurantId == Guid.NewGuid();
            var expected = new List<RestaurantFeature>();
            _mockRepository.Setup(r => r.FindAsync(filter)).ReturnsAsync(expected);

            var result = await _service.Find(filter);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetAll_ShouldReturnQueryable()
        {
            var data = new List<RestaurantFeature>().AsQueryable();
            _mockRepository.Setup(r => r.GetAllAsync<RestaurantFeature>()).Returns(data);

            var result = _service.GetAll();
            Assert.That(result, Is.EqualTo(data));
        }

        [Test]
        public async Task GetById_ShouldReturnEntity()
        {
            var id = Guid.NewGuid();
            var expected = new RestaurantFeature { RestaurantId = id };
            _mockRepository.Setup(r => r.GetByIdAsync<RestaurantFeature>(id)).ReturnsAsync(expected);

            var result = await _service.GetById(id);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public async Task Update_ShouldCallUpdateAsync()
        {
            var entity = new RestaurantFeature { RestaurantId = Guid.NewGuid() };
            await _service.Update(entity);
            _mockRepository.Verify(r => r.UpdateAsync(entity), Times.Once);
        }

        [Test]
        public async Task AddRestaurantFeatures_ShouldAddOnlyMissingFeatures()
        {
            // Arrange
            var restaurantId = Guid.NewGuid();
            var existingFeatureId = Guid.NewGuid();
            var newFeatureId = Guid.NewGuid();

            var model = new AddFeatureToRestaurantVM
            {
                RestaurantId = restaurantId,
                SelectedFeaturesIds = new List<Guid> { existingFeatureId, newFeatureId }
            };

            var existingFeatures = new List<RestaurantFeature>
            {
                new RestaurantFeature { RestaurantId = restaurantId, FeatureId = existingFeatureId }
            }.AsQueryable();

            _mockRepository.Setup(r => r.GetAllAsync<RestaurantFeature>())
                .Returns(existingFeatures);

            _mockRepository.Setup(r => r.AddAsync(It.IsAny<RestaurantFeature>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _service.AddRestaurantFeatures(model);

            // Assert
            _mockRepository.Verify(r => r.AddAsync(It.Is<RestaurantFeature>(
                rf => rf.FeatureId == newFeatureId && rf.RestaurantId == restaurantId
            )), Times.Once);

            _mockRepository.Verify(r => r.AddAsync(It.Is<RestaurantFeature>(
                rf => rf.FeatureId == existingFeatureId
            )), Times.Never);

            Assert.That(result, Is.EqualTo(restaurantId));
        }
    }
}
