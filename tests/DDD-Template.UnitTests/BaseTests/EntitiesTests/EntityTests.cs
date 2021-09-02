using DDD_Template.Domain.Base.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace DDD_Template.UnitTests.BaseTests.EntitiesTests
{
    public class EntityTests
    {
        private sealed class DummyEntity : Entity
        {
            public DummyEntity(Guid id) : base(id) { }
        }

        [Fact]
        public void Expected_Create_DummyEntity()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            var dummyEntity = new DummyEntity(id);

            // Assert
            dummyEntity.Should().BeAssignableTo(typeof(IEntity));
            dummyEntity.Should().BeOfType(typeof(DummyEntity));
            dummyEntity.Id.Should().Be(id);
        }

        [Fact]
        public void Expected_DummyEntities_be_Equal()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            var dummyEntity1 = new DummyEntity(id);
            var dummyEntity2 = new DummyEntity(id);
            var equality = dummyEntity1.Equals(dummyEntity2);

            // Assert
            equality.Should().BeTrue();
        }

        [Fact]
        public void Expected_DummyEntities_be_Equal_With_Operator()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            var dummyEntity1 = new DummyEntity(id);
            var dummyEntity2 = new DummyEntity(id);
            var equality = dummyEntity1 == dummyEntity2;

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
            var dummyEntity1 = new DummyEntity(id1);
            var dummyEntity2 = new DummyEntity(id2);
            var equality = dummyEntity1.Equals(dummyEntity2);

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
            var dummyEntity1 = new DummyEntity(id1);
            var dummyEntity2 = new DummyEntity(id2);
            var equality = dummyEntity1 != dummyEntity2;

            // Assert
            equality.Should().BeTrue();
        }
    }
}