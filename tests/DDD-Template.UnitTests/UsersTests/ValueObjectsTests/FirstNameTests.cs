using Bogus.DataSets;
using DDD_Template.Domain.Users.Exceptions;
using DDD_Template.Domain.Users.ValueObjects;
using FluentAssertions;
using System;
using Xunit;

namespace DDD_Template.UnitTests.UsersTests.ValueObjectsTests
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
        [InlineData(65)]
        [InlineData(70)]
        [InlineData(100)]
        [InlineData(1000)]
        public void Expected_throw_FirstNameIsTooLongException(int length)
        {
            // Arrange
            var lorem = new Lorem();
            var firstNameString = lorem.Letter(length);

            // Act
            var act = new Action(() => FirstName.Create(firstNameString));

            // Assert
            act.Should().Throw<FirstNameIsTooLongException>();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(30)]
        [InlineData(64)]
        public void Expected_Create_Valid_FirstName(int length)
        {
            // Arrange
            var lorem = new Lorem();
            var firstNameString = lorem.Letter(length);

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

        [Theory]
        [InlineData("John", "J", true)]
        [InlineData("John", "Jo", true)]
        [InlineData("John", "Joh", true)]
        [InlineData("John", "John", true)]
        [InlineData("John", " ", false)]
        [InlineData("John", "JJ", false)]
        [InlineData("John", "Johny", false)]
        public void Expected_FirstName_Contains(string firstNameString, string valueToFind, bool expected)
        {
            // Arrange

            // Act
            var firstName = FirstName.Create(firstNameString);
            var contains = firstName.Contains(valueToFind);

            // Assert
            contains.Should().Be(expected);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(30)]
        [InlineData(64)]
        public void Expected_FirstName_ToString(int length)
        {
            // Arrange
            var lorem = new Lorem();
            var firstNameString = lorem.Letter(length);

            // Act
            var firstName = FirstName.Create(firstNameString);

            // Assert
            firstName.ToString().Should().Be(firstNameString);
        }
    }
}