using System;

namespace DDD_Template.Domain.Users.Exceptions
{
    public class UpdateFirstNameException : InvalidOperationException
    {
        public UpdateFirstNameException() : base("Exception on FirstName update.") { }
    }
}