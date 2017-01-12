using Domain.Core.Model.Ads;

namespace Domain.Core.Event
{
    
    public interface IDomainEventPublisher
    {
        void Publish(IDomainEvent @event);
    }

}
