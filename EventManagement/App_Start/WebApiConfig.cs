using System.Web.Http;
using System.Web.Http.Cors;

namespace EventManagement
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Habilitar CORS globalmente para tu API
            var cors = new EnableCorsAttribute("https://localhost:44361", "*", "*"); // Permite solo desde https://localhost:44307
            config.EnableCors(cors);

            // Configuración de rutas de la API
            config.MapHttpAttributeRoutes();
        }
    }
}
