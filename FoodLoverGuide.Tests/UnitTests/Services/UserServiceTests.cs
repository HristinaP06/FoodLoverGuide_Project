using FoodLoverGuide.DataAccess.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodLoverGuide.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FoodLoverGuide.Core.Services;
using System.Linq.Expressions;


namespace FoodLoverGuide.Tests.UnitTests.Services
{
    [TestFixture]
    public class UserServiceTests
    {
        private Mock<IRepository> _mockRepository;
        private UserService _service;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IRepository>();
            _service = new UserService(_mockRepository.Object);
        }

        [Test]
        public async Task Add_ShouldCallAddAsync()
        {
            var user = new User { Id = Guid.NewGuid().ToString(), FirstName = "John" };
            await _service.Add(user);
            _mockRepository.Verify(r => r.AddAsync(user), Times.Once);
        }

        [Test]
        public async Task Delete_ShouldCallDeleteAsync()
        {
            var id = Guid.NewGuid();
            await _service.Delete(id);
            _mockRepository.Verify(r => r.DeleteAsync<User>(id), Times.Once);
        }

        [Test]
        public async Task Find_ShouldReturnMatchingUsers()
        {
            Expression<Func<User, bool>> filter = u => u.FirstName.Contains("John");
            var expected = new List<User> { new User { FirstName = "John" } };
            _mockRepository.Setup(r => r.FindAsync(filter)).ReturnsAsync(expected);

            var result = await _service.Find(filter);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetAll_ShouldReturnQueryable()
        {
            var data = new List<User>().AsQueryable();
            _mockRepository.Setup(r => r.GetAllAsync<User>()).Returns(data);

            var result = _service.GetAll();
            Assert.That(result, Is.EqualTo(data));
        }

        [Test]
        public async Task GetById_ShouldReturnCorrectEntity()
        {
            var id = Guid.NewGuid();
            var user = new User { Id = id.ToString() };
            _mockRepository.Setup(r => r.GetByIdAsync<User>(id)).ReturnsAsync(user);

            var result = await _service.GetById(id);
            Assert.That(result, Is.EqualTo(user));
        }

        [Test]
        public async Task Update_ShouldCallUpdateAsync()
        {
            var user = new User { Id = Guid.NewGuid().ToString(), FirstName = "Updated" };
            await _service.Update(user);
            _mockRepository.Verify(r => r.UpdateAsync(user), Times.Once);
        }
    }
}

