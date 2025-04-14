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
    public class RestaurantCategoriesServiceTests
    {
        private Mock<IRepository> _mockRepository;
        private RestaurantCategoriesService _service;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IRepository>();
            _service = new RestaurantCategoriesService(_mockRepository.Object);
        }

        [Test]
        public async Task Add_ShouldCallAddAsync()
        {
            var entity = new RestaurantCategories { RestaurantId = Guid.NewGuid(), CategoryId = Guid.NewGuid() };
            await _service.Add(entity);
            _mockRepository.Verify(r => r.AddAsync(entity), Times.Once);
        }

        [Test]
        public async Task Delete_ShouldCallDeleteAsync()
        {
            var id = Guid.NewGuid();
            await _service.Delete(id);
            _mockRepository.Verify(r => r.DeleteAsync<RestaurantCategories>(id), Times.Once);
        }

        [Test]
        public async Task Find_ShouldReturnMatchingEntities()
        {
            Expression<Func<RestaurantCategories, bool>> filter = x => x.RestaurantId == Guid.NewGuid();
            var expected = new List<RestaurantCategories>();
            _mockRepository.Setup(r => r.FindAsync(filter)).ReturnsAsync(expected);

            var result = await _service.Find(filter);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetAll_ShouldReturnQueryable()
        {
            var data = new List<RestaurantCategories>().AsQueryable();
            _mockRepository.Setup(r => r.GetAllAsync<RestaurantCategories>()).Returns(data);

            var result = _service.GetAll();
            Assert.That(result, Is.EqualTo(data));
        }

        [Test]
        public async Task GetById_ShouldReturnEntity()
        {
            var id = Guid.NewGuid();
            var expected = new RestaurantCategories { RestaurantId = id };
            _mockRepository.Setup(r => r.GetByIdAsync<RestaurantCategories>(id)).ReturnsAsync(expected);

            var result = await _service.GetById(id);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public async Task Update_ShouldCallUpdateAsync()
        {
            var entity = new RestaurantCategories { RestaurantId = Guid.NewGuid() };
            await _service.Update(entity);
            _mockRepository.Verify(r => r.UpdateAsync(entity), Times.Once);
        }

        [Test]
        public async Task AddRestaurantCategoriesAsync_ShouldAddOnlyMissingCategories()
        {
            // Arrange
            var restaurantId = Guid.NewGuid();
            var existingCategoryId = Guid.NewGuid();
            var newCategoryId = Guid.NewGuid();

            var model = new AddCategoryToRestaurantVM
            {
                RestaurantId = restaurantId,
                SelectedCategoriesIds = new List<Guid> { existingCategoryId, newCategoryId }
            };

            var existingData = new List<RestaurantCategories>
            {
                new RestaurantCategories { RestaurantId = restaurantId, CategoryId = existingCategoryId }
            }.AsQueryable();

            _mockRepository.Setup(r => r.GetAllAsync<RestaurantCategories>())
                .Returns(existingData);

            _mockRepository.Setup(r => r.AddAsync(It.IsAny<RestaurantCategories>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _service.AddRestaurantCategoriesAsync(model);

            // Assert
            _mockRepository.Verify(r => r.AddAsync(It.Is<RestaurantCategories>(
                rc => rc.CategoryId == newCategoryId && rc.RestaurantId == restaurantId
            )), Times.Once);

            _mockRepository.Verify(r => r.AddAsync(It.Is<RestaurantCategories>(
                rc => rc.CategoryId == existingCategoryId
            )), Times.Never);

            Assert.That(result, Is.EqualTo(restaurantId));
        }

    }
}
