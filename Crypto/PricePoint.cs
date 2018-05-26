using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
	public	class PricePoint
	{
		[Key]
		public int PricePointID { get; set; }

		public decimal Price { get; set; }

		public string PriceOfID { get; set; }
		public Currency PriceOf { get; set; }

		public string PricedByID { get; set; }
		public Currency PricedBy { get; set; }

		public DateTime DateTime { get; set; }
	}
}
