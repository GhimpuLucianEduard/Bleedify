using BleedifyModels.ModelsEF;
using BleedifyModels.Repositories;
using BleedifyModels.Validators;
using BleedifyServices;
using BleedifyServices.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Bleedify.Tests.Services
{
    [TestClass]
    public class BatchAdd
    {
        DonatorService _donatorService = AppService.Instance.DonatorService;
        AnuntDonatorService _anuntDonatorService = AppService.Instance.AnuntDonatorService;
        
        [TestInitialize]
        public void InitializeTests()
        {
        
        }

        [TestMethod]
        public void BatchAddTest()
        {
            int countAnunturi = _anuntDonatorService.GetAll().Count();
            int countDonatori = _donatorService.Filter(4, null, true).Count();

            _anuntDonatorService.BatchAdd(4, null, null);

            Assert.IsTrue(countAnunturi + countDonatori == _anuntDonatorService.GetAll().Count());
        }
        

        [TestCleanup]
        public void CleanupTests()
        {
        
        }

    }
}