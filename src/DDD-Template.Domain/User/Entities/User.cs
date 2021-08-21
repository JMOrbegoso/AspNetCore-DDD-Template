using DDD_Template.Domain.Base;
using DDD_Template.Domain.User.ValueObjects;
using System;

namespace DDD_Template.Domain.User.Entities
{
    public sealed class User : Entity
    {
        private FirstName _firstName { get; set; }
        public string GetFirstName() => this._firstName.Value;

        private LastName _lastName { get; set; }
        public string GetLastName() => this._lastName.Value;

        private Email _email { get; set; }
        public string GetEmail() => this._email.Value;

        private User(Guid id, FirstName firstName, LastName lastName, Email email) : base(id)
        {
            this._firstName = firstName;
            this._lastName = lastName;
            this._email = email;
        }

        public static User Create(FirstName firstName, LastName lastName, Email email)
        {
            return new User(Guid.NewGuid(), firstName, lastName, email);
        }
        public static User Create(Guid id, FirstName firstName, LastName lastName, Email email)
        {
            return new User(id, firstName, lastName, email);
        }

        public void UpdateFirstName(FirstName firstName)
        {
            this._firstName = firstName;
        }

        public void UpdateLastName(LastName lastName)
        {
            this._lastName = lastName;
        }

        public void UpdateEmail(Email email)
        {
            this._email = email;
        }
    }
}