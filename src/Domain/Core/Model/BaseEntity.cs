using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Model.Ads;
using Domain.Core.Event;

namespace Domain.Core.Model
{
    public abstract class BaseEntity
    {
        private readonly ICollection<IDomainEvent> Events = new List<IDomainEvent>();

        protected void AddEvent(IDomainEvent @event)
        {
            this.Events.Add(@event);
        }

        private void ClearEvents()
        {
            this.Events.Clear();
        }

        public void DispatchEvents()
        {

            foreach(IDomainEvent @event in Events)
            {
                DomainEvents.Publish(@event);
            }
            ClearEvents();
        }

    }
}
