using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AWA_Quiz.Startup))]
namespace AWA_Quiz
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
