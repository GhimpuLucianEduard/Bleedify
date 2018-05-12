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

        public void Update(Donatie donatie)
        {
            _repository.Update(donatie);
        }
    }
}
