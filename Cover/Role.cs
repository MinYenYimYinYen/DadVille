using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cover
{
public	class Role
	{
		[Key]
		public int? RoleID { get; set; }

		public string Description { get; set; }

		public int SongID { get; set; }
		public Song Song { get; set; }

		[Required]
		public int BandMemberID { get; set; }
		public BandMember BandMember { get; set; }



	}
}
