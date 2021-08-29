using DDD_Template.Domain.Base.ValueObjects;
using System;

namespace DDD_Template.Domain.Users.ValueObjects
{
    public sealed record BirthDate : ValueObject<DateTime>
    {
        private BirthDate() { }
        private BirthDate(DateTime birthDate) : base(birthDate) { }

        public static BirthDate Create(DateTime value)
        {
            return new BirthDate(value);
        }
        public static BirthDate Create(int year, int month, int day)
        {
            var value = new DateTime(year, month, day);
            return new BirthDate(value);
        }
        public static BirthDate Create(string birthDateString)
        {
            var value = DateTime.Parse(birthDateString);
            return new BirthDate(value);
        }

        protected override void Validate(DateTime value) { }

        public override string ToString()
        {
            return this.Value.ToString("yyyy-mm-dd");
        }

        public bool IsOver18YearsOld()
        {
            var currentAge = DateTime.Today.Year - this.Value.Year;

            if (this.Value > DateTime.Today.AddYears(-currentAge))
                currentAge--;

            return currentAge >= 18;
        }
    }
}