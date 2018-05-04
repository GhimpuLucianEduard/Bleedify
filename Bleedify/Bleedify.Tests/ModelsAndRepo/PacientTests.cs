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
    public class PacientTests
    {
        #region Private Testing Fields  

        private Pacient _testPacient;

        #endregion

        #region Initialize and Clean

        [TestInitialize]
        public void InitializeTest()
        {
            _testPacient = new Pacient();
        }

        #endregion

        #region Test Methods

        [TestMethod]
        public void TestGettersPacient()
        {
            var _datetime = new DateTime(1997, 3, 20);
            _testPacient.Id = 1;
         
            _testPacient.Nume = "Maria";
            _testPacient.Prenume = "Pop";
            _testPacient.GrupaDeSange = 1;
            _testPacient.DataNastere = _datetime;
            _testPacient.InstitutieAsociata = 1 ;

            Assert.IsTrue(_testPacient.Id == 1);
            Assert.IsTrue(String.Compare(_testPacient.Nume, "Maria") == 0);
            Assert.IsTrue(String.Compare(_testPacient.Prenume, "Pop") == 0);
            Assert.IsTrue(_testPacient.DataNastere == _datetime);
        }

        #endregion
    }
}
