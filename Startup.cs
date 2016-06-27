using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AnimeMVCExam.Startup))]
namespace AnimeMVCExam
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
