using System;

namespace DDD_Template.Domain.Base.ValueObjects
{
    public abstract record ValueObject<T> : IValueObject<T> where T : IEquatable<T>
    {
        public T Value { get; }

        protected ValueObject(T value)
        {
            this.Validate(value);

            this.Value = value;
        }

        protected abstract void Validate(T value);
    }
}