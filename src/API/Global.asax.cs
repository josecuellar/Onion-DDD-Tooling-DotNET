using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Application.Services.Ads;
using Domain.Core.Model.Ads;
using Cache;
using System.Collections.Generic;
using MediatR;
using Autofac.Features.Variance;
using Domain.Core.Services;
using Domain.Core.Event;
using Infrastructure.Messaging;

namespace API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
         protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // APPLICATION SERVICE
            builder.RegisterType<AdQueryService>().As<IAdQueryService>().InstancePerRequest();
            builder.RegisterType<AdCommandService>().As<IAdCommandService>().InstancePerRequest();

            //* INFRASTRUCTURE
            
            //CacheRepository for Ad
            builder.RegisterType<Cache.HttpRuntimeCache<IEnumerable<Ad>>>().As<ICache<IEnumerable<Ad>>>().InstancePerRequest();
            
            //Sql connection type & connectionString
            builder.RegisterType<Persistence.SQL.SqlConnectionFactory>()
                .As<Persistence.SQL.IConnectionFactory>()
                .WithParameter("connectionString", System.Configuration.ConfigurationManager.ConnectionStrings["LocalSQLServer"].ConnectionString)
                .InstancePerRequest();

            builder.RegisterType<Persistence.SQL.Ads.AdQueryRepository>().As<IAdQueryRepository>().InstancePerRequest();
            builder.RegisterType<Persistence.SQL.Ads.AdCommandRepository>().As<IAdCommandRepository>().InstancePerRequest();
            //*

            //DOMAIN SERVICES - ACL
            
                //ACL for external API façade
                builder.RegisterType<ACL.PostalCodeAdapter>().As<Domain.Core.Services.IPostalCodeAdapter>().InstancePerRequest();
                builder.RegisterType<ACL.PostalCodeTranslator>().As<Domain.Core.Services.IPostalCodeTranslator>().InstancePerRequest();
                //*
            //*

           

            //MEDIATR
                builder.RegisterSource(new ContravariantRegistrationSource());
                builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();

                builder.RegisterAssemblyTypes(typeof(Models.Command.AdCommand).GetTypeInfo().Assembly).AsImplementedInterfaces();
                builder.RegisterAssemblyTypes(typeof(Models.Query.AdQuery).GetTypeInfo().Assembly).AsImplementedInterfaces();

                builder.Register<SingleInstanceFactory>(ctx =>
                {
                    var c = ctx.Resolve<IComponentContext>();
                    return t => c.Resolve(t);
                });
                builder.Register<MultiInstanceFactory>(ctx =>
                {
                    var c = ctx.Resolve<IComponentContext>();
                    return t => (IEnumerable<object>)c.Resolve(typeof(IEnumerable<>).MakeGenericType(t));
                });
            //**


            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            DomainEvents.Dispatcher = new Infrastructure.Messaging.MassTransitEngine.Middleware();

            Infrastructure.Messaging.MassTransitEngine.Consumer.AdPriceChanged.Listen();
            Infrastructure.Messaging.MassTransitEngine.Consumer.AdCreated.Listen();
            Infrastructure.Messaging.MassTransitEngine.Consumer.AdDiscountApplied.Listen();

        }

    }
}
  