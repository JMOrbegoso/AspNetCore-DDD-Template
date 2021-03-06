using DDD_Template.Domain.Users.DomainEvents;
using DDD_Template.Domain.Users.Entities;
using DDD_Template.Domain.Users.Exceptions;
using DDD_Template.Domain.Users.ValueObjects;
using FluentAssertions;
using System;
using Xunit;

namespace DDD_Template.UnitTests.UsersTests.EntitiesTests
{
    public class UserTests
    {
        [Fact]
        public void Expected_Create_User()
        {
            // Arrange
            var id = Guid.NewGuid();
            var firstName = FirstName.Create("John");
            var lastName = LastName.Create("Doe");
            var birthDate = BirthDate.Create(2000, 10, 10);

            // Act
            var user = User.Create(id, firstName, lastName, birthDate);

            // Assert
            user.Id.Should().Be(id);
            user.FirstName.Should().Be(firstName);
            user.LastName.Should().Be(lastName);
            user.BirthDate.Should().Be(birthDate);
            user.DomainEvents.Should().ContainItemsAssignableTo<UserCreatedDomainEvent>().And.ContainSingle();
        }

        [Fact]
        public void Expected_Throw_InvalidOperationException_Update_FirstName()
        {
            // Arrange
            var id = Guid.NewGuid();
            var firstName = FirstName.Create("John");
            var lastName = LastName.Create("Doe");
            var birthDate = BirthDate.Create(2000, 10, 10);

            // Act
            var user = User.Create(id, firstName, lastName, birthDate);
            var act = new Action(() => user.UpdateFirstName(firstName));

            // Assert
            act.Should().Throw<UpdateFirstNameException>();
        }

        [Fact]
        public void Expected_Update_FirstName()
        {
            // Arrange
            var id = Guid.NewGuid();
            var originalFirstName = FirstName.Create("John");
            var newFirstName = FirstName.Create("Johny");
            var lastName = LastName.Create("Doe");
            var birthDate = BirthDate.Create(2000, 10, 10);

            // Act
            var user = User.Create(id, originalFirstName, lastName, birthDate);
            user.UpdateFirstName(newFirstName);

            // Assert
            user.Id.Should().Be(id);
            user.FirstName.Should().Be(newFirstName);
            user.LastName.Should().Be(lastName);
            user.BirthDate.Should().Be(birthDate);
        }

        [Fact]
        public void Expected_Throw_InvalidOperationException_Update_LastName()
        {
            // Arrange
            var id = Guid.NewGuid();
            var firstName = FirstName.Create("John");
            var lastName = LastName.Create("Doe");
            var birthDate = BirthDate.Create(2000, 10, 10);

            // Act
            var user = User.Create(id, firstName, lastName, birthDate);
            var act = new Action(() => user.UpdateLastName(lastName));

            // Assert
            act.Should().Throw<UpdateLastNameException>();
        }

        [Fact]
        public void Expected_Update_LastName()
        {
            // Arrange
            var id = Guid.NewGuid();
            var firstName = FirstName.Create("John");
            var originalLastName = LastName.Create("Doe");
            var newLastName = LastName.Create("Doeh");
            var birthDate = BirthDate.Create(2000, 10, 10);

            // Act
            var user = User.Create(id, firstName, originalLastName, birthDate);
            user.UpdateLastName(newLastName);

            // Assert
            user.Id.Should().Be(id);
            user.FirstName.Should().Be(firstName);
            user.LastName.Should().Be(newLastName);
            user.BirthDate.Should().Be(birthDate);
        }

        [Fact]
        public void Expected_Throw_InvalidOperationException_Update_BirthDate()
        {
            // Arrange
            var id = Guid.NewGuid();
            var firstName = FirstName.Create("John");
            var lastName = LastName.Create("Doe");
            var birthDate = BirthDate.Create(2000, 10, 10);

            // Act
            var user = User.Create(id, firstName, lastName, birthDate);
            var act = new Action(() => user.UpdateBirthDate(birthDate));

            // Assert
            act.Should().Throw<UpdateBirthDateException>();
        }

        [Fact]
        public void Expected_Update_BirthDate()
        {
            // Arrange
            var id = Guid.NewGuid();
            var firstName = FirstName.Create("John");
            var lastName = LastName.Create("Doe");
            var originalBirthDate = BirthDate.Create(2000, 10, 10);
            var newBirthDate = BirthDate.Create(2010, 10, 10);

            // Act
            var user = User.Create(id, firstName, lastName, originalBirthDate);
            user.UpdateBirthDate(newBirthDate);

            // Assert
            user.Id.Should().Be(id);
            user.FirstName.Should().Be(firstName);
            user.LastName.Should().Be(lastName);
            user.BirthDate.Should().Be(newBirthDate);
        }

        [Fact]
        public void Expected_Same_User()
        {
            // Arrange
            var id = Guid.NewGuid();

            var user1FirstName = FirstName.Create("John");
            var user1LastName = LastName.Create("Doe");
            var user1BirthDate = BirthDate.Create(2000, 10, 10);

            var user2FirstName = FirstName.Create("Johny");
            var user2LastName = LastName.Create("Doeh");
            var user2BirthDate = BirthDate.Create(2010, 10, 10);

            // Act
            var user1 = User.Create(id, user1FirstName, user1LastName, user1BirthDate);
            var user2 = User.Create(id, user2FirstName, user2LastName, user2BirthDate);
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
            var user1BirthDate = BirthDate.Create(2000, 10, 10);

            var user2FirstName = FirstName.Create("Johny");
            var user2LastName = LastName.Create("Doeh");
            var user2BirthDate = BirthDate.Create(2010, 10, 10);

            // Act
            var user1 = User.Create(id, user1FirstName, user1LastName, user1BirthDate);
            var user2 = User.Create(id, user2FirstName, user2LastName, user2BirthDate);
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
            var birthDate = BirthDate.Create(2000, 10, 10);

            // Act
            var user1 = User.Create(user1Id, firstName, lastName, birthDate);
            var user2 = User.Create(user2Id, firstName, lastName, birthDate);
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
            var birthDate = BirthDate.Create(2000, 10, 10);

            // Act
            var user1 = User.Create(user1Id, firstName, lastName, birthDate);
            var user2 = User.Create(user2Id, firstName, lastName, birthDate);
            var equality = user1 == user2;

            // Assert
            equality.Should().BeFalse();
        }
    }
}