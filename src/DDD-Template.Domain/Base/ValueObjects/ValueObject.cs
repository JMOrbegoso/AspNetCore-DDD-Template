using System;

namespace DDD_Template.Domain.Base.ValueObjects
{
    public abstract record ValueObject<T> : IValueObject<T>, IEquatable<T> where T : IEquatable<T>
    {
        public T Value { get; }

        protected ValueObject() { }
        protected ValueObject(T value)
        {
            this.Validate(value);

            this.Value = value;
        }

        protected abstract void Validate(T value);

        public bool Equals(T? other)
        {
            return this.Value.Equals(other);
        }
    }
}