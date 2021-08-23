using DDD_Template.Domain.Users.Exceptions;
using FluentAssertions;
using System;
using Xunit;

namespace DDD_Template.Domain.UnitTests.UsersTests.ExceptionsTests
{
    public class EmailFormatExceptionTests
    {
        [Fact]
        public void Expected_throw_exception_with_message()
        {
            // Arrange

            // Act
            var act = new Action(() => throw new EmailFormatException());

            // Assert
            act.Should().Throw<EmailFormatException>().WithMessage("*Email*");
        }
    }
}