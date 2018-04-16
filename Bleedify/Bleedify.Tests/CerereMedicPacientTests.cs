using System;
using BleedifyModels.Enums;
using BleedifyModels.ModelsEF;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Bleedify.Tests
{
    [TestClass]
    public class CerereMedicPacientTests
    {
        #region Private Testing Fields

        private CerereMedicPacient _testCerereMedicPacient;

        #endregion

        #region Initialize and Clean

        [TestInitialize]
        public void InitializeTest()
        {
            _testCerereMedicPacient = new CerereMedicPacient();
        }

        #endregion

        #region Test Methods

        [TestMethod]
        public void TestGetters()
        {
            // Arrange

            // Act
            _testCerereMedicPacient.Id = 1;
            _testCerereMedicPacient.IdMedic = 2;
            _testCerereMedicPacient.IdPacient = 3;
            _testCerereMedicPacient.GrupaDeSange = 4;

            _testCerereMedicPacient.TipComponenta = TipComponenta.GlobuleRosii.ToString();
            _testCerereMedicPacient.Stare = StareCerere.InAsteptare.ToString();

            // Assert
            Assert.IsTrue(_testCerereMedicPacient.Id == 1);
            Assert.IsTrue(_testCerereMedicPacient.IdMedic == 2);
            Assert.IsTrue(_testCerereMedicPacient.IdPacient == 3);
            Assert.IsTrue(_testCerereMedicPacient.GrupaDeSange == 4);

            Assert.IsTrue(String.Compare(_testCerereMedicPacient.TipComponenta, TipComponenta.GlobuleRosii.ToString(), StringComparison.Ordinal) == 0);
            Assert.IsTrue(String.Compare(_testCerereMedicPacient.Stare, StareCerere.InAsteptare.ToString(), StringComparison.Ordinal) == 0);
        }

        #endregion
    }
}
