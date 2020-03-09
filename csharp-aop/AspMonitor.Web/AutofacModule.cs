using AspMonitor.Web.Interceptors;
using AspMonitor.Web.Services;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspMonitor.Web
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            // Typed registration
            builder.Register(c => new CallLogger())
           .Named<IInterceptor>("log-calls");

            // The generic ILogger<TCategoryName> service was added to the ServiceCollection by ASP.NET Core.
            // It was then registered with Autofac using the Populate method. All of this starts
            // with the services.AddAutofac() that happens in Program and registers Autofac
            // as the service provider.
            builder.Register(c => new ValuesService(c.Resolve<ILogger<ValuesService>>()))
                .As<IValuesService>()
                .InstancePerLifetimeScope()                
                .EnableInterfaceInterceptors();
        }
    }
}
