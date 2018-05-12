using BleedifyModels.ModelsEF;
using BleedifyModels.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BleedifyModels.Repositories
{
    public class InstitutieAsociataRepository : IRepository<int, InstitutieAsociata>
    {
        private IValidator<InstitutieAsociata> _val;
        private BleedifyDB _context = ContextGetter.GetContext();

        public InstitutieAsociataRepository(InstitutieAsociataValidator val)
        {
            _val = val;
        }

        public void Add(InstitutieAsociata entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public InstitutieAsociata Find(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InstitutieAsociata> GetAll()
        {
            return _context.InstitutieAsociatas.ToList();
        }

        public void Update(InstitutieAsociata entity)
        {
            throw new NotImplementedException();
        }
    }
}
