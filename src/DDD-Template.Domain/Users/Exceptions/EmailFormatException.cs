using System;

namespace DDD_Template.Domain.Users.Exceptions
{
    public class EmailFormatException : FormatException
    {
        public EmailFormatException() : base("Email have invalid format.") { }
    }
}