using System;
using BleedifyModels.Enums;
using BleedifyModels.ModelsEF;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bleedify.Tests
{
	[TestClass]
	public class UtilizatorTests
	{
		#region Private Testing Fields

		private Utilizator _testUtilizator;

		#endregion

		#region Initialize and Clean

		[TestInitialize]
		public void InitializeTest()
		{
			_testUtilizator = new Utilizator();
		}

		#endregion

		#region Test Methods

		[TestMethod]
		public void TestGetters()
		{
			// Arrange

			// Act
			_testUtilizator.TipUtilizator = TipUtilizator.Medic.ToString();

			// Assert
			Assert.IsTrue(String.Compare(_testUtilizator.TipUtilizator, TipUtilizator.Medic.ToString(), StringComparison.Ordinal) == 0);
		}

		#endregion
	}
}
