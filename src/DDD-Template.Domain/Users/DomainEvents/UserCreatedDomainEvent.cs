using DDD_Template.Domain.Base.DomainEvents;
using System;

namespace DDD_Template.Domain.Users.DomainEvents
{
    public sealed record UserCreatedDomainEvent : DomainEvent
    {
        public Guid UserId { get; }

        public UserCreatedDomainEvent(Guid userId)
        {
            this.UserId = userId;
        }
    }
}