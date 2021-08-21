using DDD_Template.Domain.User.Exceptions;
using DDD_Template.Domain.User.ValueObjects;
using DDD_Template.TestHelpers;
using FluentAssertions;
using System;
using Xunit;

namespace DDD_Template.Domain.UnitTests.User.ValueObjects
{
    public class EmailTest
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Expected_throw_EmailIsEmptyException(string emailString)
        {
            // Arrange

            // Act
            var act = new Action(() => Email.Create(emailString));

            // Assert
            act.Should().Throw<EmailIsEmptyException>();
        }

        [Fact]
        public void Expected_throw_EmailIsEmptyException_Due_Empty_String()
        {
            // Arrange
            var emailString = string.Empty;

            // Act
            var act = new Action(() => Email.Create(emailString));

            // Assert
            act.Should().Throw<EmailIsEmptyException>();
        }

        [Theory]
        [InlineData(128)]
        [InlineData(150)]
        [InlineData(200)]
        [InlineData(1000)]
        public void Expected_throw_EmailIsTooLongException(int length)
        {
            // Arrange
            var emailString = StringHelpers.RandomStringGenerator(length) + "@domain.com";

            // Act
            var act = new Action(() => Email.Create(emailString));

            // Assert
            act.Should().Throw<EmailIsTooLongException>();
        }

        [Theory]
        [InlineData("@.")]
        [InlineData("@email.com")]
        [InlineData("email@domain")]
        [InlineData("email@domain.")]
        [InlineData("emaildomain.com")]
        [InlineData("email@domaincom")]
        [InlineData("ema%il@domain.com")]
        [InlineData("email@dom%ain.com")]
        [InlineData("ema%il@dom%ain.com")]
        [InlineData("email@domain.co%m")]
        [InlineData("email@@domain.com")]
        [InlineData("email@domain..com")]
        [InlineData("em%ail@doma%in.co%m")]
        public void Expected_throw_EmailIsMalformedException(string invalidEmail)
        {
            // Arrange
            var emailString = invalidEmail;

            // Act
            var act = new Action(() => Email.Create(emailString));

            // Assert
            act.Should().Throw<EmailFormatException>();
        }

        [Theory]
        [InlineData("e@d.c")]
        [InlineData("email@domain.com")]
        public void Expected_Create_Valid_Email(string validEmail)
        {
            // Arrange
            var emailString = validEmail;

            // Act
            var email = Email.Create(emailString);

            // Assert
            email.Value.Should().Be(emailString);
        }

        [Fact]
        public void Expected_Equal_Email()
        {
            // Arrange
            var originalEmailString = "email@domain.com";

            // Act
            var originalEmail = Email.Create(originalEmailString);
            var otherEmail = Email.Create(originalEmailString);

            // Assert
            originalEmail.Equals(otherEmail).Should().BeTrue();
        }

        [Fact]
        public void Expected_Equal_Email_With_Operator()
        {
            // Arrange
            var originalEmailString = "email@domain.com";

            // Act
            var originalEmail = Email.Create(originalEmailString);
            var otherEmail = Email.Create(originalEmailString);

            // Assert
            (originalEmail == otherEmail).Should().BeTrue();
        }

        [Fact]
        public void Expected_Not_Equal_Email()
        {
            // Arrange
            var originalEmailString = "email1@domain.com";
            var otherEmailString = "email2@domain.com";

            // Act
            var originalEmail = Email.Create(originalEmailString);
            var otherEmail = Email.Create(otherEmailString);

            // Assert
            originalEmail.Equals(otherEmail).Should().BeFalse();
        }

        [Fact]
        public void Expected_Not_Equal_Email_With_Operator()
        {
            // Arrange
            var originalEmailString = "email1@domain.com";
            var otherEmailString = "email2@domain.com";

            // Act
            var originalEmail = Email.Create(originalEmailString);
            var otherEmail = Email.Create(otherEmailString);

            // Assert
            (originalEmail != otherEmail).Should().BeTrue();
        }
    }
}