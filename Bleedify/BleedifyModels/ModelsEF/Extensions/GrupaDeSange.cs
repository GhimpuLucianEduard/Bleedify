using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BleedifyModels.ModelsEF
{
    partial class GrupaDeSange : IHasID<int>
    {
        public override string ToString()
        {
            return Nume;
        }
    }
}
