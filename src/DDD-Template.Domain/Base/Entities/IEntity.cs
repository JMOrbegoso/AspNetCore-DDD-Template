using System;

namespace DDD_Template.Domain.Base.Entities
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}