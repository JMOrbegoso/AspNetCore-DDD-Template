using DDD_Template.Domain.Base.DomainEvents;
using System.Collections.Generic;

namespace DDD_Template.Domain.Base.Entities
{
    public interface IAggregateRoot
    {
        IReadOnlyList<IDomainEvent> DomainEvents { get; }

        void AddDomainEvent(IDomainEvent domainEvent);

        void ClearDomainEvents();
    }
}