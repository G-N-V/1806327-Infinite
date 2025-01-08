using Swashbuckle.Application;
using System.Web.Http;

namespace WebAPI
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "Country API");
                })
                .EnableSwaggerUi();
        }
    }
}
