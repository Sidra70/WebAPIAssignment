using Newtonsoft.Json.Serialization;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebAPIAssignment
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            /*var authority = "https://{yourOktaDomain}/oauth2/default";
            private var configurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(
                authority + "/.well-known/openid-configuration",
                new OpenIdConnectConfigurationRetriever(),new HttpDocumentRetriever());
        private var discoveryDocument = Task.Run(() => configurationManager.GetConfigurationAsync()).GetAwaiter().GetResult();
        private static string authority;

        public Func<object, object, object, object, object> IssuerSigningKeyResolver { get; }
        public object DiscoveryDocument { get => discoveryDocument; set => discoveryDocument = value; }

        app.UseJwtBearerAuthentication(
   new JwtBearerAuthenticationOptions
   {
       AuthenticationMode = AuthenticationMode.Active,
       TokenValidationParameters = new TokenValidationParameters()
        {
            ValidAudience = "api://default",
           ValidIssuer = authority,
           IssuerSigningKeyResolver = (token, securityToken, identifier, parameters) =>
           {
               return DiscoveryDocument.SigningKeys;
           }
       }
    });
*/
            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
            app.UseWebApi(config);
        }
    }
}