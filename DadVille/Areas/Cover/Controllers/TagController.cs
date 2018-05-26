using DadVille.Areas.Cover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DadVille.Areas.Cover.Controllers
{
	public class TagController : Controller
	{
		private CoverDbContext db = new CoverDbContext();


		[HttpGet]
		public ActionResult Index()
		{
			var tags = db.Tags.Where(t => t.Active);

			return View(tags.ToList());
		}


	}
}