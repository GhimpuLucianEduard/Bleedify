using System;
using System.Linq;
using BleedifyModels.ModelsEF;
using BleedifyModels.Repositories;
using BleedifyModels.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bleedify.Tests
{
    [TestClass]
    public class PersonalRepositoryTests
    {
        #region Initialization and Cleanup

        private static PersonalRepository _personalRepository;


        [TestInitialize]
        public void InitializeTest()
        {
            _personalRepository = new PersonalRepository(new PersonalValidator());
        }


        [TestCleanup]
        public void CleanUpTest()
        {
            _personalRepository.GetAll().ToList().ForEach(x =>
            {
                if (x.Nume.CompareTo("TEST")==0)
                {
                    _personalRepository.Delete(x.Id);
                }
            });
        }

        #endregion

        #region AddTest

        [TestMethod]
        public void AddPersonalTest()
        {
            var _personal = new Personal();
            _personal.Id = 1;
            _personal.IdUtilizator = 1;
            _personal.Nume = "TEST";
            _personal.Prenume = "TEST";

            var _initialSize = _personalRepository.GetAll().Count();

            try
            {
                _personalRepository.Add(_personal);
            }
            catch (Exception)
            {
                Assert.Fail();
            }

            Assert.IsTrue(_personalRepository.GetAll().Count() == _initialSize + 1);
        }

        #endregion

        #region FindTest

        [TestMethod]
        public void FindPersonalTest()
        {
            var _personal = new Personal();
            _personal.Id = 1;
            _personal.IdUtilizator = 1;
            _personal.Nume = "TEST";
            _personal.Prenume = "TEST";

            Personal _foundPersonal = null;

            try
            {
                _personalRepository.Add(_personal);
                _foundPersonal = _personalRepository.Find(_personal.Id);
            }
            catch (Exception)
            {
                Assert.Fail();
            }

            Assert.IsTrue(_foundPersonal != null);
            Assert.IsTrue(_foundPersonal.Id == _personal.Id);
            Assert.IsTrue(_foundPersonal.IdUtilizator == _personal.IdUtilizator);
            Assert.IsTrue(_foundPersonal.Nume == _personal.Nume);
            Assert.IsTrue(_foundPersonal.Prenume == _personal.Prenume);
        }

        #endregion

        #region UpdateTest

        [TestMethod]
        public void UpdatePersonalTest()
        {
            var _personal = new Personal();
            _personal.Id = 1;
            _personal.IdUtilizator = 1;
            _personal.Nume = "TEST";
            _personal.Prenume = "TEST";

            try
            {
                _personalRepository.Add(_personal);
                _personal.IdUtilizator = 1;
                _personal.Nume = "TESTUPDATE";
                _personal.Prenume = "TESTUPDATE";
                _personalRepository.Update(_personal);
            }
            catch (Exception)
            {
                Assert.Fail();
            }

            var _foundPersonal = _personalRepository.Find(_personal.Id);
            Assert.IsTrue(_foundPersonal.Nume == "TESTUPDATE");
            Assert.IsTrue(_foundPersonal.Prenume == "TESTUPDATE");
        }

        #endregion

        #region DeleteTest

        [TestMethod]
        public void DeletePersonalTest()
        {
            var _personal = new Personal();
            _personal.Id = 1;
            _personal.IdUtilizator = 1;
            _personal.Nume = "TEST";
            _personal.Prenume = "TEST";

            var _initialSize = _personalRepository.GetAll().Count();

            try
            {
                _personalRepository.Add(_personal);
                _personalRepository.Delete(_personal.Id);
            }
            catch (Exception)
            {
                Assert.Fail();
            }

            Assert.IsTrue(_initialSize == _personalRepository.GetAll().Count());
        }

        #endregion
    }
}
