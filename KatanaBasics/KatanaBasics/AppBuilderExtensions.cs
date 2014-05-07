using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatanaBasics
{
	public static class AppBuilderExtensions
	{
		public static void UseWelcomeComponent(this IAppBuilder appBuilder)
		{
			appBuilder.Use<WelcomeComponent>();
		}
	}
}
