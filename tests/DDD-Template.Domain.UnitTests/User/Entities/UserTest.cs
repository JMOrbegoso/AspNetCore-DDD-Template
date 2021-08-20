using FluentAssertions;
using System;
using Xunit;

namespace DDD_Template.Domain.UnitTests.User.Entities
{
    public class UserTest
    {
        [Fact]
        public void Expected_the_same_Id_FirstName_LastName()
        {
            // Arrange
            var id = Guid.NewGuid();
            var firstName = "John";
            var lastName = "Doe";

            // Act
            var user = Domain.User.Entities.User.Create(id, firstName, lastName);

            // Assert
            user.Id.Should().Be(id);
            user.FirstName.Value.Should().Be(firstName);
            user.LastName.Value.Should().Be(lastName);
        }

        [Fact]
        public void Expected_the_same_FirstName_LastName()
        {
            // Arrange
            var firstName = "John";
            var lastName = "Doe";

            // Act
            var user = Domain.User.Entities.User.Create(firstName, lastName);

            // Assert
            user.Id.Should().NotBeEmpty();
            user.FirstName.Value.Should().Be(firstName);
            user.LastName.Value.Should().Be(lastName);
        }

        [Fact]
        public void Expected_Update_FirstName()
        {
            // Arrange
            var id = Guid.NewGuid();
            var originalFirstName = "John";
            var newFirstName = "Johny";
            var lastName = "Doe";

            // Act
            var user = Domain.User.Entities.User.Create(id, originalFirstName, lastName);
            user.UpdateFirstName(newFirstName);

            // Assert
            user.Id.Should().Be(id);
            user.FirstName.Value.Should().Be(newFirstName);
            user.LastName.Value.Should().Be(lastName);
        }

        [Fact]
        public void Expected_Update_LastName()
        {
            // Arrange
            var id = Guid.NewGuid();
            var firstName = "John";
            var originalLastName = "Doe";
            var newLastName = "Doeh";

            // Act
            var user = Domain.User.Entities.User.Create(id, firstName, originalLastName);
            user.UpdateLastName(newLastName);

            // Assert
            user.Id.Should().Be(id);
            user.FirstName.Value.Should().Be(firstName);
            user.LastName.Value.Should().Be(newLastName);
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

            // Act
            var user1 = Domain.User.Entities.User.Create(id, user1FirstName, user1LastName);
            var user2 = Domain.User.Entities.User.Create(id, user2FirstName, user2LastName);
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

            // Act
            var user1 = Domain.User.Entities.User.Create(id, user1FirstName, user1LastName);
            var user2 = Domain.User.Entities.User.Create(id, user2FirstName, user2LastName);
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

            // Act
            var user1 = Domain.User.Entities.User.Create(user1Id, firstName, lastName);
            var user2 = Domain.User.Entities.User.Create(user2Id, firstName, lastName);
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

            // Act
            var user1 = Domain.User.Entities.User.Create(user1Id, firstName, lastName);
            var user2 = Domain.User.Entities.User.Create(user2Id, firstName, lastName);
            var equality = user1 == user2;

            // Assert
            equality.Should().BeFalse();
        }
    }
}