using System;

namespace DDD_Template.Domain.User.Exceptions
{
    public class FirstNameIsTooLongException : Exception
    {
        public FirstNameIsTooLongException() : base("FirstName is too long.") { }
    }
}