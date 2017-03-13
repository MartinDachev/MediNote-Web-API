using MediNote.Filters;
using System.Web.Http;

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