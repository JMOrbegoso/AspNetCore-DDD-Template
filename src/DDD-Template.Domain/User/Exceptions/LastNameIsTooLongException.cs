using System;

namespace DDD_Template.Domain.User.Exceptions
{
    public class LastNameIsTooLongException : Exception
    {
        public LastNameIsTooLongException() : base("LastName is too long.") { }
    }
}