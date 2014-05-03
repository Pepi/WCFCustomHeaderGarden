using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HelloWorldClient.Startup))]
namespace HelloWorldClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            
        }
    }
}
