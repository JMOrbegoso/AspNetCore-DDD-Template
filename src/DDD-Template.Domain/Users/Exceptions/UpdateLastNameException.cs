using System;

namespace DDD_Template.Domain.Users.Exceptions
{
    public class UpdateLastNameException : InvalidOperationException
    {
        public UpdateLastNameException() : base("Exception on LastName update.") { }
    }
}