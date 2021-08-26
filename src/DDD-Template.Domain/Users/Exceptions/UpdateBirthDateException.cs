using System;

namespace DDD_Template.Domain.Users.Exceptions
{
    public class UpdateBirthDateException : InvalidOperationException
    {
        public UpdateBirthDateException() : base("Exception on BirthDate update.") { }
    }
}