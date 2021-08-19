using System;

namespace DDD_Template.Domain.User.Exceptions
{
    public class LastNameIsEmptyException : ArgumentNullException
    {
        public LastNameIsEmptyException() : base("LastName") { }
    }
}