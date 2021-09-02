using DDD_Template.Application.DomainEvents;
using DDD_Template.Domain.Base.DomainEvents;
using FluentAssertions;
using MediatR;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DDD_Template.UnitTests.DomainEventsTests
{
    public class MediatrDomainEventDispatcherTests
    {
        private record CreatedCustomerDomainEvent : IDomainEvent
        {
            public Guid Id { get; }

            public DateTime CreatedAtUtc { get; }

            public CreatedCustomerDomainEvent(Guid id, DateTime createdAtUtc)
            {
                this.Id = id;
                this.CreatedAtUtc = createdAtUtc;
            }
        }

        [Fact]
        public void Expected_CreateDomainEventNotification()
        {
            // Arrange
            var id = Guid.NewGuid();
            var createdAtUtc = DateTime.UtcNow;
            var createdCustomerDomainEvent = new CreatedCustomerDomainEvent(id, createdAtUtc);

            var mediator = new Mock<IMediator>();
            var mediatrDomainEventDispatcher = new MediatrDomainEventDispatcher(mediator.Object);

            // Act
            var notification = mediatrDomainEventDispatcher.CreateDomainEventNotification(createdCustomerDomainEvent);

            // Assert
            notification.Should().BeAssignableTo(typeof(INotification));
            notification.Should().BeOfType(typeof(DomainEventNotification<CreatedCustomerDomainEvent>));
        }

        [Fact]
        public async Task Expected_Dispatch_DomainEvent()
        {
            // Arrange
            var id = Guid.NewGuid();
            var createdAtUtc = DateTime.UtcNow;
            var createdCustomerDomainEvent = new CreatedCustomerDomainEvent(id, createdAtUtc);

            var mediator = new Mock<IMediator>();
            var mediatrDomainEventDispatcher = new MediatrDomainEventDispatcher(mediator.Object);
            var domainEventNotification = mediatrDomainEventDispatcher.CreateDomainEventNotification(createdCustomerDomainEvent);

            mediator.Setup(x => x.Publish(It.IsAny<INotification>(), default));

            // Act
            Func<Task> func = async () => await mediatrDomainEventDispatcher.Dispatch(createdCustomerDomainEvent);

            // Assert
            await func.Should().NotThrowAsync();
        }
    }
}