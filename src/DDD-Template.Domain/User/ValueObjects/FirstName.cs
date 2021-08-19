using DDD_Template.Domain.Base;
using DDD_Template.Domain.User.Exceptions;

namespace DDD_Template.Domain.User.ValueObjects
{
    public sealed record FirstName : ValueObject<string>
    {
        public readonly static int MaxLength = 255;

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