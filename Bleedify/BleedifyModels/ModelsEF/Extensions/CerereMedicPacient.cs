using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BleedifyModels.ModelsEF
{
    partial class CerereMedicPacient : IHasID<int>
    {
        public GrupaDeSange GrupaDeSangeObj
        {
            get { return GrupaDeSange1; }
            set { GrupaDeSange1 = value; }
        }

        public Pacient PacientObj
        {
            get { return Pacient; }
            set { Pacient = value; }
        }

        public Medic MedicObj
        {
            get { return Medic; }
            set { Medic = value; }
        }
    }
}
