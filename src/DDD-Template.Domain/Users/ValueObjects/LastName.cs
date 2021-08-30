using DDD_Template.Domain.Base.ValueObjects;
using DDD_Template.Domain.Users.Exceptions;

namespace DDD_Template.Domain.Users.ValueObjects
{
    public sealed record LastName : ValueObject<string>
    {
        public const int MaxLength = 64;

        private LastName() { }
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

        public bool Contains(string value)
        {
            return this.Value.Contains(value);
        }
    }
}