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
    public class FilterTests
    {
        DonatieService _donatieService = AppService.Instance.DonatieService;
        CerereMedicPacientService _cerereService = AppService.Instance.CerereService;
        Donatie _donatie = new Donatie();
        CerereMedicPacient _cerere = new CerereMedicPacient();

        [TestInitialize]
        public void InitializeTests()
        {            
            _donatie.IdDonator = 204;
            _donatie.DataDonare = DateTime.Now;
            _donatie.EtapaDonare = "<!@FilterTests@!>";
            _donatie.InstitutieAsociata = 3;
            _donatie.GrupaDeSange = 1;

            _cerere.IdPacient = 108;
            _cerere.IdMedic = 159;
            _cerere.GrupaDeSange = 1;
            _cerere.TipComponenta = "Plasma";
            _cerere.Stare = "orice";
            _cerere.DataDepunere = DateTime.Now;
            _cerere.DataServire = DateTime.Now;

            _donatieService.Add(_donatie);
            _cerereService.Add(_cerere);
        }

        [TestMethod]
        public void FilterDonatieTest()
        { 
            var foundCount = _donatieService.Filter("<!@FilterTests@!>", 1).Count();
            var donatie = _donatieService.Filter("<!@FilterTests@!>", 1).OrderByDescending(x => x.Id).First();
            var allCount = _donatieService.GetAll().Count();

            Assert.IsTrue(foundCount >= 1);
            Assert.IsTrue(_donatie.Id == donatie.Id);
            Assert.IsTrue(allCount == _donatieService.Filter(null, null).Count());
            Assert.IsTrue(allCount == _donatieService.Filter(null, new Nullable<int>()).Count());
            Assert.IsTrue(allCount == _donatieService.Filter("", null).Count());
            Assert.IsTrue(allCount == _donatieService.Filter("", new Nullable<int>()).Count());                        
        }

        [TestMethod]
        public void FilterCerereTest()
        {
            var foundCount = _cerereService.Filter(1, "", "").Count();
            var cerere = _cerereService.Filter(1, "", "").OrderByDescending(x => x.Id).First();
            var allCount = _cerereService.GetAll().Count();

            Assert.IsTrue(foundCount >= 1);
            Assert.IsTrue(_cerere.Id == cerere.Id);
            Assert.IsTrue(allCount == _cerereService.Filter(null, null, null).Count());
            Assert.IsTrue(allCount == _cerereService.Filter(null, "", null).Count());
            Assert.IsTrue(allCount == _cerereService.Filter(null, null, "").Count());
            Assert.IsTrue(allCount == _cerereService.Filter(null, "", "").Count());
            Assert.IsTrue(allCount == _cerereService.Filter(new Nullable<int>(), null, null).Count());
            Assert.IsTrue(allCount == _cerereService.Filter(new Nullable<int>(), "", null).Count());
            Assert.IsTrue(allCount == _cerereService.Filter(new Nullable<int>(), "", "").Count());
        }

        [TestCleanup]
        public void CleanupTests()
        {            
            _donatieService.Delete(_donatie.Id);
            _cerereService.Delete(_cerere.Id);
        }

    }
}