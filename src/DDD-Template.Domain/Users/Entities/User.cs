using DDD_Template.Domain.Base;
using DDD_Template.Domain.Users.ValueObjects;
using System;

namespace DDD_Template.Domain.Users.Entities
{
    public sealed class User : Entity
    {
        private FirstName _firstName { get; set; }
        public string GetFirstName() => this._firstName.Value;

        private LastName _lastName { get; set; }
        public string GetLastName() => this._lastName.Value;

        private BirthDate _birthDate { get; set; }
        public DateTime GetBirthDate() => this._birthDate.Value;

        private User(Guid id, FirstName firstName, LastName lastName, BirthDate birthDate) : base(id)
        {
            this._firstName = firstName;
            this._lastName = lastName;
            this._birthDate = birthDate;
        }

        public static User Create(FirstName firstName, LastName lastName, BirthDate birthDate)
        {
            return User.Create(Guid.NewGuid(), firstName, lastName, birthDate);
        }
        public static User Create(Guid id, FirstName firstName, LastName lastName, BirthDate birthDate)
        {
            return new User(id, firstName, lastName, birthDate);
        }

        public void UpdateFirstName(FirstName firstName)
        {
            this._firstName = firstName;
        }

        public void UpdateLastName(LastName lastName)
        {
            this._lastName = lastName;
        }

        public void UpdateBirthDate(BirthDate birthDate)
        {
            this._birthDate = birthDate;
        }
    }
}