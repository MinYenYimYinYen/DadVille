using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Cover;

namespace DadVille.Areas.Cover.Models
{
	public class CoverDbContext:DbContext
	{
		public virtual DbSet<Song> Songs { get; set; }
		public virtual DbSet<Artist> Artists { get; set; }
		public virtual DbSet<Track> Tracks { get; set; }
		public virtual DbSet<Genre> Genres { get; set; }
		public virtual DbSet<Role>	Roles { get; set; }
		public virtual	DbSet<BandMember> BandMembers { get; set; }
		public virtual DbSet<Tag> Tags { get; set; }


		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			#region Define Entity vars
			var song = modelBuilder.Entity<Song>();
			var artist = modelBuilder.Entity<Artist>();
			var track = modelBuilder.Entity<Track>();
			var genre = modelBuilder.Entity<Genre>();
			var role = modelBuilder.Entity<Role>();
			var bandMember = modelBuilder.Entity<BandMember>();

			#endregion

			#region Map Entity to db
			//salesContest.ToTable("SalesContest");
			song.ToTable("Song");
			artist.ToTable("Artist");
			track.ToTable("Track");
			genre.ToTable("Genre");
			role.ToTable("Role");
			bandMember.ToTable("BandMember");

			#endregion

			#region SetPrimaryKeys
			//int maxKeyLength = 32;
			//salesContest.Property(sc => sc.SalesContestID).HasMaxLength(maxKeyLength);

			#endregion

			#region SetForeignKeys_OneToMany
			artist.HasMany(a => a.Songs).WithOptional(s => s.Artist).HasForeignKey(a => a.AristID);
			song.HasMany(s => s.Roles).WithRequired(r => r.Song).HasForeignKey(s => s.SongID);


			#endregion

			#region SetForeignKeys_Optional
			song.HasOptional(s => s.Track).WithRequired(t => t.Song).WillCascadeOnDelete(false);
			#endregion

			#region SetForeignKeys_ManyToMany
			song.HasMany(s => s.Genres).WithMany(g => g.Songs)
				.Map(m =>
				{
					m.ToTable("SongGenre")
					.MapLeftKey("SongID")
					.MapRightKey("GenreID");
				});

			song.HasMany(s => s.Tags).WithMany(t => t.Songs)
				.Map(m =>
				{
					m.ToTable("SongTag")
					.MapLeftKey("SongID")
					.MapRightKey("TagID");
				});
			#endregion

			#region ClassHeirarchy Keys
			//script.HasMany(s => s.SubScripts).WithOptional(ss => ss.SuperScript).HasForeignKey(s => s.SuperScriptID);

			#endregion
		}
	}
}