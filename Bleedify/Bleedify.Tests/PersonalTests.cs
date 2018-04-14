using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BleedifyModels.ModelsEF;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bleedify.Tests
{
    [TestClass]
    public class PersonalTests
    {
        private Personal _testPersonal;


        [TestInitialize]
        public void InitializeTest()
        {
            _testPersonal = new Personal();
        }


        [TestMethod]
        public void TestGettersPersonal()
        {
            // Arrange
            Utilizator _utilzatorForTest = new Utilizator();
            _utilzatorForTest.Id = 223;

            // Act
            _testPersonal.Id = 1;
            _testPersonal.IdUtilizator = _utilzatorForTest.Id;
            _testPersonal.Nume = "Mister";
            _testPersonal.Prenume = "Bleedify";

            // Assert
            Assert.IsTrue(_testPersonal.Id == 1);
            Assert.IsTrue(_testPersonal.IdUtilizator == _utilzatorForTest.Id);
            Assert.IsTrue(String.Compare(_testPersonal.Nume, "Mister") == 0);
            Assert.IsTrue(String.Compare(_testPersonal.Prenume, "Bleedify") == 0);
        }
    }
}
