using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cover
{
public	class Tag
	{
		public Tag()
		{
			Active = true;
		}

		[Key]
		public int? TagID { get; set; }
		
		public string Name { get; set; }

		public List<Song> Songs { get; set; }

		public bool Active { get; set; }


	}
}
