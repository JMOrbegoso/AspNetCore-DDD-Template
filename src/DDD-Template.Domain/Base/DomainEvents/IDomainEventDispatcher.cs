using System.Threading.Tasks;

namespace DDD_Template.Domain.Base.DomainEvents
{
    public interface IDomainEventDispatcher
    {
        Task Dispatch(IDomainEvent domainEvent);
    }
}