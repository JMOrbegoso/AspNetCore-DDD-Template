using DDD_Template.Domain.Base.DomainEvents;
using FluentAssertions;
using System;
using Xunit;

namespace DDD_Template.Domain.UnitTests.BaseTests.DomainEventsTests
{
    public class DomainEventTests
    {
        private record CreatedCustomerDomainEvent : DomainEvent
        {

        }

        [Fact]
        public void Expected_Create_CreatedCustomerDomainEvent()
        {
            // Arrange

            // Act
            var domainEvent = new CreatedCustomerDomainEvent();

            // Assert
            domainEvent.Should().BeAssignableTo(typeof(IDomainEvent));
            domainEvent.Should().BeOfType(typeof(CreatedCustomerDomainEvent));

            domainEvent.Id.Should().NotBeEmpty();
            domainEvent.CreatedAtUtc.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(10));
        }
    }
}