using BleedifyModels.ModelsEF;
using BleedifyModels.Repositories;
using BleedifyModels.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bleedify.Tests
{
    [TestClass]
    public class ComponentaRepositoryTests
    {
        #region Initialization and Cleanup

        private static ComponentaRepository _componentaRepository;


        [ClassInitialize]
        public static void InitializeTest(TestContext context)
        {
            _componentaRepository = new ComponentaRepository(new ComponentaValidator());
        }


        [ClassCleanup]
        public static void CleanUpTest()
        {
            _componentaRepository.GetAll().ToList().ForEach(x =>
            {
                if (String.Compare(x.TipComponenta, "TEST", StringComparison.Ordinal) == 0 ||
                    String.Compare(x.TipComponenta, "TESTUPDATE", StringComparison.Ordinal) == 0)
                {
                    _componentaRepository.Delete(x.Id);
                }
            });
        }

        #endregion

        #region AddTest

        [TestMethod]
        public void AddComponentaTest()
        {
            var _datetimeDepunere = new DateTime(2018, 4, 14);
            var _datetimeDonare = new DateTime(2018, 4, 14);
            var _componenta = new Componenta();
            _componenta.Id = 1;
            _componenta.TipComponenta = "TEST";
            _componenta.IdDonatie = 1;
            _componenta.DataDepunere = _datetimeDepunere;
            _componenta.IdPrimitor = 1;
            _componenta.InstitutieAsociata = 1;
            _componenta.GrupaDeSange = 1;
            _componenta.DataDonare = _datetimeDonare;
            _componenta.Stare = "TEST";
           

            var _initialSize = _componentaRepository.GetAll().Count();

            try
            {
                _componentaRepository.Add(_componenta);
            }
            catch (Exception e)
            {
                Assert.Fail();
            }

            Assert.IsTrue(_componentaRepository.GetAll().Count() == _initialSize + 1);
        }

        #endregion

        #region FindTest

        [TestMethod]
        public void FindComponentaTest()
        {
            var _datetimeDepunere = new DateTime(2018, 4, 14);
            var _datetimeDonare = new DateTime(2018, 4, 14);
            var _componenta = new Componenta();
            _componenta.Id = 1;
            _componenta.TipComponenta = "TEST";
            _componenta.IdDonatie = 1;
            _componenta.DataDepunere = _datetimeDepunere;
            _componenta.IdPrimitor = 1;
            _componenta.InstitutieAsociata = 1;
            _componenta.GrupaDeSange = 1;
            _componenta.DataDonare = _datetimeDonare;
            _componenta.Stare = "TEST";

            Componenta _foundComponenta = null;

            try
            {
                _componentaRepository.Add(_componenta);
                _foundComponenta = _componentaRepository.Find(_componenta.Id);
            }
            catch (Exception)
            {
                Assert.Fail();
            }

            Assert.IsTrue(_foundComponenta != null);
            Assert.IsTrue(_foundComponenta.Id == _componenta.Id);
            Assert.IsTrue(_foundComponenta.TipComponenta == _componenta.TipComponenta);
            Assert.IsTrue(_foundComponenta.IdDonatie == _componenta.IdDonatie);
            Assert.IsTrue(_foundComponenta.DataDepunere == _componenta.DataDepunere);
            Assert.IsTrue(_foundComponenta.IdPrimitor == _componenta.IdPrimitor);
            Assert.IsTrue(_foundComponenta.InstitutieAsociata == _componenta.InstitutieAsociata);
            Assert.IsTrue(_foundComponenta.GrupaDeSange == _componenta.GrupaDeSange);
            Assert.IsTrue(_foundComponenta.DataDonare == _componenta.DataDonare);
            Assert.IsTrue(_foundComponenta.Stare == _componenta.Stare);
        }

        #endregion

        #region UpdateTest

        [TestMethod]
        public void UpdateComponentaTest()
        {
            var _datetimeDepunere = new DateTime(2018, 4, 14);
            var _datetimeDonare = new DateTime(2018, 4, 14);
            var _componenta = new Componenta();
            _componenta.Id = 1;
            _componenta.TipComponenta = "TEST";
            _componenta.IdDonatie = 1;
            _componenta.DataDepunere = _datetimeDepunere;
            _componenta.IdPrimitor = 1;
            _componenta.InstitutieAsociata = 1;
            _componenta.GrupaDeSange = 1;
            _componenta.DataDonare = _datetimeDonare;
            _componenta.Stare = "TEST";

            var _newDateTime = new DateTime(2018, 4, 13);
            try
            {
                _componentaRepository.Add(_componenta);
                _componenta.TipComponenta = "TESTUPDATE";
                _componenta.IdDonatie = 1;
                _componenta.DataDepunere = _newDateTime;
                _componenta.IdPrimitor = 1;
                _componenta.InstitutieAsociata = 1;
                _componenta.GrupaDeSange = 1;
                _componenta.DataDonare = _datetimeDonare;
                _componenta.Stare = "TESTUPDATE";
                _componentaRepository.Update(_componenta);
            }
            catch (Exception)
            {
                Assert.Fail();
            }

            var _foundComponenta = _componentaRepository.Find(_componenta.Id);
            Assert.IsTrue(_foundComponenta.IdDonatie == 1);
            Assert.IsTrue(_foundComponenta.IdPrimitor == 1);
            Assert.IsTrue(_foundComponenta.InstitutieAsociata == 1);
            Assert.IsTrue(_foundComponenta.GrupaDeSange == 1);
            Assert.IsTrue(_foundComponenta.TipComponenta == "TESTUPDATE");
            Assert.IsTrue(_foundComponenta.Stare == "TESTUPDATE");
            Assert.IsTrue(_foundComponenta.DataDepunere == _newDateTime);
            Assert.IsTrue(_foundComponenta.DataDonare == _datetimeDonare);
        }

        #endregion

        #region DeleteTest

        [TestMethod]
        public void DeleteComponentaTest()
        {
            var _datetimeDepunere = new DateTime(2018, 4, 14);
            var _datetimeDonare = new DateTime(2018, 4, 14);
            var _componenta = new Componenta();
            _componenta.Id = 1;
            _componenta.TipComponenta = "TEST";
            _componenta.IdDonatie = 1;
            _componenta.DataDepunere = _datetimeDepunere;
            _componenta.IdPrimitor = 1;
            _componenta.InstitutieAsociata = 1;
            _componenta.GrupaDeSange = 1;
            _componenta.DataDonare = _datetimeDonare;
            _componenta.Stare = "TEST";

            var _initialSize = _componentaRepository.GetAll().Count();

            try
            {
                _componentaRepository.Add(_componenta);
                _componentaRepository.Delete(_componenta.Id);
            }
            catch (Exception)
            {
                Assert.Fail();
            }

            Assert.IsTrue(_initialSize == _componentaRepository.GetAll().Count());
        }

        #endregion
    }
}
