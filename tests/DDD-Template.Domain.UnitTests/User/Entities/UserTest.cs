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
    }
}