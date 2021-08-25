using DDD_Template.Domain.Base;
using DDD_Template.Domain.Users.ValueObjects;
using System;

namespace DDD_Template.Domain.Users.Entities
{
    public sealed class User : Entity
    {
        public FirstName FirstName { get; private set; }


        public LastName LastName { get; private set; }


        public BirthDate BirthDate { get; private set; }


        private User(Guid id, FirstName firstName, LastName lastName, BirthDate birthDate) : base(id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = birthDate;
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
            this.FirstName = firstName;
        }

        public void UpdateLastName(LastName lastName)
        {
            this.LastName = lastName;
        }

        public void UpdateBirthDate(BirthDate birthDate)
        {
            this.BirthDate = birthDate;
        }
    }
}