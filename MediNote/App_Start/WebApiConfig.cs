using MediNote.Filters;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MediNote.App_Start
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            configuration.MapHttpAttributeRoutes();
        }
    }
}