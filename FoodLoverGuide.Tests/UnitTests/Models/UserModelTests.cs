using FoodLoverGuide.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodLoverGuide.Tests.UnitTests.Models
{
    [TestFixture]
    public class UserModelTests
    {
        private User _user;

        [SetUp]
        public void Setup()
        {
            _user = new User
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "John",
                LastName = "Doe",
                Age = 30,
                UserName = "johndoe",
                Email = "john@example.com"
            };
        }

        [Test]
        public void User_WithValidData_ShouldPassValidation()
        {
            var validationContext = new ValidationContext(_user);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(_user, validationContext, validationResults, true);

            Assert.That(isValid, Is.True);
            Assert.That(validationResults, Is.Empty);
        }

        [Test]
        public void User_ShouldSetPropertiesCorrectly()
        {
            var id = Guid.NewGuid().ToString();
            var firstName = "Anna";
            var lastName = "Smith";
            var age = 25;

            var user = new User
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Age = age
            };

            Assert.That(user.Id, Is.EqualTo(id));
            Assert.That(user.FirstName, Is.EqualTo(firstName));
            Assert.That(user.LastName, Is.EqualTo(lastName));
            Assert.That(user.Age, Is.EqualTo(age));
        }

        [Test]
        public void User_Collections_ShouldBeInitialized()
        {
            var user = new User();

            Assert.That(user.Reservations, Is.Not.Null);
            Assert.That(user.Reviews, Is.Not.Null);
        }

        [Test]
        public void User_FirstNameExceedsMaxLength_ShouldFailValidation()
        {
            _user.FirstName = new string('A', 51);

            var validationContext = new ValidationContext(_user);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(_user, validationContext, validationResults, true);

            Assert.That(isValid, Is.False);
            Assert.That(validationResults, Is.Not.Empty);
        }

        [Test]
        public void User_LastNameExceedsMaxLength_ShouldFailValidation()
        {
            _user.LastName = new string('B', 51);

            var validationContext = new ValidationContext(_user);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(_user, validationContext, validationResults, true);

            Assert.That(isValid, Is.False);
            Assert.That(validationResults, Is.Not.Empty);
        }
    }
}
