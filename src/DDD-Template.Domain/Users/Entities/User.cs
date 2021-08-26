using DDD_Template.Domain.Base;
using DDD_Template.Domain.Users.DomainEvents;
using DDD_Template.Domain.Users.Exceptions;
using DDD_Template.Domain.Users.ValueObjects;
using System;

namespace DDD_Template.Domain.Users.Entities
{
    public sealed class User : AggregateRoot
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
            var user = new User(id, firstName, lastName, birthDate);

            user.AddDomainEvent(new UserCreatedDomainEvent(user.Id));

            return user;
        }

        public void UpdateFirstName(FirstName firstName)
        {
            if (this.FirstName.Equals(firstName))
                throw new UpdateFirstNameException();

            this.FirstName = firstName;
        }

        public void UpdateLastName(LastName lastName)
        {
            if (this.LastName.Equals(lastName))
                throw new UpdateLastNameException();

            this.LastName = lastName;
        }

        public void UpdateBirthDate(BirthDate birthDate)
        {
            if (this.BirthDate.Equals(birthDate))
                throw new UpdateBirthDateException();

            this.BirthDate = birthDate;
        }
    }
}