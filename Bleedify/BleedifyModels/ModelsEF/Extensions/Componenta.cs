using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BleedifyModels.ModelsEF
{
    partial class Componenta : IHasID<int>
    {
        public GrupaDeSange GrupaDeSangeObj
        {
            get { return GrupaDeSange1; }
            set { GrupaDeSange1 = value; }
        }

        public Donatie DonatieObj
        {
            get { return Donatie; }
            set { Donatie = value; }
        }

        public Pacient PacientObj
        {
            get { return Pacient; }
            set { Pacient = value; }
        }

        public InstitutieAsociata InstitutieAsociataObj
        {
            get { return InstitutieAsociata1; }
            set { InstitutieAsociata1 = value; }
        }
    }
}
