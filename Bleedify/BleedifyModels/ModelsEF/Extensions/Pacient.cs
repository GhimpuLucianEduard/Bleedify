﻿namespace BleedifyModels.ModelsEF
{
	partial class Pacient : IHasID<int>
	{
		public GrupaDeSange GrupaDeSangeObj
		{
			get { return GrupaDeSange1; }
			set { GrupaDeSange1 = value; }
		}

		public InstitutieAsociata InstitutieAsociataObj
		{
			get { return InstitutieAsociata1; }
			set { InstitutieAsociata1 = value; }
		}

        public override string ToString()
        {
            return Nume + " " + Prenume;
        }
    }
}