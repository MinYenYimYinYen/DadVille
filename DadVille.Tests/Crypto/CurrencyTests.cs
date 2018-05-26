using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Crypto;

namespace DadVille.Tests.Crypto
{
	[TestClass]
	public class CurrencyTests
	{
		[TestMethod]
		public void CreateNew_Ctor_ReturnsEmptyCurrency()
		{
			//Arrange
			Currency test = new Currency();
			//Act

			//Assert
			Assert.IsNotNull(test);
		}

	}
}
