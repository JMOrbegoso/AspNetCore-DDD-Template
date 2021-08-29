using DDD_Template.Domain.Base.DomainEvents;
using DDD_Template.Domain.Base.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace DDD_Template.Domain.UnitTests.BaseTests.EntitiesTests
{
    public class AggregateRootTests
    {
        private sealed class DummyAggregateRoot : AggregateRoot
        {
            public DummyAggregateRoot(Guid id) : base(id) { }
        }

        private sealed record CreatedDummyDomainEvent : IDomainEvent
        {
            public Guid Id { get; }

            public DateTime CreatedAtUtc { get; }

            public CreatedDummyDomainEvent(Guid id, DateTime createdAtUtc)
            {
                this.Id = id;
                this.CreatedAtUtc = createdAtUtc;
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
            dummyAggregateRoot.Should().BeAssignableTo(typeof(IEntity));
            dummyAggregateRoot.Should().BeAssignableTo(typeof(IAggregateRoot));
            dummyAggregateRoot.Should().BeOfType(typeof(DummyAggregateRoot));
            dummyAggregateRoot.Id.Should().Be(id);
        }

        [Fact]
        public void Expected_DummyEntities_be_Equal()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            var dummyAggregateRoot1 = new DummyAggregateRoot(id);
            var dummyAggregateRoot2 = new DummyAggregateRoot(id);
            var equality = dummyAggregateRoot1.Equals(dummyAggregateRoot2);

            // Assert
            equality.Should().BeTrue();
        }

        [Fact]
        public void Expected_DummyEntities_be_Equal_With_Operator()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            var dummyAggregateRoot1 = new DummyAggregateRoot(id);
            var dummyAggregateRoot2 = new DummyAggregateRoot(id);
            var equality = dummyAggregateRoot1 == dummyAggregateRoot2;

            // Assert
            equality.Should().BeTrue();
        }

        [Fact]
        public void Expected_DummyEntities_be_Different()
        {
            // Arrange
            var id1 = Guid.NewGuid();
            var id2 = Guid.NewGuid();

            // Act
            var dummyAggregateRoot1 = new DummyAggregateRoot(id1);
            var dummyAggregateRoot2 = new DummyAggregateRoot(id2);
            var equality = dummyAggregateRoot1.Equals(dummyAggregateRoot2);

            // Assert
            equality.Should().BeFalse();
        }

        [Fact]
        public void Expected_DummyEntities_be_Different_With_Operator()
        {
            // Arrange
            var id1 = Guid.NewGuid();
            var id2 = Guid.NewGuid();

            // Act
            var dummyAggregateRoot1 = new DummyAggregateRoot(id1);
            var dummyAggregateRoot2 = new DummyAggregateRoot(id2);
            var equality = dummyAggregateRoot1 != dummyAggregateRoot2;

            // Assert
            equality.Should().BeTrue();
        }

        [Fact]
        public void Expected_Add_DomainEvent_In_DummyAggregateRoot()
        {
            // Arrange
            var id = Guid.NewGuid();
            var domainEventId = Guid.NewGuid();
            var createdAtUtc = DateTime.UtcNow;

            // Act
            var dummyAggregateRoot = new DummyAggregateRoot(id);
            dummyAggregateRoot.AddDomainEvent(new CreatedDummyDomainEvent(domainEventId, createdAtUtc));

            // Assert
            dummyAggregateRoot.Should().BeAssignableTo(typeof(IEntity));
            dummyAggregateRoot.Should().BeAssignableTo(typeof(IAggregateRoot));
            dummyAggregateRoot.Should().BeOfType(typeof(DummyAggregateRoot));
            dummyAggregateRoot.Id.Should().Be(id);
            dummyAggregateRoot.DomainEvents.Should().ContainItemsAssignableTo<CreatedDummyDomainEvent>().And.ContainSingle();
        }

        [Fact]
        public void Expected_Clear_DomainEvents_In_DummyAggregateRoot()
        {
            // Arrange
            var id = Guid.NewGuid();
            var domainEventId = Guid.NewGuid();
            var createdAtUtc = DateTime.UtcNow;

            // Act
            var dummyAggregateRoot = new DummyAggregateRoot(id);
            dummyAggregateRoot.AddDomainEvent(new CreatedDummyDomainEvent(domainEventId, createdAtUtc));
            dummyAggregateRoot.ClearDomainEvents();

            // Assert
            dummyAggregateRoot.Should().BeAssignableTo(typeof(IEntity));
            dummyAggregateRoot.Should().BeAssignableTo(typeof(IAggregateRoot));
            dummyAggregateRoot.Should().BeOfType(typeof(DummyAggregateRoot));
            dummyAggregateRoot.Id.Should().Be(id);
            dummyAggregateRoot.DomainEvents.Should().BeEmpty();
        }

        [Fact]
        public void Expected_DummyAggregateRoot_DomainEvents_reflects_changes_in_private_DomainEvents_list()
        {
            // Arrange
            var id = Guid.NewGuid();

            var domainEventId1 = Guid.NewGuid();
            var createdAtUtc1 = DateTime.UtcNow;

            var domainEventId2 = Guid.NewGuid();
            var createdAtUtc2 = DateTime.UtcNow;

            // Act
            var domainEvent1 = new CreatedDummyDomainEvent(domainEventId1, createdAtUtc1);
            var domainEvent2 = new CreatedDummyDomainEvent(domainEventId2, createdAtUtc2);

            var dummyAggregateRoot = new DummyAggregateRoot(id);

            // Assert
            dummyAggregateRoot.AddDomainEvent(domainEvent1);
            dummyAggregateRoot.DomainEvents.Count.Should().Be(1);

            dummyAggregateRoot.AddDomainEvent(domainEvent2);
            dummyAggregateRoot.DomainEvents.Count.Should().Be(2);

            dummyAggregateRoot.ClearDomainEvents();
            dummyAggregateRoot.DomainEvents.Count.Should().Be(0);
        }
    }
}