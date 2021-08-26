using System;
using System.Collections.Generic;

namespace DDD_Template.Domain.Base
{
    public abstract class AggregateRoot : Entity
    {
        private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();
        public IReadOnlyList<IDomainEvent> GetDomainEvents() => this._domainEvents.AsReadOnly();

        public AggregateRoot(Guid id) : base(id) { }

        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            this._domainEvents.Add(domainEvent);
        }

        protected void ClearDomainEvents()
        {
            this._domainEvents.Clear();
        }
    }
}