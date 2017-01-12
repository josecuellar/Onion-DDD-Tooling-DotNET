using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Model.Ads;
using Domain.Core.Event;
using MassTransit;
using MassTransit.BusConfigurators;
using MassTransit.Log4NetIntegration.Logging;


namespace Infrastructure.Messaging.MassTransitEngine
{
    public class Middleware : IDomainEventPublisher
    {
        private static IServiceBus serviceBus = null;
        private static IServiceBus bus
        {
            get
            {
                if (serviceBus==null)
                    serviceBus = BusInitializer.CreateBus("Publisher", x => { });

                return serviceBus;
            }
        }

        public void Publish(IDomainEvent domainEvent)
        {          
            switch(domainEvent.GetType().Name)
            {
                case "AdCreated":
                    bus.Publish<IAdCreated>(domainEvent, x => { x.SetDeliveryMode(MassTransit.DeliveryMode.Persistent); });
                    break;
                case "AdPriceChanged":
                     bus.Publish<IAdPriceChanged>(domainEvent, x => { x.SetDeliveryMode(MassTransit.DeliveryMode.Persistent); });
                    break;
                case "AdDiscountApplied":
                    bus.Publish<IAdDiscountApplied>(domainEvent, x => { x.SetDeliveryMode(MassTransit.DeliveryMode.Persistent); });
                    break;
            }            
        }        
    }

    public class BusInitializer
    {
        public static IServiceBus CreateBus(string queueName, Action<ServiceBusConfigurator> moreInitialization)
        {
            Log4NetLogger.Use();
            var bus = ServiceBusFactory.New(x =>
            {
                x.UseRabbitMq();
                x.ReceiveFrom("rabbitmq://localhost/APITest_" + queueName);
                moreInitialization(x);
            });

            return bus;
        }
    }


}
