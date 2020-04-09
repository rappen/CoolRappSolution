using Jonas;
using Microsoft.Xrm.Sdk.Query;

namespace CoolRappPlugin
{
    public class RocketPlugin : JonasPluginBase
    {
        public override void Execute(JonasPluginBag bag)
        {
            var user = bag.Service.Retrieve("systemuser", bag.PluginContext.InitiatingUserId, new ColumnSet("fullname"));
            bag.Trace($"Hello {user["fullname"]}!");
        }
    }
}
