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
    public class InstitutieAsociataService
    {
        private IRepository<int, InstitutieAsociata> _repository;

        public InstitutieAsociataService()
        {
            _repository = new InstitutieAsociataRepository(new InstitutieAsociataValidator());
        }

        public IEnumerable<InstitutieAsociata> GetAll()
        {
            return _repository.GetAll();
        }

    }
}
