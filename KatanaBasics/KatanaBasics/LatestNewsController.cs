using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace KatanaBasics
{
	public class LatestNewsController : ApiController
	{
		public HttpResponseMessage Get()
		{
			LatestNews news = new LatestNews() { Summary = "The world is falling apart." };
			return Request.CreateResponse<LatestNews>(HttpStatusCode.OK, news);
		}
	}
}
