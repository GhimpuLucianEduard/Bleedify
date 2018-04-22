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
    public class DonatorRepositoryTests
    {
        #region Initialization and Cleanup

        private static DonatorRepository _donatorRepository;


        [ClassInitialize]
        public static void InitializeTest(TestContext context)
        {
            _donatorRepository = new DonatorRepository(new DonatorValidator());
        }


        [ClassCleanup]
        public static void CleanUpTest()
        {
            _donatorRepository.GetAll().ToList().ForEach(x =>
            {
                if (String.Compare(x.Nume, "TEST", StringComparison.Ordinal) == 0 ||
                    String.Compare(x.Nume, "TESTUPDATE", StringComparison.Ordinal) == 0)
                {
                    _donatorRepository.Delete(x.Id);
                }
            });
        }

        #endregion

        #region AddTest

        [TestMethod]
        public void AddDonatorTest()
        {
            var _datetime = new DateTime(2018, 4, 14);
            var _donator = new Donator();
            _donator.Id = 1;
            _donator.IdUtilizator = 1;
            _donator.Nume = "TEST";
            _donator.Prenume = "TEST";
            _donator.DataDonarePosibila = _datetime;

            var _initialSize = _donatorRepository.GetAll().Count();

            try
            {
                _donatorRepository.Add(_donator);
            }
            catch (Exception)
            {
                Assert.Fail();
            }

            Assert.IsTrue(_donatorRepository.GetAll().Count() == _initialSize + 1);
        }

        #endregion

        #region FindTest

        [TestMethod]
        public void FindDonatorTest()
        {
            var _datetime = new DateTime(2018, 4, 14);
            var _donator = new Donator();
            _donator.Id = 1;
            _donator.IdUtilizator = 2;
            _donator.Nume = "TEST";
            _donator.Prenume = "TEST";
            _donator.DataDonarePosibila = _datetime;

            Donator _foundDonator = null;

            try
            {
                _donatorRepository.Add(_donator);
                _foundDonator = _donatorRepository.Find(_donator.Id);
            }
            catch (Exception)
            {
                Assert.Fail();
            }

            Assert.IsTrue(_foundDonator != null);
            Assert.IsTrue(_foundDonator.Id == _donator.Id);
            Assert.IsTrue(_foundDonator.IdUtilizator == _donator.IdUtilizator);
            Assert.IsTrue(_foundDonator.Nume == _donator.Nume);
            Assert.IsTrue(_foundDonator.Prenume == _donator.Prenume);
            Assert.IsTrue(_foundDonator.DataDonarePosibila == _donator.DataDonarePosibila);
            Assert.IsTrue(_foundDonator.GrupaDeSange == _donator.GrupaDeSange);

        }

        #endregion

        #region UpdateTest

        [TestMethod]
        public void UpdateDonatorTest()
        {
            var _datetime = new DateTime(2018, 4, 14);
            var _donator = new Donator();
            _donator.Id = 1;
            _donator.IdUtilizator = 2;
            _donator.Nume = "TEST";
            _donator.Prenume = "TEST";
            _donator.DataDonarePosibila = _datetime;

            var _newDateTime = new DateTime(2018, 4, 13);
            try
            {
                _donatorRepository.Add(_donator);
                _donator.IdUtilizator = 2;
                _donator.Nume = "TESTUPDATE";
                _donator.Prenume = "TESTUPDATE";
                _donator.DataDonarePosibila = _newDateTime;
                _donatorRepository.Update(_donator);
            }
            catch (Exception)
            {
                Assert.Fail();
            }

            var _foundDonator = _donatorRepository.Find(_donator.Id);
            Assert.IsTrue(_foundDonator.IdUtilizator == 2);
            Assert.IsTrue(_foundDonator.Nume == "TESTUPDATE");
            Assert.IsTrue(_foundDonator.Prenume == "TESTUPDATE");
            Assert.IsTrue(_foundDonator.DataDonarePosibila == _newDateTime);
        }

        #endregion

        #region DeleteTest

        [TestMethod]
        public void DeleteDonatorTest()
        {
            var _datetime = new DateTime(2018, 4, 14);
            var _donator = new Donator();
            _donator.Id = 1;
            _donator.IdUtilizator = 2;
            _donator.Nume = "TEST";
            _donator.Prenume = "TEST";
            _donator.DataDonarePosibila = _datetime;

            var _initialSize = _donatorRepository.GetAll().Count();

            try
            {
                _donatorRepository.Add(_donator);
                _donatorRepository.Delete(_donator.Id);
            }
            catch (Exception)
            {
                Assert.Fail();
            }

            Assert.IsTrue(_initialSize == _donatorRepository.GetAll().Count());
        }

        #endregion


    }
}
