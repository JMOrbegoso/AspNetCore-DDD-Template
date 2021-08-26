using System;

namespace DDD_Template.Domain.Base
{
    public interface IValueObject<T> where T : IEquatable<T>
    {
        T Value { get; }
    }
}