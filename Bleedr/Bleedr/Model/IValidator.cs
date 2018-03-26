namespace Bleedr.Model
{
	/// <summary>
	/// Interfata pentru validatoare
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IValidator<T>
	{
		/// <summary>
		/// Functia de validare
		/// </summary>
		/// <param name="elem">Obiectul de validad</param>
		void Validate(T elem);
	}
}