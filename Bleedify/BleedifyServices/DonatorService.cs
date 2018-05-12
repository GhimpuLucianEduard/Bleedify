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
        public Donator getDonatorByName(string nume)
        {
            foreach(var donator in _repository.GetAll())
            {
                if (donator.Nume.Equals(nume))
                {
                    return donator;
                }
            }
            throw new ServiceException("A donator with that name doesn't exist");
        }
    }
}
