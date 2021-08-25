using System;

namespace DDD_Template.Domain.Users.Exceptions
{
    public class FirstNameIsTooLongException : Exception
    {
        public FirstNameIsTooLongException() : base("FirstName is too long.") { }
    }
}