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

        private User(Guid id, string firstName, string lastName, string email) : base(id)
        {
            this._firstName = FirstName.Create(firstName);
            this._lastName = LastName.Create(lastName);
            this._email = Email.Create(email);
        }

        public static User Create(string firstName, string lastName, string email)
        {
            return new User(Guid.NewGuid(), firstName, lastName, email);
        }
        public static User Create(Guid id, string firstName, string lastName, string email)
        {
            return new User(id, firstName, lastName, email);
        }

        public void UpdateFirstName(string firstName)
        {
            this._firstName = FirstName.Create(firstName);
        }
        public void UpdateFirstName(FirstName firstName)
        {
            this._firstName = firstName;
        }

        public void UpdateLastName(string lastName)
        {
            this._lastName = LastName.Create(lastName);
        }
        public void UpdateLastName(LastName lastName)
        {
            this._lastName = lastName;
        }

        public void UpdateEmail(string email)
        {
            this._email = Email.Create(email);
        }
        public void UpdateEmail(Email email)
        {
            this._email = email;
        }
    }
}