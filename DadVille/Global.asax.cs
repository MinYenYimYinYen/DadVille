using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DadVille
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			Areas.Cover.Models.Migrations.Configuration.Seed_Startup();
			AreaRegistration.RegisterAllAreas();
			RouteConfig.RegisterRoutes(RouteTable.Routes);

		}
	}
}
