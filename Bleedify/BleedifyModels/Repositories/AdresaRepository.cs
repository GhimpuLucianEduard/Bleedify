using System.Collections.Generic;
using System.Linq;
using BleedifyModels.ModelsEF;
using BleedifyModels.Validators;

namespace BleedifyModels.Repositories
{
	public class AdresaRepository : IRepository<int, Adresa>
	{
		private BleedifyDB _context = ContextGetter.GetContext();

		public AdresaRepository()
		{
		}

		public void Add(Adresa entity)
		{
			_context.Adresas.Add(entity);
			_context.SaveChanges();
		}

		public void Delete(int id)
		{
			_context.Adresas.Remove(Find(id));
			_context.SaveChanges();
		}

		public Adresa Find(int id)
		{
			return _context.Adresas.Find(id);
		}

		public IEnumerable<Adresa> GetAll()
		{
			return _context.Adresas.ToList();
		}

		public void Update(Adresa entity)
		{
			var oldEntity = Find(entity.Id);
			_context.Entry(oldEntity).CurrentValues.SetValues(entity);
			_context.SaveChanges();
		}
	}
}
