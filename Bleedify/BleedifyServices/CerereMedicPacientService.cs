using BleedifyModels.ModelsEF;
using BleedifyModels.Repositories;
using BleedifyModels.Validators;
using System.Collections.Generic;
using System.Linq;

namespace BleedifyServices
{
    public class CerereMedicPacientService
    {
        private IRepository<int, CerereMedicPacient> _repository;

        public CerereMedicPacientService()
        {
            _repository = new CerereMedicPacientRepository(new CerereMedicPacientValidator());
        }

        public void Add(CerereMedicPacient entity)
        {
            _repository.Add(entity);
        }

        public CerereMedicPacient Find(int id)
        {
            return _repository.Find(id);
        }

        public IEnumerable<CerereMedicPacient> GetAll(string stare)
        {
            if (null == stare)
            {
                return _repository.GetAll();
            }

            var list = _repository.GetAll();
            return list.Where(x => x.Stare.CompareTo(stare) == 0).ToList(); 
        }

        public void Update(CerereMedicPacient entity)
        {
            _repository.Update(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
