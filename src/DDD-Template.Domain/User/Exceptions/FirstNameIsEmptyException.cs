using System;

namespace DDD_Template.Domain.User.Exceptions
{
    public class FirstNameIsEmptyException : ArgumentNullException
    {
        public FirstNameIsEmptyException() : base("FirstName") { }
    }
}