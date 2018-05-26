using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cover
{
	public class BandMember
	{
		public BandMember()
		{
			Active = true;
			Roles = new List<Role>();
		}

		[Key, Required, MinLength(2), MaxLength(4)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public string BandMemberID { get; set; }

		public string Name { get; set; }

		public List<Role> Roles { get; set; }

		public bool  Active { get; set; }

	}
}
