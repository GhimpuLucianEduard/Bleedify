using System.Collections.Generic;
using BleedifyModels.ModelsEF;

namespace BleedifyModels.Repositories
{	
	public interface IRepository<TID,TE> where TE : IHasID<TID>
	{
		void Add(TE entity);
		void Update(TE entity);
		void Delete(TID id);
		TE Find(TID id);
		IEnumerable<TE> GetAll();
	}
}