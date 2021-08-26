using System.Collections.Generic;

namespace DDD_Template.Domain.Base
{
    public interface IAggregateRoot
    {
        IReadOnlyList<IDomainEvent> GetDomainEvents();

        void AddDomainEvent(IDomainEvent domainEvent);

        void ClearDomainEvents();
    }
}