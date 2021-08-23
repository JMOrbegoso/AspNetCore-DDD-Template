using DDD_Template.Domain.Users.Entities;
using DDD_Template.Domain.Users.ValueObjects;
using FluentAssertions;
using System;
using Xunit;

namespace DDD_Template.Domain.UnitTests.UsersTests.EntitiesTests
{
    public class UserTests
    {
        [Fact]
        public void Expected_Create_User_with_Id()
        {
            // Arrange
            var id = Guid.NewGuid();
            var firstName = FirstName.Create("John");
            var lastName = LastName.Create("Doe");
            var email = Email.Create("john@doe.com");

            // Act
            var user = User.Create(id, firstName, lastName, email);

            // Assert
            user.Id.Should().Be(id);
            user.GetFirstName().Should().Be(firstName.Value);
            user.GetLastName().Should().Be(lastName.Value);
            user.GetEmail().Should().Be(email.Value);
        }

        [Fact]
        public void Expected_Create_User_without_Id()
        {
            // Arrange
            var firstName = FirstName.Create("John");
            var lastName = LastName.Create("Doe");
            var email = Email.Create("john@doe.com");

            // Act
            var user = User.Create(firstName, lastName, email);

            // Assert
            user.Id.Should().NotBeEmpty();
            user.GetFirstName().Should().Be(firstName.Value);
            user.GetLastName().Should().Be(lastName.Value);
            user.GetEmail().Should().Be(email.Value);
        }

        [Fact]
        public void Expected_Update_FirstName()
        {
            // Arrange
            var id = Guid.NewGuid();
            var originalFirstName = FirstName.Create("John");
            var newFirstName = FirstName.Create("Johny");
            var lastName = LastName.Create("Doe");
            var email = Email.Create("john@doe.com");

            // Act
            var user = User.Create(id, originalFirstName, lastName, email);
            user.UpdateFirstName(newFirstName);

            // Assert
            user.Id.Should().Be(id);
            user.GetFirstName().Should().Be(newFirstName.Value);
            user.GetLastName().Should().Be(lastName.Value);
            user.GetEmail().Should().Be(email.Value);
        }

        [Fact]
        public void Expected_Update_LastName()
        {
            // Arrange
            var id = Guid.NewGuid();
            var firstName = FirstName.Create("John");
            var originalLastName = LastName.Create("Doe");
            var newLastName = LastName.Create("Doeh");
            var email = Email.Create("john@doe.com");

            // Act
            var user = User.Create(id, firstName, originalLastName, email);
            user.UpdateLastName(newLastName);

            // Assert
            user.Id.Should().Be(id);
            user.GetFirstName().Should().Be(firstName.Value);
            user.GetLastName().Should().Be(newLastName.Value);
            user.GetEmail().Should().Be(email.Value);
        }

        [Fact]
        public void Expected_Update_Email()
        {
            // Arrange
            var id = Guid.NewGuid();
            var firstName = FirstName.Create("John");
            var lastName = LastName.Create("Doe");
            var originalEmail = Email.Create("john@doe.com");
            var newEmail = Email.Create("johny@doeh.com");

            // Act
            var user = User.Create(id, firstName, lastName, originalEmail);
            user.UpdateEmail(newEmail);

            // Assert
            user.Id.Should().Be(id);
            user.GetFirstName().Should().Be(firstName.Value);
            user.GetLastName().Should().Be(lastName.Value);
            user.GetEmail().Should().Be(newEmail.Value);
        }

        [Fact]
        public void Expected_Same_User()
        {
            // Arrange
            var id = Guid.NewGuid();
            var user1FirstName = FirstName.Create("John");
            var user2FirstName = FirstName.Create("Johny");
            var user1LastName = LastName.Create("Doe");
            var user2LastName = LastName.Create("Doeh");
            var user1Email = Email.Create("john@doe.com");
            var user2Email = Email.Create("johny@doeh.com");

            // Act
            var user1 = User.Create(id, user1FirstName, user1LastName, user1Email);
            var user2 = User.Create(id, user2FirstName, user2LastName, user2Email);
            var equality = user1.Equals(user2);

            // Assert
            equality.Should().BeTrue();
        }

        [Fact]
        public void Expected_Same_User_using_Operator()
        {
            // Arrange
            var id = Guid.NewGuid();
            var user1FirstName = FirstName.Create("John");
            var user2FirstName = FirstName.Create("Johny");
            var user1LastName = LastName.Create("Doe");
            var user2LastName = LastName.Create("Doeh");
            var user1Email = Email.Create("john@doe.com");
            var user2Email = Email.Create("johny@doeh.com");

            // Act
            var user1 = User.Create(id, user1FirstName, user1LastName, user1Email);
            var user2 = User.Create(id, user2FirstName, user2LastName, user2Email);
            var equality = user1 == user2;

            // Assert
            equality.Should().BeTrue();
        }

        [Fact]
        public void Expected_Different_User()
        {
            // Arrange
            var user1Id = Guid.NewGuid();
            var user2Id = Guid.NewGuid();
            var firstName = FirstName.Create("John");
            var lastName = LastName.Create("Doe");
            var email = Email.Create("john@doe.com");

            // Act
            var user1 = User.Create(user1Id, firstName, lastName, email);
            var user2 = User.Create(user2Id, firstName, lastName, email);
            var equality = user1.Equals(user2);

            // Assert
            equality.Should().BeFalse();
        }

        [Fact]
        public void Expected_Different_User_using_Operator()
        {
            // Arrange
            var user1Id = Guid.NewGuid();
            var user2Id = Guid.NewGuid();
            var firstName = FirstName.Create("John");
            var lastName = LastName.Create("Doe");
            var email = Email.Create("john@doe.com");

            // Act
            var user1 = User.Create(user1Id, firstName, lastName, email);
            var user2 = User.Create(user2Id, firstName, lastName, email);
            var equality = user1 == user2;

            // Assert
            equality.Should().BeFalse();
        }
    }
}