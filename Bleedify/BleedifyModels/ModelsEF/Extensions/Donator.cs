using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BleedifyModels.ModelsEF
{
    partial class Donator : Utilizator
    {
        public Utilizator UtilizatorObj
        {
            get { return Utilizator; }
            set { Utilizator = value; }
        }

        public GrupaDeSange GrupaDeSangeObj
        {
            get { return GrupaDeSange1; }
            set { GrupaDeSange1 = value; }
        }
    }
}
