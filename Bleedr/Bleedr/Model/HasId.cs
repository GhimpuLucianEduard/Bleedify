namespace Bleedr.Model
{
	/// <summary>
	/// Interfata pentru clasele cu id
	/// </summary>
	/// <typeparam name="T">Tipul id-ului</typeparam>
	public interface IHasId<T>
	{
		T Id { get; set; }
	}
}