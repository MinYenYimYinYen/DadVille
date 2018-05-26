using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DadVille.Areas.Cover.Models;
using System.Data.Entity.Migrations;
using Cover;
using System.Linq;

namespace DadVille.Tests.Cover
{
	[TestClass]
	public class Seed
	{
		private CoverDbContext db = new CoverDbContext();

		[TestMethod]
		public void AddTag()
		{
			//Arrange
			db.Tags.AddOrUpdate(t => t.Name, new Tag { Name = "Dance" });
			db.Tags.AddOrUpdate(t => t.Name, new Tag { Name = "Head-Bang" });
			//Act
			db.SaveChanges();
			var tagDance = db.Tags.Where(t => t.Name == "Dance").SingleOrDefault();
			//Assert
			Assert.IsNotNull(tagDance);
		}

		[TestMethod]
		public void AddSong()
		{
			//Arrange
			db.Songs.AddOrUpdate(s => s.Title, new Song { Title = "High Speed Dirt" });
			db.Songs.AddOrUpdate(s => s.Title, new Song { Title = "Boot Scootin' Boogey" });
			//Act
			db.SaveChanges();
			var boot = db.Songs.Where(s => s.Title == "Boot Scootin' Boogey").SingleOrDefault();
			//Assert
			Assert.IsNotNull(boot);
		}





		//var highSpeedDirt = db.Songs.Where(s => s.Title == "High Speed Dirt").Single();
		//if (highSpeedDirt.Tags.Where(t=>t.Name == tagBang.Name).SingleOrDefault()==null)
		//	highSpeedDirt.Tags.Add(tagBang);

		//var bootScoot = db.Songs.Where(s => s.Title == "Boot Scootin' Boogey").Single();
		//if (bootScoot.Tags.Where(t=>t.Name == tagDance.Name).SingleOrDefault()==null)
		//	bootScoot.Tags.Add(tagDance);


	}
}

