using DDD_Template.Domain.Base.DomainEvents;
using FluentAssertions;
using System;
using Xunit;

namespace DDD_Template.Domain.UnitTests.BaseTests.DomainEventsTests
{
    public class IDomainEventTests
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
        public void Expected_Create_CreatedCustomerDomainEvent()
        {
            // Arrange
            var id = Guid.NewGuid();
            var createdAtUtc = DateTime.UtcNow;

            // Act
            var domainEvent = new CreatedCustomerDomainEvent(id, createdAtUtc);

            // Assert
            domainEvent.Should().BeAssignableTo(typeof(IDomainEvent));
            domainEvent.Should().BeOfType(typeof(CreatedCustomerDomainEvent));
            domainEvent.Id.Should().Be(id);
            domainEvent.CreatedAtUtc.Should().Be(createdAtUtc);
        }
    }
}