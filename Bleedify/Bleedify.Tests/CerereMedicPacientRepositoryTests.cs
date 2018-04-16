using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using BleedifyModels.ModelsEF;
using BleedifyModels.Repositories;
using BleedifyModels.Enums;
using BleedifyModels.Validators;

namespace Bleedify.Tests
{
    [TestClass]
    public class CerereMedicPacientRepositoryTests
    {
        #region Private Testing fields

        private static CerereMedicPacientRepository _cerereMedicPacientRepository;

        #endregion

        #region Initialize and Cleanup

        [ClassInitialize]
        public static void InitializeTest(TestContext context)
        {
            _cerereMedicPacientRepository = new CerereMedicPacientRepository(new CerereMedicPacientValidator());
        }

        [ClassCleanup]
        public static void CleanUpTest()
        {
            _cerereMedicPacientRepository.GetAll().ToList().ForEach(x =>
            {
                if (String.Compare(x.Stare, "TEST", StringComparison.Ordinal) == 0)
                {
                    _cerereMedicPacientRepository.Delete(x.Id);
                }
            });
        }

        #endregion

        #region AddTest

        [TestMethod]
        public void AddCerereTest()
        {
            var size = _cerereMedicPacientRepository.GetAll().Count();

            try
            {
                var cerereTest1 = new CerereMedicPacient
                {
                    Id = 1,
                    IdMedic = 2,
                    IdPacient = 3,
                    TipComponenta = TipComponenta.GlobuleRosii.ToString(),
                    Stare = "TEST"
                };

                var cerereTest2 = new CerereMedicPacient
                {
                    Id = 2,
                    IdMedic = 2,
                    IdPacient = 4,
                    TipComponenta = TipComponenta.Plasma.ToString(),
                    Stare = "TEST"
                };

                _cerereMedicPacientRepository.Add(cerereTest1);
                _cerereMedicPacientRepository.Add(cerereTest2);

            }
            catch (Exception)
            {
                Assert.Fail();
            }

            var size2 = _cerereMedicPacientRepository.GetAll().Count();

            Assert.IsTrue(size2 == size + 2);

            try
            {
                var cerereTest1 = new CerereMedicPacient
                {
                    Id = 1,
                    IdMedic = 2,
                    IdPacient = 3,
                    TipComponenta = TipComponenta.GlobuleRosii.ToString(),
                    Stare = "TEST"
                };

                _cerereMedicPacientRepository.Add(cerereTest1);

                Assert.Fail();
            }
            catch (Exception)
            {
                // Test Passed
            }
        }

        #endregion

        #region DeleteTest

        [TestMethod]
        public void DeleteCerereTest()
        {
            var size = _cerereMedicPacientRepository.GetAll().Count();
            try
            {
                var cerereTest1 = new CerereMedicPacient
                {
                    Id = 4,
                    IdMedic = 2,
                    IdPacient = 3,
                    TipComponenta = TipComponenta.GlobuleRosii.ToString(),
                    Stare = "TEST"
                };

                var cerereTest2 = new CerereMedicPacient
                {
                    Id = 5,
                    IdMedic = 2,
                    IdPacient = 4,
                    TipComponenta = TipComponenta.Plasma.ToString(),
                    Stare = "TEST"
                };

                _cerereMedicPacientRepository.Add(cerereTest2);
                _cerereMedicPacientRepository.Add(cerereTest1);

                _cerereMedicPacientRepository.Delete(cerereTest2.Id);
                _cerereMedicPacientRepository.Delete(cerereTest1.Id);

            }
            catch (Exception)
            {
                Assert.Fail();
            }

            var size2 = _cerereMedicPacientRepository.GetAll().Count();

            Assert.IsTrue(size2 == size);

            try
            {
                var cerereTest1 = new CerereMedicPacient
                {
                    Id = 10,
                    IdMedic = 2,
                    IdPacient = 3,
                    TipComponenta = TipComponenta.GlobuleRosii.ToString(),
                    Stare = "TEST"
                };

                _cerereMedicPacientRepository.Delete(cerereTest1.Id);

                Assert.Fail();
            }
            catch (Exception)
            {
                // Test passed
            }

        }

        #endregion

        #region FindTest

        [TestMethod]
        public void FindCerereTest()
        {
            try
            {
                var cerereTest1 = new CerereMedicPacient
                {
                    Id = 12,
                    IdMedic = 2,
                    IdPacient = 3,
                    TipComponenta = TipComponenta.GlobuleRosii.ToString(),
                    Stare = "TEST"
                };

                _cerereMedicPacientRepository.Add(cerereTest1);

                var cerereFind = _cerereMedicPacientRepository.Find(1);

                Assert.IsTrue(cerereFind.Id == cerereTest1.Id);
                Assert.IsTrue(cerereFind.IdMedic == cerereTest1.IdMedic);
                Assert.IsTrue(cerereFind.IdPacient == cerereTest1.IdPacient);
                Assert.IsTrue(String.Compare(cerereFind.TipComponenta, cerereTest1.TipComponenta, StringComparison.Ordinal) == 0);

            }
            catch (Exception)
            {
                Assert.Fail();
            }

        }

        #endregion

        #region UpdateTest

        [TestMethod]
        public void UpdateCerereTest()
        {
            try
            {
                var cerereUpdate = new CerereMedicPacient
                {
                    Id = 15,
                    IdMedic = 2,
                    IdPacient = 3,
                    TipComponenta = TipComponenta.Trombocite.ToString(),
                    Stare = "TEST"
                };

                _cerereMedicPacientRepository.Add(cerereUpdate);
                
                Assert.IsTrue(cerereUpdate.Id == 15);
                Assert.IsTrue(cerereUpdate.IdMedic == 2);
                Assert.IsTrue(cerereUpdate.IdPacient == 3);
                Assert.IsTrue(String.Compare(cerereUpdate.TipComponenta, TipComponenta.GlobuleRosii.ToString(), StringComparison.Ordinal) == 0);

                var cerereUpdate1 = new CerereMedicPacient
                {
                    Id = 15,
                    IdMedic = 22,
                    IdPacient = 33,
                    TipComponenta = TipComponenta.Trombocite.ToString(),
                    Stare = "TEST"
                };

                _cerereMedicPacientRepository.Update(cerereUpdate1);

                cerereUpdate = _cerereMedicPacientRepository.Find(1);

                Assert.IsTrue(cerereUpdate.Id == 15);
                Assert.IsTrue(cerereUpdate.IdMedic == 22);
                Assert.IsTrue(cerereUpdate.IdPacient == 33);
                Assert.IsTrue(String.Compare(cerereUpdate.TipComponenta, TipComponenta.Trombocite.ToString(), StringComparison.Ordinal) == 0);

            }
            catch (Exception)
            {
                Assert.Fail();
            }

        }

        #endregion
    }
}
