using System;

namespace DDD_Template.Domain.Base
{
    public interface IDomainEvent
    {
        Guid Id { get; }

        DateTime CreatedAtUtc { get; }
    }
}