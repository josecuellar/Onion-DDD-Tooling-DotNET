using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Application.Services.Ads;
using Domain.Core.Model.Ads;
using Domain.Core.Services.Ads;
using Cache;
using System.Collections.Generic;

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
            builder.RegisterType<AdService>().As<IAdService>().InstancePerRequest();

            //* INFRASTRUCTURE
            
            //CacheRepository for Ad
            builder.RegisterType<Cache.HttpRuntimeCache<IEnumerable<Ad>>>().As<ICache<IEnumerable<Ad>>>().InstancePerRequest();
            
            //Sql connection type & connectionString
            builder.RegisterType<Persistence.SQL.SqlConnectionFactory>()
                .As<Persistence.SQL.IConnectionFactory>()
                .WithParameter("connectionString", System.Configuration.ConfigurationManager.ConnectionStrings["LocalSQLServer"].ConnectionString)
                .InstancePerRequest();

            builder.RegisterType<Persistence.SQL.Ads.AdReadRepository>().As<IAdReadRepository>().InstancePerRequest();
            builder.RegisterType<Persistence.SQL.Ads.AdCommandRepository>().As<IAdCommandRepository>().InstancePerRequest();
            //*

            //DOMAIN SERVICES
            builder.RegisterType<AdDomainService>().As<IAdDomainService>().InstancePerRequest();
            //*

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }
    }
}
