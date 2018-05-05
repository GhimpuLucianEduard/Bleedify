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
    public class PersonalService
    {
        private IRepository<int, Personal> _repository;

        public PersonalService()
        {
            _repository = new PersonalRepository(new PersonalValidator());
        }
        
        public void Register(Personal personal)
        {
            _repository.Add(personal);
        }
    }
}
