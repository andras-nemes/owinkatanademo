using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace KatanaBasics
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
			
			/*
			appBuilder.Use(async (env, next) =>
				{
					foreach (KeyValuePair<string, object> kvp in env.Environment)
					{
						Console.WriteLine(string.Concat("Key: ", kvp.Key, ", value: ", kvp.Value));
					}

					await next();
				});*/

			appBuilder.Use(async (env, next) =>
				{
					Console.WriteLine(string.Concat("Http method: ", env.Request.Method, ", path: ", env.Request.Path));
					await next();
					Console.WriteLine(string.Concat("Response code: ", env.Response.StatusCode));
				});

			RunWebApiConfiguration(appBuilder);

			appBuilder.UseWelcomeComponent();

			//appBuilder.UseWelcomePage();

			/*
			appBuilder.Run(owinContext =>
				{
					return owinContext.Response.WriteAsync("Hello from OWIN web server.");
				});*/
        }

		private void RunWebApiConfiguration(IAppBuilder appBuilder)
		{
			HttpConfiguration httpConfiguration = new HttpConfiguration();
			httpConfiguration.Routes.MapHttpRoute(
				name: "WebApi"
				, routeTemplate: "{controller}/{id}"
				, defaults: new { id = RouteParameter.Optional }
				);
			appBuilder.UseWebApi(httpConfiguration);
		}
    }
}
