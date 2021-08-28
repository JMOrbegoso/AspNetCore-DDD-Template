using System;

namespace DDD_Template.Domain.Base.Entities
{
    public abstract class Entity : IEntity
    {
        public Guid Id { get; }

        protected Entity() { }
        protected Entity(Guid id)
        {
            this.Id = id;
        }

        public bool Equals(Entity other)
        {
            if (other is null) return false;

            if (this.GetType() != other.GetType()) return false;

            if (ReferenceEquals(this, other)) return true;

            return this.Id.Equals(other.Id);
        }

        public override bool Equals(object obj) => this.Equals(obj as Entity);

        public static bool operator ==(Entity a, Entity b) => a.Equals(b);

        public static bool operator !=(Entity a, Entity b) => !a.Equals(b);

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}