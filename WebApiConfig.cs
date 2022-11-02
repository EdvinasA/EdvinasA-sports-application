using System.Web.Http;
using System.Web.Http.Cors;

namespace SaveApp
{
    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {
            var cors = new EnableCorsAttribute("http://localhost:3000", "*", "*");
            config.EnableCors(cors);
        }
    }
}