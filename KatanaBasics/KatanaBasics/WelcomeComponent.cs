using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationFunction = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;

namespace KatanaBasics
{
	public class WelcomeComponent
	{
		private readonly ApplicationFunction _nextComponent;

		public WelcomeComponent(ApplicationFunction appFunc)
		{
			if (appFunc == null) throw new ArgumentNullException("AppFunc of next component");
			_nextComponent = appFunc;
		}

		public Task Invoke(IDictionary<string, object> environment)
		{
			Stream responseBody = environment["owin.ResponseBody"] as Stream;
			using (StreamWriter responseWriter = new StreamWriter(responseBody))
			{
				return responseWriter.WriteAsync("Hello from the welcome component");
			}
			//await _nextComponent(environment);
		}
	}
}
