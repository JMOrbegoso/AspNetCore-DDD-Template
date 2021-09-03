using DDD_Template.Domain.Users.Exceptions;
using FluentAssertions;
using System;
using Xunit;

namespace DDD_Template.UnitTests.UsersTests.ExceptionsTests
{
    public class UpdateBirthDateExceptionTests
    {
        [Fact]
        public void Expected_throw_exception_with_message()
        {
            // Arrange

            // Act
            var act = new Action(() => throw new UpdateBirthDateException());

            // Assert
            act.Should().Throw<UpdateBirthDateException>().WithMessage("*BirthDate*");
        }
    }
}