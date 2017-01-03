using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Services;
using Domain.Core.Model.Ads;
using Domain.Core.Event;
using MassTransit;

namespace Infrastructure.Messaging
{
    public class IAdCreatedConsumer : Consumes<IAdCreated>.Context
    {
        public static void Listen()
        {
            var bus = BusInitializer.CreateBus("Subscriber", x =>
            {
                x.Subscribe(subs =>
                {
                    subs.Consumer<IAdCreatedConsumer>().Permanent();
                });
            });
        }

        public void Consume(IConsumeContext<IAdCreated> message)
        {
            //throw new NotImplementedException();
        }
    }
}
