using DDD_Template.Domain.User.Exceptions;
using FluentAssertions;
using System;
using Xunit;

namespace DDD_Template.Domain.UnitTests.User.ExceptionsTests
{
    public class EmailIsTooLongExceptionTests
    {
        [Fact]
        public void Expected_throw_exception_with_message()
        {
            // Arrange

            // Act
            var act = new Action(() => throw new EmailIsTooLongException());

            // Assert
            act.Should().Throw<EmailIsTooLongException>().WithMessage("*Email*");
        }
    }
}