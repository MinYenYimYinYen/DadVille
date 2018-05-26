using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cover
{
	public class Genre
	{
		[Key]
		public int? GenreID { get; set; }

		public string Name { get; set; }

		public List<Song> Songs { get; set; }
	}
}
