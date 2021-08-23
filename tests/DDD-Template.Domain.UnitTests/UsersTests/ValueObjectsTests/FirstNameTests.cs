using DDD_Template.Domain.Users.Exceptions;
using DDD_Template.Domain.Users.ValueObjects;
using DDD_Template.TestHelpers;
using FluentAssertions;
using System;
using Xunit;

namespace DDD_Template.Domain.UnitTests.UsersTests.ValueObjectsTests
{
    public class FirstNameTests
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Expected_throw_FirstNameIsEmptyException(string firstNameString)
        {
            // Arrange

            // Act
            var act = new Action(() => FirstName.Create(firstNameString));

            // Assert
            act.Should().Throw<FirstNameIsEmptyException>();
        }

        [Fact]
        public void Expected_throw_FirstNameIsEmptyException_Due_Empty_String()
        {
            // Arrange
            var firstNameString = string.Empty;

            // Act
            var act = new Action(() => FirstName.Create(firstNameString));

            // Assert
            act.Should().Throw<FirstNameIsEmptyException>();
        }

        [Theory]
        [InlineData(256)]
        [InlineData(400)]
        [InlineData(1000)]
        [InlineData(10000)]
        public void Expected_throw_FirstNameIsTooLongException(int length)
        {
            // Arrange
            var firstNameString = StringHelpers.RandomStringGenerator(length);

            // Act
            var act = new Action(() => FirstName.Create(firstNameString));

            // Assert
            act.Should().Throw<FirstNameIsTooLongException>();
        }

        [Fact]
        public void Expected_Create_Valid_FirstName()
        {
            // Arrange
            var firstNameString = "John";

            // Act
            var firstName = FirstName.Create(firstNameString);

            // Assert
            firstName.Value.Should().Be(firstNameString);
        }

        [Fact]
        public void Expected_Equal_FirstName()
        {
            // Arrange
            var originalFirstNameString = "John";

            // Act
            var originalFirstName = FirstName.Create(originalFirstNameString);
            var otherFirstName = FirstName.Create(originalFirstNameString);

            // Assert
            originalFirstName.Equals(otherFirstName).Should().BeTrue();
        }

        [Fact]
        public void Expected_Equal_FirstName_With_Operator()
        {
            // Arrange
            var originalFirstNameString = "John";

            // Act
            var originalFirstName = FirstName.Create(originalFirstNameString);
            var otherFirstName = FirstName.Create(originalFirstNameString);

            // Assert
            (originalFirstName == otherFirstName).Should().BeTrue();
        }

        [Fact]
        public void Expected_Not_Equal_FirstName()
        {
            // Arrange
            var originalFirstNameString = "John";
            var otherFirstNameString = "Johny";

            // Act
            var originalFirstName = FirstName.Create(originalFirstNameString);
            var otherFirstName = FirstName.Create(otherFirstNameString);

            // Assert
            originalFirstName.Equals(otherFirstName).Should().BeFalse();
        }

        [Fact]
        public void Expected_Not_Equal_FirstName_With_Operator()
        {
            // Arrange
            var originalFirstNameString = "John";
            var otherFirstNameString = "Johny";

            // Act
            var originalFirstName = FirstName.Create(originalFirstNameString);
            var otherFirstName = FirstName.Create(otherFirstNameString);

            // Assert
            (originalFirstName != otherFirstName).Should().BeTrue();
        }
    }
}