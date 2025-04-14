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
    public class UserEditVM_Tests
    {
        [Test]
        public void UserEditVM_Should_Populate_Correctly()
        {
            // Arrange
            var vm = new UserEditVM
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Тест",
                LastName = "Потребител",
                Email = "test@example.com",
                Age = 28,
                CurrentPassword = "oldPass123",
                NewPassword = "newPass456",
                ConfirmNewPassword = "newPass456"
            };

            // Assert
            Assert.That(vm.Id, Is.Not.Null.And.Not.Empty);
            Assert.That(vm.FirstName, Is.EqualTo("Тест"));
            Assert.That(vm.LastName, Is.EqualTo("Потребител"));
            Assert.That(vm.Email, Is.EqualTo("test@example.com"));
            Assert.That(vm.Age, Is.EqualTo(28));
            Assert.That(vm.CurrentPassword, Is.EqualTo("oldPass123"));
            Assert.That(vm.NewPassword, Is.EqualTo("newPass456"));
            Assert.That(vm.ConfirmNewPassword, Is.EqualTo("newPass456"));
        }
    }
}
