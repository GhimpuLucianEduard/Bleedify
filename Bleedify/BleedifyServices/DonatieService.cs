using BleedifyModels.ModelsEF;
using BleedifyModels.Repositories;
using BleedifyModels.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BleedifyServices
{
    public class DonatieService
    {
        private IRepository<int, Donatie> _repository;

        public DonatieService()
        {
            _repository = new DonatieRepository(new DonatieValidator());
        }

        public void Add(Donatie entity)
        {
            _repository.Add(entity);
        }

        public IEnumerable<Donatie> GetAll()
        {
	
            return _repository.GetAll();
        }

	    public void Delete(int id)
	    {
		    _repository.Delete(id);
	    }

	    public IEnumerable<Donatie> GetAllByDonator(int idDonator)
	    {
		    return _repository.GetAll().Where(x => x.IdDonator == idDonator).ToList();
	    }

        public void Update(Donatie donatie)
        {
            _repository.Update(donatie);
        }

        public IEnumerable<Donatie> Filter(string etapaDonare, Nullable<int> grupaDeSange = null)
        {          
            return _repository.GetAll()
                .Where(x => {
                    if (null == grupaDeSange || grupaDeSange.HasValue)
                        return true;
                    return x.GrupaDeSange.HasValue && x.GrupaDeSange.Value == grupaDeSange;
                    })
                .Where(x =>
                {
                    if (string.IsNullOrEmpty(etapaDonare))
                        return true;
                    return x.EtapaDonare.ToLower().Equals(etapaDonare.ToLower());
                });
        }
    }
}
