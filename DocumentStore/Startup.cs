
// Add the following usings:
using Microsoft.Owin;
using Microsoft.Owin.Extensions;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;
using System.Web.Http;

namespace MinimalOwinWebApiSelfHost
{
    public class Startup
    {
        // This method is required by Katana:
        public void Configuration(IAppBuilder app)
        {
            var webApiConfiguration = ConfigureWebApi();

            app.UseCors(new Microsoft.Owin.Cors.CorsOptions());

            // Use the extension method provided by the WebApi.Owin library:
            app.UseWebApi(webApiConfiguration);

            app.UseFileServer(new FileServerOptions
            {
                RequestPath = new PathString(string.Empty),
                FileSystem = new PhysicalFileSystem("./public"),
                EnableDirectoryBrowsing = true
            });

            app.UseStageMarker(PipelineStage.MapHandler);
        }


        private HttpConfiguration ConfigureWebApi()
        {
            var config = new HttpConfiguration();
            //config.EnableCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional });

            return config;
        }
    }
}
