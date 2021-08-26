using System;
using System.Collections.Generic;

namespace DDD_Template.Domain.Base
{
    public abstract class AggregateRoot : Entity
    {
        private readonly List<DomainEvent> _domainEvents = new List<DomainEvent>();
        public IReadOnlyList<DomainEvent> GetDomainEvents() => this._domainEvents.AsReadOnly();

        public AggregateRoot(Guid id) : base(id) { }

        protected void AddDomainEvent(DomainEvent domainEvent)
        {
            this._domainEvents.Add(domainEvent);
        }

        protected void ClearDomainEvents()
        {
            this._domainEvents.Clear();
        }
    }
}