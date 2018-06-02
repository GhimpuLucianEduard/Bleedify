using System.Collections.Generic;
using System.Linq;
using BleedifyModels.ModelsEF;
using BleedifyModels.Repositories;
using BleedifyModels.Validators;

namespace BleedifyServices
{
	public class AdresaService
	{
		private IRepository<int, Adresa> _repository;

		public AdresaService()
		{
			_repository = new AdresaRepository();
		}

		public void Add(Adresa entity)
		{
			_repository.Add(entity);
		}

		public Adresa Find(int id)
		{
			return _repository.Find(id);
		}

		public IEnumerable<Adresa> GetAll()
		{
			return _repository.GetAll();
		}

		public void Update(Adresa entity)
		{
			_repository.Update(entity);
		}

		public void Delete(int id)
		{
			_repository.Delete(id);
		}
	}
}