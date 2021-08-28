using DDD_Template.Domain.Base.ValueObjects;
using System;

namespace DDD_Template.Domain.Users.ValueObjects
{
    public sealed record BirthDate : ValueObject<DateTime>
    {
        public const string OldestDateString = "1920-01-01";

        private BirthDate(DateTime birthDate) : base(birthDate) { }
        private BirthDate(int year, int month, int day) : base(new DateTime(year, month, day)) { }
        private BirthDate(string birthDateString) : base(DateTime.Parse(birthDateString)) { }

        public static BirthDate Create(DateTime value)
        {
            return new BirthDate(value);
        }
        public static BirthDate Create(int year, int month, int day)
        {
            return new BirthDate(year, month, day);
        }
        public static BirthDate Create(string birthDateString)
        {
            return new BirthDate(birthDateString);
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