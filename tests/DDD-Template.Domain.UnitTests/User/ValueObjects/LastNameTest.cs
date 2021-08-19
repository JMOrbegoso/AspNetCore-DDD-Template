using DDD_Template.Domain.User.Exceptions;
using DDD_Template.Domain.User.ValueObjects;
using FluentAssertions;
using System;
using System.Linq;
using Xunit;

namespace DDD_Template.Domain.UnitTests.User.ValueObjects
{
    public class LastNameTest
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Expected_throw_LastNameIsEmptyException(string lastNameString)
        {
            // Arrange

            // Act
            var act = new Action(() => LastName.Create(lastNameString));

            // Assert
            act.Should().Throw<LastNameIsEmptyException>();
        }

        [Fact]
        public void Expected_throw_LastNameIsEmptyException_Due_Empty_String()
        {
            // Arrange
            var lastNameString = string.Empty;

            // Act
            var act = new Action(() => LastName.Create(lastNameString));

            // Assert
            act.Should().Throw<LastNameIsEmptyException>();
        }

        [Fact]
        public void Expected_throw_LastNameIsTooLongException()
        {
            // Arrange
            var lastNameString = String.Concat(Enumerable.Repeat("Doe", 86));

            // Act
            var act = new Action(() => LastName.Create(lastNameString));

            // Assert
            act.Should().Throw<LastNameIsTooLongException>();
        }

        [Fact]
        public void Expected_Create_Valid_LastName()
        {
            // Arrange
            var lastNameString = "Doe";

            // Act
            var lastName = LastName.Create(lastNameString);

            // Assert
            lastName.Value.Should().Be(lastNameString);
        }

        [Fact]
        public void Expected_Equal_LastName()
        {
            // Arrange
            var originalLastNameString = "Doe";
            var otherLastNameString = "Doe";

            // Act
            var originalLastName = LastName.Create(originalLastNameString);
            var otherLastName = LastName.Create(otherLastNameString);

            // Assert
            originalLastName.Equals(otherLastName).Should().BeTrue();
        }

        [Fact]
        public void Expected_Equal_LastName_With_Operator()
        {
            // Arrange
            var originalLastNameString = "Doe";
            var otherLastNameString = "Doe";

            // Act
            var originalLastName = LastName.Create(originalLastNameString);
            var otherLastName = LastName.Create(otherLastNameString);

            // Assert
            (originalLastName == otherLastName).Should().BeTrue();
        }

        [Fact]
        public void Expected_Not_Equal_LastName()
        {
            // Arrange
            var originalLastNameString = "Doe";
            var otherLastNameString = "Doeh";

            // Act
            var originalLastName = LastName.Create(originalLastNameString);
            var otherLastName = LastName.Create(otherLastNameString);

            // Assert
            originalLastName.Equals(otherLastName).Should().BeFalse();
        }

        [Fact]
        public void Expected_Not_Equal_LastName_With_Operator()
        {
            // Arrange
            var originalLastNameString = "Doe";
            var otherLastNameString = "Doeh";

            // Act
            var originalLastName = LastName.Create(originalLastNameString);
            var otherLastName = LastName.Create(otherLastNameString);

            // Assert
            (originalLastName != otherLastName).Should().BeTrue();
        }
    }
}