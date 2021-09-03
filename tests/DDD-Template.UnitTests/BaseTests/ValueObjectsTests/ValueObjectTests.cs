using DDD_Template.Domain.Base.ValueObjects;
using FluentAssertions;
using System;
using Xunit;

namespace DDD_Template.UnitTests.BaseTests.ValueObjectsTests
{
    public class ValueObjectTests
    {
        public record NameValueObject : ValueObject<string>
        {
            public NameValueObject(string name) : base(name) { }

            protected override void Validate(string value)
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Name");
            }
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Expected_throw_Validation_Error_On_NameValueObject_Creation(string nameString)
        {
            // Arrange

            // Act
            var act = new Action(() => new NameValueObject(nameString));

            // Assert
            act.Should().Throw<ArgumentNullException>().WithMessage("*Name*");
        }

        [Fact]
        public void Expected_Create_NameValueObject()
        {
            // Arrange
            var name = "John";

            // Act
            var nameValueObject = new NameValueObject(name);

            // Assert
            nameValueObject.Value.Should().Be(name);
        }

        [Fact]
        public void Expected_NameValueObjects_be_Equal()
        {
            // Arrange
            var name = "John";

            // Act
            var nameValueObject1 = new NameValueObject(name);
            var nameValueObject2 = new NameValueObject(name);
            var result = nameValueObject1.Equals(nameValueObject2);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Expected_NameValueObjects_be_Equal_with_Operator()
        {
            // Arrange
            var name = "John";

            // Act
            var nameValueObject1 = new NameValueObject(name);
            var nameValueObject2 = new NameValueObject(name);
            var result = nameValueObject1 == nameValueObject2;

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Expected_NameValueObject_be_Equal_by_Value()
        {
            // Arrange
            var name = "John";

            // Act
            var nameValueObject = new NameValueObject(name);
            var result = nameValueObject.Equals(name);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Expected_NameValueObject_be_Equal_by_Value_with_Operator()
        {
            // Arrange
            var name = "John";

            // Act
            var nameValueObject = new NameValueObject(name);
            var result = nameValueObject == name;

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Expected_NameValueObjects_be_Different()
        {
            // Arrange
            var name1 = "John";
            var name2 = "Johny";

            // Act
            var nameValueObject1 = new NameValueObject(name1);
            var nameValueObject2 = new NameValueObject(name2);
            var result = nameValueObject1.Equals(nameValueObject2);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Expected_NameValueObjects_be_Different_with_Operator()
        {
            // Arrange
            var name1 = "John";
            var name2 = "Johny";

            // Act
            var nameValueObject1 = new NameValueObject(name1);
            var nameValueObject2 = new NameValueObject(name2);
            var result = nameValueObject1 != nameValueObject2;

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Expected_NameValueObject_be_Different_by_Value()
        {
            // Arrange
            var name1 = "John";
            var name2 = "Johny";

            // Act
            var nameValueObject = new NameValueObject(name1);
            var result = nameValueObject.Equals(name2);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Expected_NameValueObject_be_Different_by_Value_with_Operator()
        {
            // Arrange
            var name1 = "John";
            var name2 = "Johny";

            // Act
            var nameValueObject = new NameValueObject(name1);
            var result = nameValueObject != name2;

            // Assert
            result.Should().BeTrue();
        }
    }
}