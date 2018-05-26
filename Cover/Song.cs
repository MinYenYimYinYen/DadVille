using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cover
{
	public class Song
	{
		public Song()
		{
			Active = true;
			Genres = new List<Genre>();
			Tags = new List<Tag>();
			Roles = new List<Cover.Role>();
		}

		[Key]
		public int? SongID { get; set; }
		public string Title { get; set; }

		public int? AristID { get; set; }
		public Artist Artist { get; set; }

		public int? TrackID { get; set; }
		public Track Track { get; set; }

		public List<Genre> Genres { get; set; }

		public int? ReleaseYear { get; set; }
		public TimeSpan	PerformanceTime { get; set; }

		public List<Tag> Tags { get; set; }

		public List<Role> Roles { get; set; }

		public bool Active { get; set; }






	}
}
