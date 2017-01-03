using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Model.Ads;

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
