using System.Collections.Generic;
using System.Linq;
using BleedifyModels.ModelsEF;
using BleedifyModels.Repositories;
using BleedifyModels.Validators;

namespace BleedifyServices
{
    public class MedicService
    {
        private IRepository<int, Medic> _repository;

        public MedicService()
        {
            _repository = new MedicRepository(new MedicValidator());
        }

        public void Add(Medic entity)
        {
			var utilizator = new Utilizator();
	        utilizator.TipUtilizator = entity.TipUtilizator;
	        utilizator.InstitutieAsociata = entity.InstitutieAsociata;
	        utilizator.UserName = entity.UserName;
	        utilizator.Password = entity.Password;
			AppService.Instance.UtilizatorService.Add(utilizator);
	        entity.IdUtilizator = utilizator.Id;
			_repository.Add(entity);
        }

        public Medic Find(int id)
        {
            return _repository.Find(id);
        }

        public IEnumerable<Medic> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(Medic entity)
        {
            _repository.Update(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

	    public Medic FindByIdUtilizator(int idUtilizator)
	    {
		    return _repository.GetAll().First(x => x.IdUtilizator == idUtilizator);
	    }
    }
}
