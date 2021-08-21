using FluentAssertions;
using System;
using Xunit;

namespace DDD_Template.Domain.UnitTests.User.Entities
{
    public class UserTest
    {
        [Fact]
        public void Expected_Create_User_with_Id()
        {
            // Arrange
            var id = Guid.NewGuid();
            var firstName = "John";
            var lastName = "Doe";
            var email = "john@doe.com";

            // Act
            var user = Domain.User.Entities.User.Create(id, firstName, lastName, email);

            // Assert
            user.Id.Should().Be(id);
            user.GetFirstName().Should().Be(firstName);
            user.GetLastName().Should().Be(lastName);
        }

        [Fact]
        public void Expected_Create_User_without_Id()
        {
            // Arrange
            var firstName = "John";
            var lastName = "Doe";
            var email = "john@doe.com";

            // Act
            var user = Domain.User.Entities.User.Create(firstName, lastName, email);

            // Assert
            user.Id.Should().NotBeEmpty();
            user.GetFirstName().Should().Be(firstName);
            user.GetLastName().Should().Be(lastName);
        }

        [Fact]
        public void Expected_Update_FirstName()
        {
            // Arrange
            var id = Guid.NewGuid();
            var originalFirstName = "John";
            var newFirstName = "Johny";
            var lastName = "Doe";
            var email = "john@doe.com";

            // Act
            var user = Domain.User.Entities.User.Create(id, originalFirstName, lastName, email);
            user.UpdateFirstName(newFirstName);

            // Assert
            user.Id.Should().Be(id);
            user.GetFirstName().Should().Be(newFirstName);
            user.GetLastName().Should().Be(lastName);
        }

        [Fact]
        public void Expected_Update_LastName()
        {
            // Arrange
            var id = Guid.NewGuid();
            var firstName = "John";
            var originalLastName = "Doe";
            var newLastName = "Doeh";
            var email = "john@doe.com";

            // Act
            var user = Domain.User.Entities.User.Create(id, firstName, originalLastName, email);
            user.UpdateLastName(newLastName);

            // Assert
            user.Id.Should().Be(id);
            user.GetFirstName().Should().Be(firstName);
            user.GetLastName().Should().Be(newLastName);
        }

        [Fact]
        public void Expected_Update_Email()
        {
            // Arrange
            var id = Guid.NewGuid();
            var firstName = "John";
            var lastName = "Doe";
            var originalEmail = "john@doe.com";
            var newEmail = "johny@doeh.com";

            // Act
            var user = Domain.User.Entities.User.Create(id, firstName, lastName, originalEmail);
            user.UpdateEmail(newEmail);

            // Assert
            user.Id.Should().Be(id);
            user.GetFirstName().Should().Be(firstName);
            user.GetLastName().Should().Be(lastName);
            user.GetEmail().Should().Be(newEmail);
        }

        [Fact]
        public void Expected_Same_User()
        {
            // Arrange
            var id = Guid.NewGuid();
            var user1FirstName = "John";
            var user2FirstName = "Johny";
            var user1LastName = "Doe";
            var user2LastName = "Doeh";
            var user1Email = "john@doe.com";
            var user2Email = "johny@doeh.com";

            // Act
            var user1 = Domain.User.Entities.User.Create(id, user1FirstName, user1LastName, user1Email);
            var user2 = Domain.User.Entities.User.Create(id, user2FirstName, user2LastName, user2Email);
            var equality = user1.Equals(user2);

            // Assert
            equality.Should().BeTrue();
        }

        [Fact]
        public void Expected_Same_User_using_Operator()
        {
            // Arrange
            var id = Guid.NewGuid();
            var user1FirstName = "John";
            var user2FirstName = "Johny";
            var user1LastName = "Doe";
            var user2LastName = "Doeh";
            var user1Email = "john@doe.com";
            var user2Email = "johny@doeh.com";

            // Act
            var user1 = Domain.User.Entities.User.Create(id, user1FirstName, user1LastName, user1Email);
            var user2 = Domain.User.Entities.User.Create(id, user2FirstName, user2LastName, user2Email);
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
            var firstName = "John";
            var lastName = "Doe";
            var email = "john@doe.com";

            // Act
            var user1 = Domain.User.Entities.User.Create(user1Id, firstName, lastName, email);
            var user2 = Domain.User.Entities.User.Create(user2Id, firstName, lastName, email);
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
            var firstName = "John";
            var lastName = "Doe";
            var email = "john@doe.com";

            // Act
            var user1 = Domain.User.Entities.User.Create(user1Id, firstName, lastName, email);
            var user2 = Domain.User.Entities.User.Create(user2Id, firstName, lastName, email);
            var equality = user1 == user2;

            // Assert
            equality.Should().BeFalse();
        }
    }
}