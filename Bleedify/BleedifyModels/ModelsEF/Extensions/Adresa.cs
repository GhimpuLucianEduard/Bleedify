namespace BleedifyModels.ModelsEF
{
	partial class Adresa : IHasID<int>
	{
		public override string ToString()
		{
			return Oras + " " + Strada + " " + Numarul + " " + CodPostal;
		}
	}
}