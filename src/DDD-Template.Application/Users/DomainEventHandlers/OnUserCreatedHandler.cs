using DDD_Template.Application.DomainEvents;
using DDD_Template.Domain.Users.DomainEvents;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DDD_Template.Application.Users.DomainEventHandlers
{
    public class OnUserCreatedHandler : INotificationHandler<DomainEventNotification<UserCreatedDomainEvent>>
    {
        public OnUserCreatedHandler()
        {

        }

        public Task Handle(DomainEventNotification<UserCreatedDomainEvent> notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}