namespace BleedifyModels.ModelsEF
{
    partial class Donatie : IHasID<int>
    {        
        public Donator DonatorObj { get; set; }
    }
}