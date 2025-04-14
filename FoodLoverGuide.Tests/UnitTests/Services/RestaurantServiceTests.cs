using FoodLoverGuide.Core.IServices;
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
    public class RestaurantServiceTests
    {
        private Mock<IRepository> _mockRepository;
        private Mock<IRestaurantCategoriesService> _mockCategoriesService;
        private RestaurantService _service;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IRepository>();
            _mockCategoriesService = new Mock<IRestaurantCategoriesService>();
            _service = new RestaurantService(_mockRepository.Object, _mockCategoriesService.Object);
        }

        [Test]
        public async Task AddRestaurantAsync_ShouldCallAddAsync()
        {
            var model = new RestaurantCreateVM { Name = "Test", Description = "Desc", Location = "Loc" };
            var result = await _service.AddRestaurantAsync(model);
            _mockRepository.Verify(r => r.AddAsync(It.Is<Restaurant>(res => res.Name == model.Name)), Times.Once);
        }

        [Test]
        public async Task DeleteRestaurantAsync_ShouldCallDeleteAsync()
        {
            var id = Guid.NewGuid();
            await _service.DeleteRestaurantAsync(id);
            _mockRepository.Verify(r => r.DeleteAsync<Restaurant>(id), Times.Once);
        }

        [Test]
        public async Task Find_ShouldReturnFilteredRestaurants()
        {
            Expression<Func<Restaurant, bool>> filter = r => r.Name.Contains("A");
            var list = new List<Restaurant> { new Restaurant { Name = "A" } };
            _mockRepository.Setup(r => r.FindAsync(filter)).ReturnsAsync(list);
            var result = await _service.Find(filter);
            Assert.That(result, Is.EqualTo(list));
        }

        [Test]
        public void GetAllRestaurants_ShouldFilterByNameAndStatus()
        {
            var restaurants = new List<Restaurant>
            {
                new Restaurant { Name = "A", IsActive = true },
                new Restaurant { Name = "B", IsActive = false }
            }.AsQueryable();

            _mockRepository.Setup(r => r.GetAllAsync<Restaurant>()).Returns(restaurants);

            var result = _service.GetAllRestaurants("a", true);
            Assert.That(result.Count(), Is.EqualTo(1));
        }

        [Test]
        public async Task GetByIdAsync_ShouldReturnCorrectEntity()
        {
            var id = Guid.NewGuid();
            var entity = new Restaurant { Id = id };
            _mockRepository.Setup(r => r.GetByIdAsync<Restaurant>(id)).ReturnsAsync(entity);
            var result = await _service.GetByIdAsync(id);
            Assert.That(result, Is.EqualTo(entity));
        }

        [Test]
        public async Task UpdateAsync_ShouldCallUpdateAsync()
        {
            var model = new RestaurantCreateVM { Id = Guid.NewGuid(), Name = "Updated" };
            await _service.UpdateAsync(model);
            _mockRepository.Verify(r => r.UpdateAsync(It.Is<Restaurant>(r => r.Id == model.Id)), Times.Once);
        }

        [Test]
        public async Task ActivateAsync_WhenNotActive_ShouldUpdate()
        {
            var restaurant = new Restaurant { IsActive = false };
            await _service.ActivateAsync(restaurant);
            Assert.That(restaurant.IsActive, Is.True);
            _mockRepository.Verify(r => r.UpdateAsync(restaurant), Times.Once);
        }

        [Test]
        public async Task ActivateAsync_WhenAlreadyActive_ShouldNotUpdate()
        {
            var restaurant = new Restaurant { IsActive = true };
            await _service.ActivateAsync(restaurant);
            _mockRepository.Verify(r => r.UpdateAsync(restaurant), Times.Never);
        }

        [Test]
        public async Task DeactivateAsync_WhenActive_ShouldUpdate()
        {
            var restaurant = new Restaurant { IsActive = true };
            await _service.DeactivateAsync(restaurant);
            Assert.That(restaurant.IsActive, Is.False);
            _mockRepository.Verify(r => r.UpdateAsync(restaurant), Times.Once);
        }

        [Test]
        public async Task DeactivateAsync_WhenAlreadyInactive_ShouldNotUpdate()
        {
            var restaurant = new Restaurant { IsActive = false };
            await _service.DeactivateAsync(restaurant);
            _mockRepository.Verify(r => r.UpdateAsync(restaurant), Times.Never);
        }

        [Test]
        public void GetRestaurantsWithFilters_ShouldFilterByCategory()
        {
            var categoryId = Guid.NewGuid();
            var restaurant = new Restaurant
            {
                RestaurantCategoriesList = new List<RestaurantCategories>
        {
            new RestaurantCategories { CategoryId = categoryId }
        }
            };

            var data = new List<Restaurant> { restaurant }.AsQueryable();

            _mockRepository.Setup(r => r.GetAllAsync<Restaurant>())
                .Returns(data);

            var result = _service.GetRestaurantsWithFilters(new[] { categoryId.ToString() });

            Assert.That(result, Is.Not.Empty);
        }

        [Test]
        public void GetRestaurantsWithFilters_ShouldFilterByFeature()
        {
            var featureId = Guid.NewGuid();
            var restaurant = new Restaurant
            {
                Features = new List<RestaurantFeature>
        {
            new RestaurantFeature { FeatureId = featureId }
        }
            };

            var data = new List<Restaurant> { restaurant }.AsQueryable();

            _mockRepository.Setup(r => r.GetAllAsync<Restaurant>())
                .Returns(data);

            var result = _service.GetRestaurantsWithFilters(null, new[] { featureId.ToString() });

            Assert.That(result, Is.Not.Empty);
        }

        [Test]
        public void GetRestaurantsWithFilters_ShouldFilterByPriceRange_Budget()
        {
            var restaurant = new Restaurant
            {
                PriceRangeTo = 17 // fits "budget"
            };

            var data = new List<Restaurant> { restaurant }.AsQueryable();

            _mockRepository.Setup(r => r.GetAllAsync<Restaurant>())
                .Returns(data);

            var result = _service.GetRestaurantsWithFilters(priceRange: "budget");

            Assert.That(result, Is.Not.Empty);
        }

        [Test]
        public void GetRestaurantsWithFilters_ShouldFilterByPriceRange_Premium()
        {
            var restaurant = new Restaurant
            {
                PriceRangeTo = 50 // fits "premium"
            };

            var data = new List<Restaurant> { restaurant }.AsQueryable();

            _mockRepository.Setup(r => r.GetAllAsync<Restaurant>())
                .Returns(data);

            var result = _service.GetRestaurantsWithFilters(priceRange: "premium");

            Assert.That(result, Is.Not.Empty);
        }

        [Test]
        public void GetRestaurantsWithFilters_ShouldFilterByRating()
        {
            var restaurant = new Restaurant
            {
                Reviews = new List<Review>
        {
            new Review { Rating = 5 },
            new Review { Rating = 4 }
        }
            };

            var data = new List<Restaurant> { restaurant }.AsQueryable();

            _mockRepository.Setup(r => r.GetAllAsync<Restaurant>())
                .Returns(data);

            var result = _service.GetRestaurantsWithFilters(rating: "4.5");

            Assert.That(result, Is.Not.Empty);
        }
    }
}
