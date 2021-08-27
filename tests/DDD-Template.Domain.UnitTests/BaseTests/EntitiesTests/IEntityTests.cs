using DDD_Template.Domain.Base.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace DDD_Template.Domain.UnitTests.BaseTests.EntitiesTests
{
    public class IEntityTests
    {
        private class DummyEntity : IEntity
        {
            public Guid Id { get; }

            public DummyEntity(Guid id)
            {
                this.Id = id;
            }
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
    }
}