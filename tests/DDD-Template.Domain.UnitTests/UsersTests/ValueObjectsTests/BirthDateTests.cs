using DDD_Template.Domain.Users.ValueObjects;
using FluentAssertions;
using System;
using Xunit;

namespace DDD_Template.Domain.UnitTests.UsersTests.ValueObjectsTests
{
    public class BirthDateTests
    {
        [Fact]
        public void Expected_Create_Valid_BirthDate_From_DateTime()
        {
            // Arrange

            // Act
            var dateTime = DateTime.Today.AddYears(-18);
            var birthDate = BirthDate.Create(dateTime);

            // Assert
            birthDate.Value.Should().Be(dateTime);
        }

        [Theory]
        [InlineData(-1, 0, 0)]
        [InlineData(0, -1, 0)]
        [InlineData(0, 0, -1)]
        [InlineData(-1, -1, -1)]
        [InlineData(0, 0, 0)]
        [InlineData(2000, 13, 1)]
        [InlineData(2000, 12, 32)]
        [InlineData(2000, 13, 32)]
        public void Expected_throw_ArgumentOutOfRangeException(int year, int month, int day)
        {
            // Arrange

            // Act
            var act = new Action(() => BirthDate.Create(year, month, day));

            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(1921, 01, 02)]
        [InlineData(1950, 12, 11)]
        [InlineData(2000, 08, 16)]
        [InlineData(2020, 09, 15)]
        public void Expected_Create_Valid_BirthDate_From_Ints(int year, int month, int day)
        {
            // Arrange

            // Act
            var birthDate = BirthDate.Create(year, month, day);
            var originalBirthDate = new DateTime(year, month, day);

            // Assert
            birthDate.Value.Should().Be(originalBirthDate);
        }

        [Theory]
        [InlineData("xxxx-xx-xx")]
        [InlineData("0000-00-00")]
        [InlineData("0000-01-01")]
        [InlineData("abcd-01-01")]
        public void Expected_throw_FormatException(string badFormatDate)
        {
            // Arrange

            // Act
            var act = new Action(() => BirthDate.Create(badFormatDate));

            // Assert
            act.Should().Throw<FormatException>();
        }

        [Theory]
        [InlineData("1921-01-02")]
        [InlineData("1950-12-11")]
        [InlineData("2000-08-16")]
        [InlineData("2020-09-15")]
        public void Expected_Create_Valid_BirthDate_From_String(string birthDateString)
        {
            // Arrange

            // Act
            var birthDate = BirthDate.Create(birthDateString);
            var originalBirthDate = DateTime.Parse(birthDateString);

            // Assert
            birthDate.Value.Should().Be(originalBirthDate);
        }

        [Fact]
        public void Expected_Equal_BirthDate()
        {
            // Arrange
            var originalBirthDateString = "2020-01-01";

            // Act
            var originalBirthDate = BirthDate.Create(originalBirthDateString);
            var otherBirthDate = BirthDate.Create(originalBirthDateString);

            // Assert
            originalBirthDate.Equals(otherBirthDate).Should().BeTrue();
        }

        [Fact]
        public void Expected_Equal_BirthDate_With_Operator()
        {
            // Arrange
            var originalBirthDateString = "2020-01-01";

            // Act
            var originalBirthDate = BirthDate.Create(originalBirthDateString);
            var otherBirthDate = BirthDate.Create(originalBirthDateString);

            // Assert
            (originalBirthDate == otherBirthDate).Should().BeTrue();
        }

        [Fact]
        public void Expected_Not_Equal_BirthDate()
        {
            // Arrange
            var originalBirthDateString = "2020-01-01";
            var otherBirthDateString = "2000-01-01";

            // Act
            var originalBirthDate = BirthDate.Create(originalBirthDateString);
            var otherBirthDate = BirthDate.Create(otherBirthDateString);

            // Assert
            originalBirthDate.Equals(otherBirthDate).Should().BeFalse();
        }

        [Fact]
        public void Expected_Not_Equal_BirthDate_With_Operator()
        {
            // Arrange
            var originalBirthDateString = "2020-01-01";
            var otherBirthDateString = "2000-01-01";

            // Act
            var originalBirthDate = BirthDate.Create(originalBirthDateString);
            var otherBirthDate = BirthDate.Create(otherBirthDateString);

            // Assert
            (originalBirthDate != otherBirthDate).Should().BeTrue();
        }

        [Theory]
        [InlineData("1921-01-02")]
        [InlineData("1950-12-11")]
        [InlineData("2000-08-16")]
        public void Expected_Is_Over_18_Years_Old(string birthDateString)
        {
            // Arrange

            // Act
            var birthDate = BirthDate.Create(birthDateString);

            // Assert
            birthDate.IsOver18YearsOld().Should().BeTrue();
        }

        [Fact]
        public void Expected_Is_Over_18_Years_Old_with_Tricky_BirthDate()
        {
            // Arrange

            // Act
            var trickyBirthDate = DateTime.Today.AddYears(-18);
            var birthDate = BirthDate.Create(trickyBirthDate);

            // Assert
            birthDate.IsOver18YearsOld().Should().BeTrue();
        }

        [Theory]
        [InlineData("2005-01-01")]
        [InlineData("2010-01-01")]
        [InlineData("2020-01-01")]
        public void Expected_Is_Not_Over_18_Years_Old(string birthDateString)
        {
            // Arrange

            // Act
            var birthDate = BirthDate.Create(birthDateString);

            // Assert
            birthDate.IsOver18YearsOld().Should().BeFalse();
        }

        [Fact]
        public void Expected_Is_Not_Over_18_Years_Old_with_Tricky_BirthDate()
        {
            // Arrange

            // Act
            var trickyBirthDate = DateTime.Today.AddYears(-18).AddDays(+1);
            var birthDate = BirthDate.Create(trickyBirthDate);

            // Assert
            birthDate.IsOver18YearsOld().Should().BeFalse();
        }

        [Theory]
        [InlineData("1975-01-01")]
        [InlineData("2000-01-01")]
        [InlineData("2005-01-01")]
        [InlineData("2011-01-01")]
        [InlineData("2020-01-01")]
        [InlineData("2025-01-01")]
        [InlineData("2036-01-01")]
        public void Expected_BirthDate_To_String(string birthDateString)
        {
            // Arrange

            // Act
            var birthDate = BirthDate.Create(birthDateString);

            // Assert
            birthDate.ToString().Should().Be(birthDateString);
        }
    }
}