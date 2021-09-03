using DDD_Template.Domain.Base.DomainEvents;
using DDD_Template.Domain.Base.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace DDD_Template.UnitTests.BaseTests.EntitiesTests
{
    public class IAggregateRootTests
    {
        private class DummyAggregateRoot : IAggregateRoot
        {
            public IReadOnlyList<IDomainEvent> DomainEvents { get; }

            public Guid Id { get; }

            public DummyAggregateRoot(Guid id)
            {
                this.Id = id;
            }

            public void AddDomainEvent(IDomainEvent domainEvent)
            {
                throw new NotImplementedException();
            }

            public void ClearDomainEvents()
            {
                throw new NotImplementedException();
            }
        }

        [Fact]
        public void Expected_Create_DummyAggregateRoot()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            var dummyAggregateRoot = new DummyAggregateRoot(id);

            // Assert
            dummyAggregateRoot.Should().BeAssignableTo(typeof(IAggregateRoot));
            dummyAggregateRoot.Should().BeAssignableTo(typeof(IEntity));
            dummyAggregateRoot.Should().BeOfType(typeof(DummyAggregateRoot));
            dummyAggregateRoot.Id.Should().Be(id);
        }
    }
}