using System.Runtime.CompilerServices;

namespace BleedifyModels.ModelsEF
{
    partial class Donatie : IHasID<int>
    {
	    public Donator DonatorObj
	    {
		    get { return Donator; }
		    set { Donator = value; }
	    }

	    public InstitutieAsociata InstitutieAsociataObj
	    {
		    get { return InstitutieAsociata1; }
		    set { InstitutieAsociata1 = value; }
	    }

	    public GrupaDeSange GrupaDeSangeObj
	    {
		    get { return GrupaDeSange1; }
		    set { GrupaDeSange1 = value; }
	    }

	}
}