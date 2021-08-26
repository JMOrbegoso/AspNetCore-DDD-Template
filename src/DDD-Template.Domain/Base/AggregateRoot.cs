using DDD_Template.Domain.Base.DomainEvents;
using System;
using System.Collections.Generic;

namespace DDD_Template.Domain.Base
{
    public abstract class AggregateRoot : Entity, IAggregateRoot
    {
        private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();
        public IReadOnlyList<IDomainEvent> DomainEvents { get => this._domainEvents.AsReadOnly(); }

        public AggregateRoot(Guid id) : base(id) { }

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            this._domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            this._domainEvents.Clear();
        }
    }
}