using System;

namespace DDD_Template.Domain.Users.Exceptions
{
    public class EmailIsTooLongException : Exception
    {
        public EmailIsTooLongException() : base("Email is too long.") { }
    }
}