using DDD_Template.Domain.Base.ValueObjects;
using DDD_Template.Domain.Users.Exceptions;

namespace DDD_Template.Domain.Users.ValueObjects
{
    public sealed record FirstName : ValueObject<string>
    {
        public const int MaxLength = 64;

        private FirstName() { }
        private FirstName(string value) : base(value) { }

        public static FirstName Create(string value)
        {
            return new FirstName(value);
        }

        protected override void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new FirstNameIsEmptyException();

            if (value.Length > FirstName.MaxLength)
                throw new FirstNameIsTooLongException();
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}