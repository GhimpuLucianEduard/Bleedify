namespace BleedifyModels.ModelsEF
{
	partial class InstitutieAsociata : IHasID<int>
	{
		public Adresa AdresaObj
		{
			get { return Adresa1; }
			set { Adresa1 = value; }
		}

		public override string ToString()
		{
			return Nume;
		}
	}
}