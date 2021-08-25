using System;

namespace DDD_Template.Domain.Users.Exceptions
{
    public class LastNameIsEmptyException : ArgumentNullException
    {
        public LastNameIsEmptyException() : base("LastName") { }
    }
}