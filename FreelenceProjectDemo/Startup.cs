using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FreelenceProjectDemo.Startup))]
namespace FreelenceProjectDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
