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
    public class CategoryServiceTests
    {
        private Mock<IRepository> _mockRepository;
        private CategoryService _service;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IRepository>();
            _service = new CategoryService(_mockRepository.Object);
        }

        [Test]
        public async Task Add_ValidCategory_ShouldCallRepositoryAddAsync()
        {
            var category = new Category { Id = Guid.NewGuid(), CategoryName = "Pizza" };

            await _service.Add(category);

            _mockRepository.Verify(r => r.AddAsync(category), Times.Once);
        }

        [Test]
        public async Task Delete_ValidId_ShouldCallRepositoryDeleteAsync()
        {
            var id = Guid.NewGuid();

            await _service.Delete(id);

            _mockRepository.Verify(r => r.DeleteAsync<Category>(id), Times.Once);
        }

        [Test]
        public async Task Find_ValidFilter_ShouldCallRepositoryFindAsync()
        {
            Expression<Func<Category, bool>> filter = c => c.CategoryName.Contains("Pizza");
            var expected = new List<Category> { new Category { CategoryName = "Pizza" } };
            _mockRepository.Setup(r => r.FindAsync(filter)).ReturnsAsync(expected);

            var result = await _service.Find(filter);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetAll_ShouldCallRepositoryGetAllAsync()
        {
            var queryable = new List<Category>().AsQueryable();
            _mockRepository.Setup(r => r.GetAllAsync<Category>()).Returns(queryable);

            var result = _service.GetAll();

            Assert.That(result, Is.EqualTo(queryable));
        }

        [Test]
        public async Task GetById_ValidId_ShouldCallRepositoryGetByIdAsync()
        {
            var id = Guid.NewGuid();
            var category = new Category { Id = id, CategoryName = "Sushi" };
            _mockRepository.Setup(r => r.GetByIdAsync<Category>(id)).ReturnsAsync(category);

            var result = await _service.GetById(id);

            Assert.That(result, Is.EqualTo(category));
        }

        [Test]
        public async Task Update_ValidCategory_ShouldCallRepositoryUpdateAsync()
        {
            var category = new Category { Id = Guid.NewGuid(), CategoryName = "Burger" };

            await _service.Update(category);

            _mockRepository.Verify(r => r.UpdateAsync(category), Times.Once);
        }

        [Test]
        public void GetRestaurantCategory_ShouldThrowNotImplementedException()
        {
            var restaurantId = Guid.NewGuid();

            Assert.Throws<NotImplementedException>(() => _service.GetRestaurantCategory(restaurantId));
        }
    }
}
