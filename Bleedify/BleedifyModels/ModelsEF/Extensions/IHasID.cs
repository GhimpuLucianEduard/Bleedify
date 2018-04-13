namespace BleedifyModels.ModelsEF
{
	public interface IHasID<T>
	{
		T Id { get; set; }
	}
}