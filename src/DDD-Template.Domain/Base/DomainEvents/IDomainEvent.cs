using System;

namespace DDD_Template.Domain.Base.DomainEvents
{
    public interface IDomainEvent
    {
        Guid Id { get; }

        DateTime CreatedAtUtc { get; }
    }
}