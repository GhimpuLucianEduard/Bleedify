using BleedifyModels.Validators;
using BleedifyModels.ModelsEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BleedifyModels.Repositories
{
    public class MedicRepository : IRepository<int,Medic>
    {
        private MedicValidator _validator;
        private BleedifyDB _context = ContextGetter.GetContext();

        public MedicRepository(MedicValidator validator)
        {
            _validator = validator;
        }

        public void Add(Medic entity)
        {
            _validator.Validate(entity);
            _context.Medics.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Medic entity)
        {
            _validator.Validate(entity);
            var oldEntity = Find(entity.Id);
            _context.Entry(oldEntity).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Medics.Remove(Find(id));
            _context.SaveChanges();
        }

        public Medic Find(int id)
        {
            return _context.Medics.Find(id);
        }

        public IEnumerable<Medic> GetAll()
        {
            return _context.Medics.ToList();
        }
    }
}
