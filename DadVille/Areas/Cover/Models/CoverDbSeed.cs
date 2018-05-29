using Cover;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace DadVille.Areas.Cover.Models.Migrations
{
	/// <summary>
	/// The rest of this partial class is in the Migrations folder.
	/// I separated it because I want the seed instructions on their own.
	/// </summary>
	partial class Configuration : DbMigrationsConfiguration<DadVille.Areas.Cover.Models.CoverDbContext>
	{
		private static CoverDbContext db = new CoverDbContext();
		protected override void Seed(DadVille.Areas.Cover.Models.CoverDbContext context)
		{
			//SeedTag();
			//SeedSong();
			//SeedSongTag();
			//SeedArtist();


		}

		public static void Seed_Startup()
		{
			//SeedTag();
			//SeedSong();
			//SeedSongTag();
			//SeedArtist();
			//SeedGenre();
			//SeedSongGenre();
			//AssignArtistToSong();
			//AssignNewGenreNewSongNewTag();
		}

		#region Entity Assignments
		public static void SeedTag()
		{
			var tag1 = new Tag { Name = "Dance" };
			var tag2 = new Tag { Name = "Head-Bang" };
			AddOrUpdate.Tag(tag1);
			AddOrUpdate.Tag(tag2);
		}

		public static void SeedSong()
		{
			//var song1 = new Song { Title = "High Speed Dirt" };
			//var song2 = new Song { Title = "Boot Scootin' Boogey" };
			//AddOrUpdate.Song(song1);
			//AddOrUpdate.Song(song2);

		}

		public static void SeedArtist()
		{
			var artist = new Artist { Name = "Megadeth" };
			AddOrUpdate.Artist(artist);
		}

		public static void SeedGenre()
		{
			var genre = new Genre { Name = "Pop Country" };
			AddOrUpdate.Genre(genre);
		}

		#endregion

		#region One to Many Assignments
		public static void AssignArtistToSong()
		{
			var artist = db.Artists.Include("Songs").Where(a => a.Name == "Megadeth").Single();
			var song = db.Songs.Where(s => s.Title == "High Speed Dirt").Single();
			Assign.Artist_Song(artist, song);
		}
		#endregion

		#region Many to Many Assignments
		//public static void SeedSongTag()
		//{
		//	var tag = db.Tags.Include("Songs").Where(t => t.Name == "Dance").Single();
		//	var song = db.Songs.Where(s => s.Title == "Boot Scootin' Boogey").Single();
		//	Assign.Tag_Song(tag, song);
		//}

		//public static void SeedSongGenre()
		//{
		//	var genre = db.Genres.Include("Songs").Where(g => g.Name == "Pop Country").Single();
		//	var song = db.Songs.Where(s => s.Title == "Boot Scootin' Boogey").Single();
		//	Assign.Genre_Song(genre, song);
		//}

		#endregion

		#region Assign New
		public static void AssignNewGenreNewSongNewTag()
		{
			//var stairway = AddOrUpdate.Song(new Song { Title = "Stairway To Heaven" });
			//var x = 
		}
	
		#endregion
	}
}