using DDD_Template.Domain.Base;
using DDD_Template.Domain.User.Exceptions;
using System.Text.RegularExpressions;

namespace DDD_Template.Domain.User.ValueObjects
{
    public sealed record Email : ValueObject<string>
    {
        public const int MaxLength = 128;
        public const string EmailRegex = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

        private Email(string value) : base(value) { }

        public static Email Create(string value)
        {
            return new Email(value);
        }

        protected override void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new EmailIsEmptyException();

            if (value.Length > Email.MaxLength)
                throw new EmailIsTooLongException();

            if (!Regex.IsMatch(value, Email.EmailRegex))
                throw new EmailFormatException();
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}