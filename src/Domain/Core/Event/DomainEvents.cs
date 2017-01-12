
namespace Domain.Core.Event
{
  
    public class DomainEvents
    {
        public static IDomainEventPublisher    Dispatcher { get; set; }

        public static void Publish(IDomainEvent @event)
        {
            Dispatcher.Publish(@event);
        }
        
    }

  

}
