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

        private User(Guid id, string firstName, string lastName) : base(id)
        {
            this.FirstName = FirstName.Create(firstName);
            this.LastName = LastName.Create(lastName);
        }

        public static User Create(string firstName, string lastName)
        {
            return new User(Guid.NewGuid(), firstName, lastName);
        }
        public static User Create(Guid id, string firstName, string lastName)
        {
            return new User(id, firstName, lastName);
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
    }
}