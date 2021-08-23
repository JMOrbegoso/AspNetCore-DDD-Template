using System;

namespace DDD_Template.Domain.Users.Exceptions
{
    public class LastNameIsTooLongException : Exception
    {
        public LastNameIsTooLongException() : base("LastName is too long.") { }
    }
}