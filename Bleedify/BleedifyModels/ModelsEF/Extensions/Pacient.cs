namespace BleedifyModels.ModelsEF
{
	partial class Pacient : Utilizator
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
	}
}