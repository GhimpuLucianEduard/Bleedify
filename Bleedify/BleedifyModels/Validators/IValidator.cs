namespace BleedifyModels.Validators
{	
	/// <summary>
	/// Interfata pentru clasele de validare
	/// </summary>
	/// <typeparam name="T">Tipul entitatii de validat</typeparam>
	public interface IValidator<T>
	{	
		/// <summary>
		/// Functia de validare
		/// Arunca ValidationException in cazul in care
		/// entity nu e valid
		/// </summary>
		/// <param name="entity">Entitatea de validat</param>
		void Validate(T entity);
	}
}