using DDD_Template.Domain.Users.Exceptions;
using DDD_Template.Domain.Users.ValueObjects;
using DDD_Template.TestHelpers;
using FluentAssertions;
using System;
using Xunit;

namespace DDD_Template.Domain.UnitTests.UsersTests.ValueObjectsTests
{
    public class LastNameTests
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

        [Theory]
        [InlineData(65)]
        [InlineData(70)]
        [InlineData(100)]
        [InlineData(1000)]
        public void Expected_throw_LastNameIsTooLongException(int length)
        {
            // Arrange
            var lastNameString = StringHelpers.RandomStringGenerator(length);

            // Act
            var act = new Action(() => LastName.Create(lastNameString));

            // Assert
            act.Should().Throw<LastNameIsTooLongException>();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(30)]
        [InlineData(64)]
        public void Expected_Create_Valid_LastName(int length)
        {
            // Arrange
            var lastNameString = StringHelpers.RandomStringGenerator(length);

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

            // Act
            var originalLastName = LastName.Create(originalLastNameString);
            var otherLastName = LastName.Create(originalLastNameString);

            // Assert
            originalLastName.Equals(otherLastName).Should().BeTrue();
        }

        [Fact]
        public void Expected_Equal_LastName_With_Operator()
        {
            // Arrange
            var originalLastNameString = "Doe";

            // Act
            var originalLastName = LastName.Create(originalLastNameString);
            var otherLastName = LastName.Create(originalLastNameString);

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

        [Theory]
        [InlineData("Doe", "D", true)]
        [InlineData("Doe", "Do", true)]
        [InlineData("Doe", "Doe", true)]
        [InlineData("Doe", " ", false)]
        [InlineData("Doe", "DD", false)]
        [InlineData("Doe", "Doeh", false)]
        public void Expected_LastName_Contains(string lastNameString, string valueToFind, bool expected)
        {
            // Arrange

            // Act
            var lastName = LastName.Create(lastNameString);
            var contains = lastName.Contains(valueToFind);

            // Assert
            contains.Should().Be(expected);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(30)]
        [InlineData(64)]
        public void Expected_LastName_ToString(int length)
        {
            // Arrange
            var lastNameString = StringHelpers.RandomStringGenerator(length);

            // Act
            var lastName = LastName.Create(lastNameString);

            // Assert
            lastName.ToString().Should().Be(lastNameString);
        }
    }
}