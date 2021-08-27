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
        public void Expected_Create_DummyEntity()
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
        public void Expected_Add_DomainEvent_In_DummyEntity()
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
        public void Expected_Clear_DomainEvents_In_DummyEntity()
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
    }
}