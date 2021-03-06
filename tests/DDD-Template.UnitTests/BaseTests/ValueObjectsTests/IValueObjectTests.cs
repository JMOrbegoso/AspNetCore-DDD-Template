using DDD_Template.Domain.Base.ValueObjects;
using FluentAssertions;
using System;
using Xunit;

namespace DDD_Template.UnitTests.BaseTests.ValueObjectsTests
{
    public class IValueObjectTests
    {
        private record StringValueObject : IValueObject<string>
        {
            public string Value { get; }

            public StringValueObject(string value)
            {
                this.Value = value;
            }

            public bool Equals(string other)
            {
                throw new NotImplementedException();
            }
        }

        [Fact]
        public void Expected_Create_String_ValueObject()
        {
            // Arrange
            var stringValue = "value";

            // Act
            var stringValueObject = new StringValueObject(stringValue);

            // Assert
            stringValueObject.Should().BeAssignableTo(typeof(IValueObject<string>));
            stringValueObject.Should().BeOfType(typeof(StringValueObject));
            stringValueObject.Value.Should().Be(stringValue);
        }

        private record DecimalValueObject : IValueObject<decimal>
        {
            public decimal Value { get; }

            public DecimalValueObject(decimal value)
            {
                this.Value = value;
            }

            public bool Equals(decimal other)
            {
                throw new NotImplementedException();
            }
        }

        [Fact]
        public void Expected_Create_Decimal_ValueObject()
        {
            // Arrange
            var decimalValue = 14m;

            // Act
            var stringValueObject = new DecimalValueObject(decimalValue);

            // Assert
            stringValueObject.Should().BeAssignableTo(typeof(IValueObject<decimal>));
            stringValueObject.Value.Should().Be(decimalValue);
        }

        private struct DateStruct : IEquatable<DateStruct>
        {
            public int Day;
            public int Month;
            public int Year;

            public bool Equals(DateStruct other)
            {
                throw new NotImplementedException();
            }
        }

        private record DateStructValueObject : IValueObject<DateStruct>
        {
            public DateStruct Value { get; }

            public DateStructValueObject(DateStruct value)
            {
                this.Value = value;
            }

            public bool Equals(DateStruct other)
            {
                throw new NotImplementedException();
            }
        }

        [Fact]
        public void Expected_Create_DateStruct_ValueObject()
        {
            // Arrange
            var dateStructValue = new DateStruct()
            {
                Day = 1,
                Month = 1,
                Year = 2000,
            };

            // Act
            var dateStructValueObject = new DateStructValueObject(dateStructValue);

            // Assert
            dateStructValueObject.Should().BeAssignableTo(typeof(IValueObject<DateStruct>));
            dateStructValueObject.Value.Should().Be(dateStructValue);
        }
    }
}