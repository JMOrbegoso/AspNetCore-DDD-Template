using System;

namespace DDD_Template.Domain.User.Exceptions
{
    public class EmailIsEmptyException : ArgumentNullException
    {
        public EmailIsEmptyException() : base("Email") { }
    }
}