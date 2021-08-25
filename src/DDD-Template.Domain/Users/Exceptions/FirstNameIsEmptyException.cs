using System;

namespace DDD_Template.Domain.Users.Exceptions
{
    public class FirstNameIsEmptyException : ArgumentNullException
    {
        public FirstNameIsEmptyException() : base("FirstName") { }
    }
}