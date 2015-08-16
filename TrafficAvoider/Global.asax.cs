using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace TrafficAvoider
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            var thisAssembly = Assembly.GetExecutingAssembly();
            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register Web API controllers.
            builder.RegisterApiControllers(thisAssembly);

            // Register MVC controllers.
            builder.RegisterControllers(typeof(WebApiApplication).Assembly);

            // Register Providers
            builder.RegisterAssemblyTypes(thisAssembly).Where(t => t.Name.EndsWith("Provider")).AsImplementedInterfaces().InstancePerRequest();

            //builder.RegisterAssemblyTypes(thisAssembly).Where(t => t.Name.EndsWith("Service") && !t.Name.ContainsAny("Logging", "JsonSerializer")).AsImplementedInterfaces().InstancePerRequest();
            

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);


            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
