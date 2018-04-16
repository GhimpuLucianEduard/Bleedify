using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using BleedifyModels.ModelsEF;
using BleedifyModels.Repositories;
using BleedifyModels.Validators;
using BleedifyModels.Enums;

namespace Bleedify.Tests
{
    class CerereMedicPacientValidatorTests
    {
        #region Private Testing fields

        private static CerereMedicPacientValidator _cerereMedicPacientValidator;

        #endregion

        #region ValidatorTest

        [TestMethod]
        public void CerereValidatorTest()
        {
            try
            {
                var cerereTest = new CerereMedicPacient
                {
                    Id = 1,
                    IdMedic = 2,
                    IdPacient = 3,
                    TipComponenta = "",
                    Stare = "TEST"
                };

                _cerereMedicPacientValidator.Validate(cerereTest);

                Assert.Fail();
            }
            catch (ValidationException)
            {
                // Test passed
            }

            try
            {
                var cerereTest = new CerereMedicPacient
                {
                    Id = 1,
                    IdMedic = 2,
                    IdPacient = 3,
                    TipComponenta = TipComponenta.GlobuleRosii.ToString(),
                    Stare = ""
                };

                _cerereMedicPacientValidator.Validate(cerereTest);

                Assert.Fail();
            }
            catch (ValidationException)
            {
                // Test passed
            }

            try
            {
                var cerereTest = new CerereMedicPacient
                {
                    Id = 1,
                    IdMedic = 2,
                    IdPacient = 3,
                    TipComponenta = "",
                    Stare = ""
                };

                _cerereMedicPacientValidator.Validate(cerereTest);

                Assert.Fail();
            }
            catch (ValidationException)
            {
                // Test passed
            }

            try
            {
                var cerereTest = new CerereMedicPacient
                {
                    Id = 1,
                    IdMedic = 2,
                    IdPacient = 3,
                    TipComponenta = TipComponenta.GlobuleRosii.ToString(),
                    Stare = "TEST"
                };

                _cerereMedicPacientValidator.Validate(cerereTest);

                // Test passed
            }
            catch (ValidationException)
            {
                Assert.Fail();
            }
        }

        #endregion

    }
}
