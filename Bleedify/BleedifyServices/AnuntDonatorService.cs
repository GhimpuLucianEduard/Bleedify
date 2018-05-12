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
    public class AnuntDonatorService
    {
        private IRepository<int, AnuntDonator> _repository;

        public AnuntDonatorService()
        {
            _repository = new AnuntDonatorRepository(new AnuntDonatorValidator());
        }

        public IEnumerable<AnuntDonator> GetAll()
        {
            return _repository.GetAll();
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public void Add(AnuntDonator entity)
        {
            _repository.Add(entity);
        }

        public IEnumerable<AnuntDonator> Filter(string tipAnunt)
        {
            return _repository.GetAll()
                .Where(x =>
                {
                    if (string.IsNullOrEmpty(tipAnunt))
                        return true;
                    return x.TipAnuntDonator.ToLower().Equals(tipAnunt.ToLower());
                })
                .ToList();
        }
    }
}
