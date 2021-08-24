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
            var birthDate = BirthDate.Create(2000, 10, 10);

            // Act
            var user = User.Create(id, firstName, lastName, email, birthDate);

            // Assert
            user.Id.Should().Be(id);
            user.GetFirstName().Should().Be(firstName.Value);
            user.GetLastName().Should().Be(lastName.Value);
            user.GetEmail().Should().Be(email.Value);
            user.GetBirthDate().Should().Be(birthDate.Value);
        }

        [Fact]
        public void Expected_Create_User_without_Id()
        {
            // Arrange
            var firstName = FirstName.Create("John");
            var lastName = LastName.Create("Doe");
            var email = Email.Create("john@doe.com");
            var birthDate = BirthDate.Create(2000, 10, 10);

            // Act
            var user = User.Create(firstName, lastName, email, birthDate);

            // Assert
            user.Id.Should().NotBeEmpty();
            user.GetFirstName().Should().Be(firstName.Value);
            user.GetLastName().Should().Be(lastName.Value);
            user.GetEmail().Should().Be(email.Value);
            user.GetBirthDate().Should().Be(birthDate.Value);
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
            var birthDate = BirthDate.Create(2000, 10, 10);

            // Act
            var user = User.Create(id, originalFirstName, lastName, email, birthDate);
            user.UpdateFirstName(newFirstName);

            // Assert
            user.Id.Should().Be(id);
            user.GetFirstName().Should().Be(newFirstName.Value);
            user.GetLastName().Should().Be(lastName.Value);
            user.GetEmail().Should().Be(email.Value);
            user.GetBirthDate().Should().Be(birthDate.Value);
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
            var birthDate = BirthDate.Create(2000, 10, 10);

            // Act
            var user = User.Create(id, firstName, originalLastName, email, birthDate);
            user.UpdateLastName(newLastName);

            // Assert
            user.Id.Should().Be(id);
            user.GetFirstName().Should().Be(firstName.Value);
            user.GetLastName().Should().Be(newLastName.Value);
            user.GetEmail().Should().Be(email.Value);
            user.GetBirthDate().Should().Be(birthDate.Value);
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
            var birthDate = BirthDate.Create(2000, 10, 10);

            // Act
            var user = User.Create(id, firstName, lastName, originalEmail, birthDate);
            user.UpdateEmail(newEmail);

            // Assert
            user.Id.Should().Be(id);
            user.GetFirstName().Should().Be(firstName.Value);
            user.GetLastName().Should().Be(lastName.Value);
            user.GetEmail().Should().Be(newEmail.Value);
            user.GetBirthDate().Should().Be(birthDate.Value);
        }

        [Fact]
        public void Expected_Update_BirthDate()
        {
            // Arrange
            var id = Guid.NewGuid();
            var firstName = FirstName.Create("John");
            var lastName = LastName.Create("Doe");
            var email = Email.Create("john@doe.com");
            var originalBirthDate = BirthDate.Create(2000, 10, 10);
            var newBirthDate = BirthDate.Create(2010, 10, 10);

            // Act
            var user = User.Create(id, firstName, lastName, email, originalBirthDate);
            user.UpdateBirthDate(newBirthDate);

            // Assert
            user.Id.Should().Be(id);
            user.GetFirstName().Should().Be(firstName.Value);
            user.GetLastName().Should().Be(lastName.Value);
            user.GetEmail().Should().Be(email.Value);
            user.GetBirthDate().Should().Be(newBirthDate.Value);
        }

        [Fact]
        public void Expected_Same_User()
        {
            // Arrange
            var id = Guid.NewGuid();

            var user1FirstName = FirstName.Create("John");
            var user1LastName = LastName.Create("Doe");
            var user1Email = Email.Create("john@doe.com");
            var user1BirthDate = BirthDate.Create(2000, 10, 10);

            var user2FirstName = FirstName.Create("Johny");
            var user2LastName = LastName.Create("Doeh");
            var user2Email = Email.Create("johny@doeh.com");
            var user2BirthDate = BirthDate.Create(2010, 10, 10);

            // Act
            var user1 = User.Create(id, user1FirstName, user1LastName, user1Email, user1BirthDate);
            var user2 = User.Create(id, user2FirstName, user2LastName, user2Email, user2BirthDate);
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
            var user1LastName = LastName.Create("Doe");
            var user1Email = Email.Create("john@doe.com");
            var user1BirthDate = BirthDate.Create(2000, 10, 10);

            var user2FirstName = FirstName.Create("Johny");
            var user2LastName = LastName.Create("Doeh");
            var user2Email = Email.Create("johny@doeh.com");
            var user2BirthDate = BirthDate.Create(2010, 10, 10);

            // Act
            var user1 = User.Create(id, user1FirstName, user1LastName, user1Email, user1BirthDate);
            var user2 = User.Create(id, user2FirstName, user2LastName, user2Email, user2BirthDate);
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
            var birthDate = BirthDate.Create(2000, 10, 10);

            // Act
            var user1 = User.Create(user1Id, firstName, lastName, email, birthDate);
            var user2 = User.Create(user2Id, firstName, lastName, email, birthDate);
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
            var birthDate = BirthDate.Create(2000, 10, 10);

            // Act
            var user1 = User.Create(user1Id, firstName, lastName, email, birthDate);
            var user2 = User.Create(user2Id, firstName, lastName, email, birthDate);
            var equality = user1 == user2;

            // Assert
            equality.Should().BeFalse();
        }
    }
}