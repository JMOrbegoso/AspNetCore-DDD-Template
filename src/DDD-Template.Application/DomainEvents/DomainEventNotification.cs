using MediatR;

namespace DDD_Template.Application.DomainEvents
{
    public sealed record DomainEventNotification<IDomainEvent> : INotification
    {
        public IDomainEvent DomainEvent { get; }

        public DomainEventNotification(IDomainEvent domainEvent)
        {
            this.DomainEvent = domainEvent;
        }
    }
}