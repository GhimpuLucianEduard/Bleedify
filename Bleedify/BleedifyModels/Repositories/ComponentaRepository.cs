using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BleedifyModels.ModelsEF;
using BleedifyModels.Validators;

namespace BleedifyModels.Repositories
{
    public class ComponentaRepository : IRepository<int, Componenta>
    {

        private ComponentaValidator _validator;
        private BleedifyDB _context = ContextGetter.GetContext();

        public ComponentaRepository(ComponentaValidator validator)
        {
            _validator = validator;
        }

        public void Add(Componenta entity)
        {
            _validator.Validate(entity);
            _context.Componentas.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Componentas.Remove(Find(id));
            _context.SaveChanges();
        }

        public Componenta Find(int id)
        {
            return _context.Componentas.Find(id);
        }

        public IEnumerable<Componenta> GetAll()
        {
            return _context.Componentas.ToList();
        }

        public void Update(Componenta entity)
        {
            _validator.Validate(entity);
            var oldEntity = Find(entity.Id);
            _context.Entry(oldEntity).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }
    }
}
