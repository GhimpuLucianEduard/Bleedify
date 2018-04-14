using BleedifyModels.ModelsEF;
using BleedifyModels.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BleedifyModels.Repositories
{
    public class DonatorRepository : IRepository<int, Donator>
    {
        private DonatorValidator _validator;
        private BleedifyDB _context = ContextGetter.GetContext();

        public DonatorRepository(DonatorValidator validator)
        {
            _validator = validator;
        }

        public void Add(Donator entity)
        {
            _validator.Validate(entity);
            _context.Donators.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Donators.Remove(Find(id));
            _context.SaveChanges();
        }

        public Donator Find(int id)
        {
            return _context.Donators.Find(id);
        }

        public IEnumerable<Donator> GetAll()
        {
            return _context.Donators.ToList();
        }

        public void Update(Donator entity)
        {
            _validator.Validate(entity);
            var oldEntity = Find(entity.Id);
            _context.Entry(oldEntity).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }
    }
}
