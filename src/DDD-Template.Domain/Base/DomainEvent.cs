using System;

namespace DDD_Template.Domain.Base
{
    public abstract record DomainEvent : IDomainEvent
    {
        public Guid Id { get; } = Guid.NewGuid();

        public DateTime CreatedAtUtc { get; } = DateTime.UtcNow;
    }
}