using DDD_Template.Domain.User.Exceptions;
using FluentAssertions;
using System;
using Xunit;

namespace DDD_Template.Domain.UnitTests.User.ExceptionsTests
{
    public class EmailIsEmptyExceptionTests
    {
        [Fact]
        public void Expected_throw_exception_with_message()
        {
            // Arrange

            // Act
            var act = new Action(() => throw new EmailIsEmptyException());

            // Assert
            act.Should().Throw<EmailIsEmptyException>().WithMessage("*Email*");
        }
    }
}