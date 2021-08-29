using DDD_Template.Application.DomainEvents;
using DDD_Template.Domain.Base.DomainEvents;
using FluentAssertions;
using MediatR;
using System;
using Xunit;

namespace DDD_Template.Application.UnitTests.DomainEventsTests
{
    public class DomainEventNotificationTests
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
        public void Expected_Create_DomainEventNotification()
        {
            // Arrange
            var id = Guid.NewGuid();
            var createdAtUtc = DateTime.UtcNow;
            var domainEvent = new CreatedCustomerDomainEvent(id, createdAtUtc);

            // Act
            var domainEventNotification = new DomainEventNotification<CreatedCustomerDomainEvent>(domainEvent);

            // Assert
            domainEventNotification.Should().BeAssignableTo(typeof(INotification));
            domainEventNotification.DomainEvent.Should().BeOfType(typeof(CreatedCustomerDomainEvent));
            domainEventNotification.DomainEvent.Id.Should().Be(id);
            domainEventNotification.DomainEvent.CreatedAtUtc.Should().Be(createdAtUtc);
        }
    }
}