using DDD_Template.Domain.Users.Exceptions;
using FluentAssertions;
using System;
using Xunit;

namespace DDD_Template.UnitTests.UsersTests.ExceptionsTests
{
    public class LastNameIsTooLongExceptionTests
    {
        [Fact]
        public void Expected_throw_exception_with_message()
        {
            // Arrange

            // Act
            var act = new Action(() => throw new LastNameIsTooLongException());

            // Assert
            act.Should().Throw<LastNameIsTooLongException>().WithMessage("*LastName*");
        }
    }
}