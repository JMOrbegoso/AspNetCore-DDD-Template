using DDD_Template.Domain.Base.DomainEvents;
using MediatR;
using System;
using System.Threading.Tasks;

namespace DDD_Template.Application.DomainEvents
{
    public sealed class MediatrDomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IMediator _mediator;

        public MediatrDomainEventDispatcher(IMediator mediator)
        {
            this._mediator = mediator;
        }

        public async Task Dispatch(IDomainEvent domainEvent)
        {
            var domainEventNotification = this.CreateDomainEventNotification(domainEvent);

            await this._mediator.Publish(domainEventNotification);
        }

        public INotification CreateDomainEventNotification(IDomainEvent domainEvent)
        {
            var domainEventType = domainEvent.GetType();
            var genericDispatcherType = typeof(DomainEventNotification<>).MakeGenericType(domainEventType);
            var notification = Activator.CreateInstance(genericDispatcherType, domainEvent);
            return (INotification)notification;
        }
    }
}