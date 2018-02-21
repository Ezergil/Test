using System.Web.Http;
using TestProject.WebFramework.DI;

namespace TestProject.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            WebCapsule.Initialize(config);

            config.Routes.MapHttpRoute(
                name: "DefaultApi2",
                routeTemplate: "api/{controller}/{id}/details",
                defaults: new { action = "details" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}"
            );
        }
    }
}
