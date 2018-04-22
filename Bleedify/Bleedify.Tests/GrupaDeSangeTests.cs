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
    class GrupaDeSangeTests
    {
        private GrupaDeSange _testGrupaDeSange;

        [TestInitialize]
        public void InitializeTest()
        {
            _testGrupaDeSange = new GrupaDeSange();
        }

        [TestMethod]
        public void TestGettersGrupaDeSange()
        {
            _testGrupaDeSange.Id = 1;
            _testGrupaDeSange.Nume = "NumeGrupaDeSange";
            _testGrupaDeSange.CerereMedicPacients = new List<CerereMedicPacient>();
            _testGrupaDeSange.Componentas = new List<Componenta>();
            _testGrupaDeSange.Donators = new List<Donator>();
            _testGrupaDeSange.Pacients = new List<Pacient>();

            Assert.IsTrue(_testGrupaDeSange.Id == 1);
            Assert.IsTrue(String.Compare(_testGrupaDeSange.Nume, "NumeGrupaDeSange") == 0);
            Assert.IsTrue(_testGrupaDeSange.CerereMedicPacients.Count == 0);
            Assert.IsTrue(_testGrupaDeSange.Componentas.Count == 0);
            Assert.IsTrue(_testGrupaDeSange.Donators.Count == 0);
            Assert.IsTrue(_testGrupaDeSange.Pacients.Count == 0);
        }

        [TestMethod]
        public void TestSettersGrupaDeSange()
        {
            _testGrupaDeSange.Id = 1;
            _testGrupaDeSange.Nume = "NumeGrupaDeSange";
            _testGrupaDeSange.CerereMedicPacients = new List<CerereMedicPacient>();
            _testGrupaDeSange.Componentas = new List<Componenta>();
            _testGrupaDeSange.Donators = new List<Donator>();
            _testGrupaDeSange.Pacients = new List<Pacient>();

            Assert.IsTrue(_testGrupaDeSange.Id == 1);
            Assert.IsTrue(String.Compare(_testGrupaDeSange.Nume, "NumeGrupaDeSange") == 0);
            Assert.IsTrue(_testGrupaDeSange.CerereMedicPacients.Count == 0);
            Assert.IsTrue(_testGrupaDeSange.Componentas.Count == 0);
            Assert.IsTrue(_testGrupaDeSange.Donators.Count == 0);
            Assert.IsTrue(_testGrupaDeSange.Pacients.Count == 0);
        }
    }
}
