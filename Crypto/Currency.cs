using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
	public class Currency
	{
		[Key, MaxLength(8), Required, MinLength(1), DatabaseGenerated(DatabaseGeneratedOption.None)]
		public string CurrencyID { get; set; }

		[MinLength(3), MaxLength(32)]
		public string Name { get; set; }

		public List<PricePoint> PricePoints { get; set; }

		public List<PricePoint> BasePricePoints { get; set; }
	}
}
