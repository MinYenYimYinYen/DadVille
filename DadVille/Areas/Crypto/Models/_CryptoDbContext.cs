using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Crypto;

namespace DadVille.Areas.Crypto.Models
{
	public class CryptoDbContext:DbContext
	{
		//add-migration -configuration DadVille.Areas.Crypto.Migrations.Configuration
		public virtual DbSet<Bank> Banks { get; set; }	
		public virtual DbSet<Account> Accounts { get; set; }
		public virtual DbSet<Currency> Currencies { get; set; }
		public virtual DbSet<PricePoint>PricePoints { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			#region Define Entity vars
			var bank = modelBuilder.Entity<Bank>();
			var account = modelBuilder.Entity<Account>();
			var currency = modelBuilder.Entity<Currency>();
			var pricePoint = modelBuilder.Entity<PricePoint>();

			#endregion

			#region Map Entity to db
			//salesContest.ToTable("SalesContest");
			bank.ToTable("Bank");
			account.ToTable("Account");
			currency.ToTable("Currency");
			pricePoint.ToTable("PricePoint");

			#endregion

			#region SetPrimaryKeys
			//int maxKeyLength = 32;
			//salesContest.Property(sc => sc.SalesContestID).HasMaxLength(maxKeyLength);

			#endregion

			#region SetForeignKeys_OneToMany
			//employee.HasMany(e => e.DirectReports).WithRequired(dr => dr.Employee).HasForeignKey(e => e.EmployeeID);
			bank.HasMany(x => x.Accounts).WithRequired(x => x.Bank).HasForeignKey(x=>x.BankID);
			currency.HasMany(x => x.PricePoints).WithRequired(x => x.PriceOf).HasForeignKey(x => x.PriceOfID);
			currency.HasMany(x => x.BasePricePoints).WithRequired(x => x.PricedBy).HasForeignKey(x => x.PricedByID).WillCascadeOnDelete(false);
			#endregion


			#region SetForeignKeys_ManyToMany
			//department.HasMany(d => d.Scripts).WithMany(s => s.Departments)
			//	.Map(m =>
			//	{
			//		m.ToTable("DeptsScripts")
			//		 .MapLeftKey("DepartmentID")
			//		 .MapRightKey("ScriptID");
			//	});
			#endregion

			#region ClassHeirarchy Keys
			//script.HasMany(s => s.SubScripts).WithOptional(ss => ss.SuperScript).HasForeignKey(s => s.SuperScriptID);

			#endregion
		}
	}
}