using DDD_Template.Domain.Base;
using DDD_Template.Domain.User.Exceptions;

namespace DDD_Template.Domain.User.ValueObjects
{
    public sealed record LastName : ValueObject<string>
    {
        public readonly static int MaxLength = 255;

        private LastName(string value) : base(value) { }

        public static LastName Create(string value)
        {
            return new LastName(value);
        }

        protected override void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new LastNameIsEmptyException();

            if (value.Length > LastName.MaxLength)
                throw new LastNameIsTooLongException();
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}