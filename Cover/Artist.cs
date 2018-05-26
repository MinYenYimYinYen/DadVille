using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cover
{
	public class Artist
	{
		[Key]
		public int? ArtistID { get; set; }
		public string Name { get; set; }

		public List<Song> Songs { get; set; }
	}
}
