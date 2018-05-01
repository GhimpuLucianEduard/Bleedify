using BleedifyModels.ModelsEF;
using BleedifyModels.Repositories;
using BleedifyModels.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        [TestInitialize]
        public void InitializeTest()
        {
            _componentaRepository = new ComponentaRepository(new ComponentaValidator());
        }


        [TestCleanup]
        public void CleanUpTest()
        {
            _componentaRepository.GetAll().ToList().ForEach(x =>
            {
                if (x.Stare.CompareTo("TEST")==0)
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

            _componenta.TipComponenta = "TEST";
            _componenta.IdDonatie = 2;
            _componenta.DataDepunere = _datetimeDepunere;
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
            _componenta.TipComponenta = "TEST";
            _componenta.IdDonatie = 2;
            _componenta.DataDepunere = _datetimeDepunere;
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
        }

        #endregion

        #region UpdateTest

        [TestMethod]
        public void UpdateComponentaTest()
        {
            var _datetimeDepunere = new DateTime(2018, 4, 14);
            var _datetimeDonare = new DateTime(2018, 4, 14);
            var _componenta = new Componenta();

            _componenta.TipComponenta = "TEST";
            _componenta.IdDonatie = 2;
            _componenta.DataDepunere = _datetimeDepunere;
            _componenta.Stare = "TEST";

            var _newDateTime = new DateTime(2018, 4, 13);
            try
            {
                _componentaRepository.Add(_componenta);
                _componenta.TipComponenta = "TESTUPDATE";
            }
            catch (Exception)
            {
                Assert.Fail();
            }

            var _foundComponenta = _componentaRepository.Find(_componenta.Id);
            Assert.IsTrue(_foundComponenta.IdDonatie == 2);
        }

        #endregion

        #region DeleteTest

        [TestMethod]
        public void DeleteComponentaTest()
        {
            var _datetimeDepunere = new DateTime(2018, 4, 14);
            var _datetimeDonare = new DateTime(2018, 4, 14);
            var _componenta = new Componenta();
            _componenta.TipComponenta = "TEST";
            _componenta.IdDonatie = 1;
            _componenta.DataDepunere = _datetimeDepunere;
            _componenta.Stare = "TEST";

            var _initialSize = _componentaRepository.GetAll().Count();

            try
            {
                _componentaRepository.Add(_componenta);
                _componentaRepository.Delete(_componenta.Id);
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
            }

            Assert.IsTrue(_initialSize == _componentaRepository.GetAll().Count());
        }

        #endregion
    }
}
