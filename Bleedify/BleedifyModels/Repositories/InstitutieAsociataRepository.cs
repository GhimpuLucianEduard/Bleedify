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
	        _val.Validate(entity);
	        _context.InstitutieAsociatas.Add(entity);
	        _context.SaveChanges();
		}

        public void Delete(int id)
        {
			_context.InstitutieAsociatas.Remove(Find(id));
			_context.SaveChanges();
		}

        public InstitutieAsociata Find(int id)
        {
			return _context.InstitutieAsociatas.Find(id);
		}

        public IEnumerable<InstitutieAsociata> GetAll()
        {
            return _context.InstitutieAsociatas.ToList();
        }

        public void Update(InstitutieAsociata entity)
        {
			_val.Validate(entity);
	        var oldEntity = Find(entity.Id);
	        _context.Entry(oldEntity).CurrentValues.SetValues(entity);
	        _context.SaveChanges();
		}
	}
}
