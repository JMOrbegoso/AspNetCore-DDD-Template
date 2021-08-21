using System;

namespace DDD_Template.Domain.User.Exceptions
{
    public class EmailIsTooLongException : Exception
    {
        public EmailIsTooLongException() : base("Email is too long.") { }
    }
}