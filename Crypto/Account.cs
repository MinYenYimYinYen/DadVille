using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
	public class Account
	{
		public Account()
		{

		}

		[Key]
		public int AccountID { get; set; }

		public string BankID { get; set; }
		public Bank Bank { get; set; }

		public string CurrencyID { get; set; }
		public Currency Currency { get; set; }

		[NotMapped]
		public string AutoAlias { get => BankID + '-' + CurrencyID; }

	}
}
