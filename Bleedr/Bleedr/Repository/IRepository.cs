using System.Collections.Generic;
using Bleedr.Model;

namespace Bleedr.Repository
{
	/// <summary>
	/// Interfata pentru operatii CRUD
	/// </summary>
	/// <typeparam name="TE">Tipul Clasei, implementeaza HasId</typeparam>
	/// <typeparam name="TId">Tipul Id-ului</typeparam>
	public interface IRepository<TId, TE> where TE : IHasId<TId>
	{
		/// <summary>
		/// Funtie care de cautare
		/// </summary>
		/// <param name="id">Id-ul entitatii de cautat</param>
		/// <returns>Entitatea gasita sau null</returns>
		TE Find(TId id);

		/// <summary>
		/// Functie care returneaza o colectie cu toate obiectele
		/// </summary>
		/// <returns>Colectie cu toate obiectele din repository</returns>
		IEnumerable<TE> FindAll();

		/// <summary>
		/// Functie pentru adaugarea unui nou obiect
		/// </summary>
		/// <param name="entity">Noua entitate</param>
		void Add(TE entity);

		/// <summary>
		/// Functie pentru stergerea unui obiect
		/// </summary>
		/// <param name="id">Id-ul obiectului de sters</param>
		void Delete(TId id);

		/// <summary>
		/// Functie pentru modificarea unui obiect 
		/// </summary>
		/// <param name="entity">Noul obiect</param>
		void Update(TE entity);

	}
}