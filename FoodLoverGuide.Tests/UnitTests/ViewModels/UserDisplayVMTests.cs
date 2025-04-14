using FoodLoverGuide.Core.ViewModels.User;
using FoodLoverGuide.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodLoverGuide.Tests.UnitTests.ViewModels
{

    [TestFixture]
    public class UserDisplayVM_Tests
    {
        [Test]
        public void UserDisplayVM_Should_Populate_Correctly()
        {
            // Arrange
            var reservations = new List<Reservation>
            {
                new Reservation
                {
                    Id = Guid.NewGuid(),
                    Date = DateTime.Now,
                    UserId = "user1",
                    RestaurantId = Guid.NewGuid()
                },
                new Reservation
                {
                    Id = Guid.NewGuid(),
                    Date = DateTime.Now.AddDays(1),
                    UserId = "user1",
                    RestaurantId = Guid.NewGuid()
                }
            };

            var vm = new UserDisplayVM
            {
                FirstName = "Тест",
                LastName = "Потребител",
                Age = 25,
                Email = "test@example.com",
                Reservations = reservations
            };

            // Assert
            Assert.That(vm.FirstName, Is.EqualTo("Тест"));
            Assert.That(vm.LastName, Is.EqualTo("Потребител"));
            Assert.That(vm.Age, Is.EqualTo(25));
            Assert.That(vm.Email, Is.EqualTo("test@example.com"));
            Assert.That(vm.Reservations, Is.Not.Null);
            Assert.That(vm.Reservations.Count, Is.EqualTo(2));
        }
    }
}

