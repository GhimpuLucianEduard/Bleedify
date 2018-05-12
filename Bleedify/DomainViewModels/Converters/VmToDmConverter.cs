using BleedifyModels.ModelsEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainViewModels.Converters
{
    public static class VmToDmConverter
    {
        public static Donatie Convert(DonatieViewModel donatieViewModel)
        {
            return new Donatie()
            {
                Id = donatieViewModel.Id,
                IdDonator = donatieViewModel.DonatorId,
                DataDonare = donatieViewModel.DataDonare,
                EtapaDonare = donatieViewModel.EtapaDonare,
                InstitutieAsociata = donatieViewModel.InstitutieAsociataId,
                GrupaDeSange = donatieViewModel.GrupaDeSangeId,
                MotivRefuz = donatieViewModel.MotivRefuz
            };
        }
    }
}
