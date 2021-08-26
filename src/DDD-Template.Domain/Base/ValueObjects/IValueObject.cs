using System;

namespace DDD_Template.Domain.Base.ValueObjects
{
    public interface IValueObject<T> where T : IEquatable<T>
    {
        T Value { get; }
    }
}