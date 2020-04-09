using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;

namespace CoolRappPlugin
{
    public class RocketPlugin : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            var trace = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
            var context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            var serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            var service = serviceFactory.CreateOrganizationService(context.InitiatingUserId);

            var user = service.Retrieve("systemuser", context.InitiatingUserId, new ColumnSet("fullname"));
            trace.Trace($"Hello {user["fullname"]}!");
        }
    }
}
