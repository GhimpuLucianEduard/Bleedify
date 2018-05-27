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
    public class DonatorService
    {
        private IRepository<int, Donator> _repository;

        public DonatorService()
        {
            _repository = new DonatorRepository(new DonatorValidator());
        }

        public IEnumerable<Donator> GetAll()
        {
            return _repository.GetAll();
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public void Add(Donator entity)
        {
            _repository.Add(entity);
        }

        public Donator getDonatorByName(string nume, string prenume)
        {
            foreach(var donator in _repository.GetAll())
            {
                if (donator.Nume.Equals(nume) && donator.Prenume.Equals(prenume))
                {
                    return donator;
                }
            }
            throw new ServiceException("A donator with that name doesn't exist");
        }
    
        public IEnumerable<Donator> Filter(int? grupaDeSange, int? institutie, bool canDonate = false)
        {
            return _repository.GetAll()
                .Where(x =>
                {
                    if (null == grupaDeSange || !grupaDeSange.HasValue)
                        return true;
                    return x.GrupaDeSange.HasValue && x.GrupaDeSange == grupaDeSange;
                })                
                .Where(x =>
                {
                    if (null == institutie || !institutie.HasValue)
                        return true;
                    return x.InstitutieAsociata.HasValue && x.InstitutieAsociata.Value == institutie;
                })
                //.Where(x =>
                //{
                //    if (!canDonate)
                //        return true;
                //    return null != x.DataDonarePosibila && x.DataDonarePosibila <= DateTime.Now;
                //})
                .ToList();
        }

	    public Utilizator FindByIdUtilizator(int idUtilizator)
	    {
		    return _repository.GetAll().First(x => x.IdUtilizator == idUtilizator);
		}
    }
}
