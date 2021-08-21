using DDD_Template.Domain.Base;
using DDD_Template.Domain.User.ValueObjects;
using System;

namespace DDD_Template.Domain.User.Entities
{
    public sealed class User : Entity
    {
        private FirstName FirstName { get; set; }
        public string GetFirstName() => this.FirstName.Value;

        private LastName LastName { get; set; }
        public string GetLastName() => this.LastName.Value;

        private Email Email { get; set; }
        public string GetEmail() => this.Email.Value;

        private User(Guid id, string firstName, string lastName, string email) : base(id)
        {
            this.FirstName = FirstName.Create(firstName);
            this.LastName = LastName.Create(lastName);
            this.Email = Email.Create(email);
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
            this.FirstName = FirstName.Create(firstName);
        }
        public void UpdateFirstName(FirstName firstName)
        {
            this.FirstName = firstName;
        }

        public void UpdateLastName(string lastName)
        {
            this.LastName = LastName.Create(lastName);
        }
        public void UpdateLastName(LastName lastName)
        {
            this.LastName = lastName;
        }

        public void UpdateEmail(string email)
        {
            this.Email = Email.Create(email);
        }
        public void UpdateEmail(Email email)
        {
            this.Email = email;
        }
    }
}