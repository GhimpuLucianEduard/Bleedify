using System.Collections.Generic;
using System.Linq;
using BleedifyModels.ModelsEF;
using BleedifyModels.Validators;

namespace BleedifyModels.Repositories
{
    public class PersonalRepository : IRepository<int, Personal>
    {
        private PersonalValidator _validator;
        private BleedifyDB _context = ContextGetter.GetContext();

        public PersonalRepository(PersonalValidator validator)
        {
            _validator = validator;
        }

        public void Add(Personal entity)
        {
            _validator.Validate(entity);
            _context.Personals.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Personals.Remove(Find(id));
            _context.SaveChanges();
        }

        public Personal Find(int id)
        {
            return _context.Personals.Find(id);
        }

        public IEnumerable<Personal> GetAll()
        {
            return _context.Personals.ToList();
        }

        public void Update(Personal entity)
        {
            _validator.Validate(entity);
            var oldEntity = Find(entity.Id);
            _context.Entry(oldEntity).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }
    }
}
