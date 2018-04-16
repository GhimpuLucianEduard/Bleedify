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
    public class MedicRepositoryTests
    {
        #region Initialization and Clean

        private static MedicRepository _medicRepository;

        [ClassInitialize]
        public static void InitializeTest(TestContext context)
        {
            _medicRepository = new MedicRepository(new MedicValidator());
        }

        [ClassCleanup]
        public static void CleanUpTest()
        {
            _medicRepository.GetAll().ToList().ForEach(x =>
           {
               if (String.Compare(x.Nume, "TEST", StringComparison.Ordinal) == 0 ||
                   String.Compare(x.Nume, "TESTUPDATE", StringComparison.Ordinal) == 0)
               {
                   _medicRepository.Delete(x.Id);
               }
           });
        }

        #endregion

        #region AddTest

        [TestMethod]
        public void AddMedicTest()
        {
            var _medic = new Medic();
            _medic.Id = 1;
            _medic.IdUtilizator = 1;
            _medic.Nume = "TEST";
            _medic.Prenume = "TEST";
            _medic.IdentificatorMedic = "TEST";
            var _initialSize = _medicRepository.GetAll().Count();
            try
            {
                _medicRepository.Add(_medic);
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
            Assert.IsTrue(_medicRepository.GetAll().Count() == _initialSize + 1);
        }

        #endregion

        #region FindTest

        [TestMethod]
        public void FindMedicTest()
        {
            var _medic = new Medic();
            _medic.Id = 1;
            _medic.IdUtilizator = 2;
            _medic.Nume = "TEST";
            _medic.Prenume = "TEST";
            _medic.IdentificatorMedic = "TEST";
            Medic _foundMedic = null;
            try
            {
                _medicRepository.Add(_medic);
                _foundMedic = _medicRepository.Find(_medic.Id);
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
            Assert.IsTrue(_foundMedic != null);
            Assert.IsTrue(_foundMedic.Id == _medic.Id);
            Assert.IsTrue(_foundMedic.IdUtilizator == _medic.IdUtilizator);
            Assert.IsTrue(String.Compare(_foundMedic.Nume,_medic.Nume) == 0);
            Assert.IsTrue(String.Compare(_foundMedic.Prenume, _medic.Prenume) == 0);
            Assert.IsTrue(String.Compare(_foundMedic.IdentificatorMedic, _medic.IdentificatorMedic) == 0);
        }

        #endregion

        #region UpdateTest

        [TestMethod]
        public void UpdateMedicTest()
        {
            var _medic = new Medic();
            _medic.Id = 1;
            _medic.IdUtilizator = 1;
            _medic.Nume = "TEST";
            _medic.Prenume = "TEST";
            _medic.IdentificatorMedic = "TEST";

            try
            {
                _medicRepository.Add(_medic);
                _medic.Nume = "TESTUPDATE";
                _medic.Prenume = "TESTUPDATE";
                _medic.IdentificatorMedic = "TESTUPDATE";
                _medicRepository.Update(_medic);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
            var _foundMedic = _medicRepository.Find(_medic.Id);
            Assert.IsTrue(String.Compare(_foundMedic.Nume,"TESTUPDATE") == 0);
            Assert.IsTrue(String.Compare(_foundMedic.Prenume, "TESTUPDATE") == 0);
            Assert.IsTrue(String.Compare(_foundMedic.IdentificatorMedic, "TESTUPDATE") == 0);
        }

        #endregion

        #region DeleteTest

        [TestMethod]
        public void DeleteMedicTest()
        {
            var _medic = new Medic();
            _medic.Id = 1;
            _medic.IdUtilizator = 1;
            _medic.Nume = "TEST";
            _medic.Prenume = "TEST";
            _medic.IdentificatorMedic = "TEST";
            var _initialSize = _medicRepository.GetAll().Count();

            try
            {
                _medicRepository.Add(_medic);
                _medicRepository.Delete(_medic.Id);
            }
            catch (Exception)
            {
                Assert.Fail();
            }

            Assert.IsTrue(_initialSize == _medicRepository.GetAll().Count());
        }

        #endregion
    }
}
