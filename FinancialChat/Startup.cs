using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FinancialChat.Startup))]
namespace FinancialChat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
