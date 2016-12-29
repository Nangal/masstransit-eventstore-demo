using System.Web.Http;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Api.Startup))]

namespace Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            ServiceBusConfig.Configure();
        }
    }
}
