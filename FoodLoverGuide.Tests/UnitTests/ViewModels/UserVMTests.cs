using FoodLoverGuide.Core.ViewModels.User;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodLoverGuide.Tests.UnitTests.ViewModels
{

    [TestFixture]
    public class UserVM_Tests
    {
        [Test]
        public void UserVM_Should_Populate_Correctly()
        {
            // Arrange
            var userVM = new UserVM
            {
                Id = "123",
                FirstName = "Тест",
                LastName = "Потребител",
                Email = "test@example.com",
                Role = "Admin"
            };

            // Assert
            Assert.That(userVM.Id, Is.EqualTo("123"));
            Assert.That(userVM.FirstName, Is.EqualTo("Тест"));
            Assert.That(userVM.LastName, Is.EqualTo("Потребител"));
            Assert.That(userVM.Email, Is.EqualTo("test@example.com"));
            Assert.That(userVM.Role, Is.EqualTo("Admin"));
        }
    }
}
