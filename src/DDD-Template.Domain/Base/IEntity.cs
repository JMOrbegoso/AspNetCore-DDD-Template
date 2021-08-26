using System;

namespace DDD_Template.Domain.Base
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}