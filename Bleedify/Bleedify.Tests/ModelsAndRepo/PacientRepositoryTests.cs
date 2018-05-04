using System;
using System.Linq;
using BleedifyModels.ModelsEF;
using BleedifyModels.Repositories;
using BleedifyModels.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Bleedify.Tests
{
    [TestClass]
    public class PacientRepositoryTests
    {
        #region Initialization and Cleanup

        private static PacientRepository _pacientRepository;


        [TestInitialize]
        public void InitializeTest()
        {
            _pacientRepository = new PacientRepository(new PacientValidator());
        }


        [TestCleanup]
        public void CleanUpTest()
        {
            _pacientRepository.GetAll().ToList().ForEach(x =>
            {
                if (String.Compare(x.Nume, "TEST", StringComparison.Ordinal) == 0 ||
                    String.Compare(x.Nume, "TESTUPDATE", StringComparison.Ordinal) == 0)
                {
                    _pacientRepository.Delete(x.Id);
                }
            });
        }

        #endregion

        #region AddTest

        [TestMethod]
        public void AddPacientTest()
        {
            var _datetime = new DateTime(1998, 2, 20); 
            var _pacient = new Pacient();
            _pacient.Id = 1;
            _pacient.Nume = "TEST";
            _pacient.Prenume = "TEST";
            _pacient.GrupaDeSange = 1;
            _pacient.DataNastere=_datetime;

            var _initialSize = _pacientRepository.GetAll().Count();

            try
            {
                _pacientRepository.Add(_pacient);
            }
            catch (Exception)
            {
                Assert.Fail();
            }

            Assert.IsTrue(_pacientRepository.GetAll().Count() == _initialSize + 1);
        }

        #endregion

        #region FindTest

        [TestMethod]
        public void FindPacientTest()
        {
            var _datetime = new DateTime(1998, 2, 20);
            var _pacient = new Pacient();
            _pacient.Id = 1;
            _pacient.Nume = "TEST";
            _pacient.Prenume = "TEST";
            _pacient.GrupaDeSange = 1;
            _pacient.DataNastere = _datetime;

            Pacient _foundPacient = null;

            try
            {
                _pacientRepository.Add(_pacient);
                _foundPacient = _pacientRepository.Find(_pacient.Id);
            }
            catch (Exception)
            {
                Assert.Fail();
            }

            Assert.IsTrue(_foundPacient != null);
            Assert.IsTrue(_foundPacient.Id == _pacient.Id);
            Assert.IsTrue(_foundPacient.Nume == _pacient.Nume);
            Assert.IsTrue(_foundPacient.Prenume == _pacient.Prenume);
            Assert.IsTrue(_foundPacient.GrupaDeSange == _pacient.GrupaDeSange);
            Assert.IsTrue(_foundPacient.DataNastere == _pacient.DataNastere);
        }

        #endregion

        #region UpdateTest

        [TestMethod]
        public void UpdatePacientTest()
        {
            var _datetime = new DateTime(1998, 2, 20);
            var _pacient = new Pacient();
            _pacient.Id = 1;
            _pacient.Nume = "TEST";
            _pacient.Prenume = "TEST";
            _pacient.GrupaDeSange = 1;
            _pacient.DataNastere = _datetime;
            try
            {
                _pacientRepository.Add(_pacient);
                _pacient.Nume = "TESTUPDATE";
				_pacientRepository.Update(_pacient);

            }
            catch (Exception)
            {
                Assert.Fail();
            }

            var _foundPacient = _pacientRepository.Find(_pacient.Id);
            Assert.IsTrue(_foundPacient.Nume.CompareTo("TESTUPDATE")==0);
        }

        #endregion

        #region DeleteTest

        [TestMethod]
        public void DeletePacientTest()
        {
            var _datetime = new DateTime(1998, 2, 20);
            var _pacient = new Pacient();
            _pacient.Id = 1;
            _pacient.Nume = "TEST";
            _pacient.Prenume = "TEST";
            _pacient.GrupaDeSange = 1;
            _pacient.DataNastere = _datetime;

            var _initialSize = _pacientRepository.GetAll().Count();

            try
            {
                _pacientRepository.Add(_pacient);
                _pacientRepository.Delete(_pacient.Id);
            }
            catch (Exception)
            {
                Assert.Fail();
            }

            Assert.IsTrue(_initialSize == _pacientRepository.GetAll().Count());
        }

        #endregion
    }
}


