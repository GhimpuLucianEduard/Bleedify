using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using BleedifyModels.ModelsEF;
using BleedifyModels.Repositories;
using BleedifyModels.Enums;
using BleedifyModels.Validators;
using System.Data.Entity.Validation;

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

            var cerereTest1 = new CerereMedicPacient
            {
                TipComponenta = TipComponenta.Trombocite.ToString(),
                DataDepunere = DateTime.Now,
                DataServire = DateTime.Now,
                Stare = "TEST"
            };

            var cerereTest2 = new CerereMedicPacient
            {
                TipComponenta = TipComponenta.Plasma.ToString(),
                DataDepunere = DateTime.Now,
                DataServire = DateTime.Now,
                Stare = "TEST"
            };

            try
            { 
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
                    TipComponenta = TipComponenta.Trombocite.ToString(),
                    DataDepunere = DateTime.Now,
                    DataServire = DateTime.Now,
                    Stare = "TEST"
                };

                var cerereTest2 = new CerereMedicPacient
                {
                    TipComponenta = TipComponenta.Plasma.ToString(),
                    DataDepunere = DateTime.Now,
                    DataServire = DateTime.Now,
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
                    TipComponenta = TipComponenta.Trombocite.ToString(),
                    DataDepunere = DateTime.Now,
                    DataServire = DateTime.Now,
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
                    TipComponenta = TipComponenta.Trombocite.ToString(),
                    DataDepunere = DateTime.Now,
                    DataServire = DateTime.Now,
                    Stare = "TEST"
                };

                _cerereMedicPacientRepository.Add(cerereTest1);

                var cerereFind = _cerereMedicPacientRepository.Find(cerereTest1.Id);

                Assert.IsTrue(cerereFind.Id == cerereTest1.Id);
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
                    TipComponenta = TipComponenta.Trombocite.ToString(),
                    DataDepunere = DateTime.Now,
                    DataServire = DateTime.Now,
                    Stare = "TEST"
                };

                _cerereMedicPacientRepository.Add(cerereUpdate);
                

                Assert.IsTrue(String.Compare(cerereUpdate.TipComponenta, TipComponenta.Trombocite.ToString(), StringComparison.Ordinal) == 0);

                cerereUpdate.TipComponenta = TipComponenta.Plasma.ToString();

                _cerereMedicPacientRepository.Update(cerereUpdate);

                cerereUpdate = _cerereMedicPacientRepository.Find(cerereUpdate.Id);

                Assert.IsTrue(String.Compare(cerereUpdate.TipComponenta, TipComponenta.Plasma.ToString(), StringComparison.Ordinal) == 0);

            }
            catch (Exception)
            {
                Assert.Fail();
            }

        }

        #endregion
    }
}
