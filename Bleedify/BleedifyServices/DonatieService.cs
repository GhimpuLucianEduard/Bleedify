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

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Donatie Find(int id)
        {
            return _repository.Find(id);
        }

        public IEnumerable<Donatie> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(Donatie entity)
        {
            _repository.Update(entity);
        }
    }
}
