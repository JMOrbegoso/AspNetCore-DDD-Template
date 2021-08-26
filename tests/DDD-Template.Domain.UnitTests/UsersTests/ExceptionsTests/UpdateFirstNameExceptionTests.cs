using DDD_Template.Domain.Users.Exceptions;
using FluentAssertions;
using System;
using Xunit;

namespace DDD_Template.Domain.UnitTests.UsersTests.ExceptionsTests
{
    public class UpdateFirstNameExceptionTests
    {
        [Fact]
        public void Expected_throw_exception_with_message()
        {
            // Arrange

            // Act
            var act = new Action(() => throw new UpdateFirstNameException());

            // Assert
            act.Should().Throw<UpdateFirstNameException>().WithMessage("*FirstName*");
        }
    }
}