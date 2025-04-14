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
    public class FeatureServiceTests
    {
        private Mock<IRepository> _mockRepository;
        private FeatureService _service;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IRepository>();
            _service = new FeatureService(_mockRepository.Object);
        }

        [Test]
        public async Task Add_ValidFeature_ShouldCallRepositoryAddAsync()
        {
            var feature = new Feature { Id = Guid.NewGuid(), Name = "WiFi" };

            await _service.Add(feature);

            _mockRepository.Verify(r => r.AddAsync(feature), Times.Once);
        }

        [Test]
        public async Task Delete_ValidId_ShouldCallRepositoryDeleteAsync()
        {
            var id = Guid.NewGuid();

            await _service.Delete(id);

            _mockRepository.Verify(r => r.DeleteAsync<Feature>(id), Times.Once);
        }

        [Test]
        public async Task Find_ValidFilter_ShouldCallRepositoryFindAsync()
        {
            Expression<Func<Feature, bool>> filter = f => f.Name.Contains("WiFi");
            var expected = new List<Feature> { new Feature { Name = "WiFi" } };
            _mockRepository.Setup(r => r.FindAsync(filter)).ReturnsAsync(expected);

            var result = await _service.Find(filter);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetAll_ShouldCallRepositoryGetAllAsync()
        {
            var queryable = new List<Feature>().AsQueryable();
            _mockRepository.Setup(r => r.GetAllAsync<Feature>()).Returns(queryable);

            var result = _service.GetAll();

            Assert.That(result, Is.EqualTo(queryable));
        }

        [Test]
        public async Task GetById_ValidId_ShouldCallRepositoryGetByIdAsync()
        {
            var id = Guid.NewGuid();
            var feature = new Feature { Id = id, Name = "Parking" };
            _mockRepository.Setup(r => r.GetByIdAsync<Feature>(id)).ReturnsAsync(feature);

            var result = await _service.GetById(id);

            Assert.That(result, Is.EqualTo(feature));
        }

        [Test]
        public async Task Update_ValidFeature_ShouldCallRepositoryUpdateAsync()
        {
            var feature = new Feature { Id = Guid.NewGuid(), Name = "Air Conditioning" };

            await _service.Update(feature);

            _mockRepository.Verify(r => r.UpdateAsync(feature), Times.Once);
        }
    }
}
