using System;

namespace DDD_Template.Domain.User.Exceptions
{
    public class EmailFormatException : FormatException
    {
        public EmailFormatException() : base("Email have invalid format.")
        {

        }
    }
}