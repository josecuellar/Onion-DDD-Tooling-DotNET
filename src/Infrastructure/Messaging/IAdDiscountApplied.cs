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
    public class IAdDiscountAppliedConsumer : Consumes<IAdDiscountApplied>.Context
    {
        public static void Listen()
        {
            var bus = BusInitializer.CreateBus("Subscriber", x =>
            {
                x.Subscribe(subs =>
                {
                    subs.Consumer<IAdDiscountAppliedConsumer>().Permanent();
                });
            });
        }

        public void Consume(IConsumeContext<IAdDiscountApplied> message)
        {
            //throw new NotImplementedException();
        }
    }
}
