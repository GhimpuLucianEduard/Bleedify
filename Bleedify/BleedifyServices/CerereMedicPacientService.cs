using BleedifyModels.ModelsEF;
using BleedifyModels.Repositories;
using BleedifyModels.Validators;
using System;
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

        public IEnumerable<CerereMedicPacient> GetAll()
        {            
            return _repository.GetAll();          
        }

        public void Update(CerereMedicPacient entity)
        {
            _repository.Update(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<CerereMedicPacient> Filter(int? grupaDeSange, string tipComponenta, string stare)
        {
            var something = _repository.GetAll();
            return _repository.GetAll()
                .Where(x =>
                {
                    if (null == grupaDeSange || !grupaDeSange.HasValue)
                        return true;
                    return x.GrupaDeSange.HasValue && x.GrupaDeSange.Value == grupaDeSange.Value;
                })
                .Where(x =>
                {
                    if (string.IsNullOrEmpty(tipComponenta))
                        return true;
                    return x.TipComponenta.ToLower().Equals(tipComponenta.ToLower());
                })
                .Where(x =>
                {
                    if (string.IsNullOrEmpty(stare))
                        return true;
                    return x.Stare.ToLower().Equals(stare.ToLower());
                })
                .ToList();
        }
    }
}
