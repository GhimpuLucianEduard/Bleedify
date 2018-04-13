namespace BleedifyModels.ModelsEF
{
	partial class Utilizator : IHasID<int>
	{
		public InstitutieAsociata IntInstitutieAsociataObj
		{
			get { return InstitutieAsociata1; }
			set { InstitutieAsociata1 = value; }
		}
	}
}