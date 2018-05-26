using Cover;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace DadVille.Areas.Cover.Models
{
	public static class AddOrUpdate
	{
		private static CoverDbContext db = new CoverDbContext();
		public static Song AddSong(this Song _song)
			//What if this whole situation was extension methods for the classes, pertaining to CRUD
		{
			var song = _song;
			var existingsong = db.Songs.Where(s => s.Title == song.Title).SingleOrDefault();
			if (existingsong == null)
			{
				db.Songs.Add(song);
			}
			else
			{
				existingsong.Active = _song.Active;
				existingsong.Artist = _song.Artist;
				existingsong.Genres = _song.Genres;
				existingsong.PerformanceTime = _song.PerformanceTime;
				existingsong.ReleaseYear = _song.ReleaseYear;
				existingsong.Roles = _song.Roles;
				existingsong.Tags = _song.Tags;
				existingsong.Track = _song.Track;
			}
			db.SaveChanges();
			var check = db.Songs.Where(s => s.Title == song.Title).Single();
			return check;
		}
		public static Artist Artist(Artist artist)
		{
			var existingArtist = db.Artists.Where(a => a.Name == artist.Name).SingleOrDefault();
			if (existingArtist == null)
			{
				db.Artists.Add((Artist)artist);
			}
			else
			{
				existingArtist.Songs = artist.Songs;
			}
			db.SaveChanges();
			var check = db.Artists.Where(a => a.Name == artist.Name).Single();
			return check;
		}
		public static Genre Genre(Genre genre)
		{
			var existingGenre = db.Genres.Where(g => g.Name == genre.Name).SingleOrDefault();
			if (existingGenre == null)
			{
				db.Genres.Add(genre);
			}
			else
			{
				existingGenre.Songs = genre.Songs;
			}
			db.SaveChanges();
			var check = db.Genres.Where(g => g.Name == genre.Name).Single();
			return check;

		}
		public static Tag Tag(Tag tag)
		{
			var existingTag = db.Tags.Where(t => t.Name == tag.Name).SingleOrDefault();
			if (existingTag == null)
			{
				db.Tags.Add(tag);
			}
			db.SaveChanges();
			var check = db.Tags.Where(t => t.Name == tag.Name).Single();
			return check;
		}

	}
	public static class Assign
	{
		private static CoverDbContext db = new CoverDbContext();

		#region OneToMany
		public static bool Artist_Song(Artist artist, Song song)
		{
			var existingArtist = db.Artists.Where(a => a.Name == artist.Name).SingleOrDefault();
			if (existingArtist == null) existingArtist = AddOrUpdate.Artist(artist);

			var existingSong = db.Songs.Include("Artist").Where(s => s.Title == song.Title).SingleOrDefault();
			if (existingSong == null) existingSong = AddOrUpdate.AddSong(song);

			if (existingSong.Artist == null)
			{
				existingSong.Artist = existingArtist;
				db.SaveChanges();
				return true;
			}

			existingSong.Artist = existingArtist;
			db.SaveChanges();
			return true;

		}
		#endregion

		#region ManyToMany
		public static bool Tag_Song(Tag tag, Song song)
		{
			var existingTag = db.Tags.Where(t => t.Name == tag.Name).SingleOrDefault();
			if (existingTag == null) existingTag = AddOrUpdate.Tag(tag);

			var existingSong = db.Songs.Include("Tags").Where(s => s.Title == song.Title).SingleOrDefault();
			if (existingSong == null) existingSong = AddOrUpdate.Song(song);

			bool songHasTag = (existingSong.Tags.Where(t => t.Name == existingTag.Name).SingleOrDefault() != null);
			if (!songHasTag)
			{
				existingSong.Tags.Add(existingTag);
			}
			db.SaveChanges();

			return true;
		}

		public static bool Genre_Song(Genre genre, Song song)
		{
			var existingGenre = db.Genres.Where(t => t.Name == genre.Name).SingleOrDefault();
			if (existingGenre == null) existingGenre = AddOrUpdate.Genre(genre);

			var existingSong = db.Songs.Include("Genres").Where(s => s.Title == song.Title).SingleOrDefault();
			if (existingSong == null) existingSong = AddOrUpdate.Song(song);

			bool songHasGenre = (existingSong.Genres.Where(t => t.Name == existingGenre.Name).SingleOrDefault() != null);
			if (!songHasGenre)
			{
				existingSong.Genres.Add(existingGenre);
			}
			db.SaveChanges();
			return true;
		}
		#endregion
	}
}