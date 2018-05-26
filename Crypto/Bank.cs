using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
	public class Bank
	{

		public Bank()
		{
			Accounts = new List<Account>();
		}

		[Key, MaxLength(8), Required, MinLength(3), DatabaseGenerated(DatabaseGeneratedOption.None)]
		public string BankID { get; set; }

		[MinLength(3),MaxLength(32)]
		public string Name { get; set; }


		public List<Account> Accounts { get; set; }
		
	}
}
