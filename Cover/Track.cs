using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cover
{
	public class Track
	{
		[Key]
		public int? TrackID { get; set; }

		public int SongID { get; set; }
		public Song Song { get; set; }

		public string PathMP3 { get; set; }
		public string PathWAV { get; set; }
		public string AYouTube { get; set; }

		public PlaybackSource? PlayBackSource { get; set; }

		public enum PlaybackSource
		{
			MP3, Wave, YouTube
		}
	}
}
