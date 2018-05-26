namespace DadVille.Areas.Cover.Models.Migrations
{
	using global::Cover;
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;

	internal sealed partial class Configuration : DbMigrationsConfiguration<DadVille.Areas.Cover.Models.CoverDbContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
			MigrationsDirectory = @"Areas\Cover\Models\Migrations";
		}


	}
}
