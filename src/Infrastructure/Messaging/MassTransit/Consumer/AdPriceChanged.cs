using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Services;
using Domain.Core.Model.Ads;
using Domain.Core.Event;
using MassTransit;

namespace Infrastructure.Messaging.MassTransitEngine.Consumer
{
    public class AdPriceChanged : Consumes<IAdPriceChanged>.Context
    {
        public static void Listen()
        {
            var bus = BusInitializer.CreateBus("Subscriber", x =>
            {
                x.Subscribe(subs =>
                {
                    subs.Consumer<AdPriceChanged>().Permanent();
                });
            });
        }

        public void Consume(IConsumeContext<IAdPriceChanged> message)
        {
            //throw new NotImplementedException();
        }
    }
}
