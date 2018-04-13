using System.Collections.Generic;
using System.Linq;
using BleedifyModels.ModelsEF;
using BleedifyModels.Validators;

namespace BleedifyModels.Repositories
{
	public class UtilizatorRepository : IRepository<int, Utilizator>
	{
		private UtilizatorValidator _validator;
		private BleedifyDB _context = ContextGetter.GetContext();

		public UtilizatorRepository(UtilizatorValidator validator)
		{
			_validator = validator;
		}

		public void Add(Utilizator entity)
		{
			_validator.Validate(entity);
			_context.Utilizators.Add(entity);
			_context.SaveChanges();
		}

		public void Update(Utilizator entity)
		{	
			_validator.Validate(entity);
			var oldEntity = Find(entity.Id);
			_context.Entry(oldEntity).CurrentValues.SetValues(entity);
			_context.SaveChanges();
		}

		public void Delete(int id)
		{
			_context.Utilizators.Remove(Find(id));
			_context.SaveChanges();
		}

		public Utilizator Find(int id)
		{
			return _context.Utilizators.Find(id);
		}

		public IEnumerable<Utilizator> GetAll()
		{
			return _context.Utilizators.ToList();
		}
	}
}