using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MediNote.Startup))]
namespace MediNote
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
