using System;

namespace DDD_Template.Domain.Users.Exceptions
{
    public class EmailIsEmptyException : ArgumentNullException
    {
        public EmailIsEmptyException() : base("Email") { }
    }
}