using BleedifyModels.ModelsEF;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bleedify.Tests
{
    [TestClass]
    public class MedicTests
    {
        #region Private Testing Fields  
        private Medic _testMedic;
        #endregion

        #region Initialize and Clean
        [TestInitialize]
        public void InitializeTest()
        {
            _testMedic = new Medic();
        }
        #endregion

        #region Test Methods
        [TestMethod]
        public void TestGettersMedic()
        {

            _testMedic.Id = 1;
            _testMedic.IdUtilizator = 2;
            _testMedic.Nume = "Ion";
            _testMedic.Prenume = "Don";
            _testMedic.IdentificatorMedic = "medic1";

            Assert.IsTrue(_testMedic.Id == 1);
            Assert.IsTrue(_testMedic.IdUtilizator == 2);
            Assert.IsTrue(String.Compare(_testMedic.Nume, "Ion") == 0);
            Assert.IsTrue(String.Compare(_testMedic.Prenume, "Don") == 0);
            Assert.IsTrue(String.Compare(_testMedic.IdentificatorMedic,"medic1") == 0);

        }
        #endregion
    }
}
