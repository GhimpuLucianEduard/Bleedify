using BleedifyModels.Validators;
using BleedifyModels.ModelsEF;
using System.Collections.Generic;
using System.Linq;

namespace BleedifyModels.Repositories
{
    public class PacientRepository: IRepository<int, Pacient>
    {
        private PacientValidator _validator;
        private BleedifyDB _context = ContextGetter.GetContext();

        public PacientRepository(PacientValidator validator)
        {
            _validator = validator;
        }

        public void Add(Pacient entity)
        {
            _validator.Validate(entity);
            _context.Pacients.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Pacient entity)
        {
            _validator.Validate(entity);
            var oldEntity = Find(entity.Id);
            _context.Entry(oldEntity).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Pacients.Remove(Find(id));
            _context.SaveChanges();
        }

        public Pacient Find(int id)
        {
            return _context.Pacients.Find(id);
        }

        public IEnumerable<Pacient> GetAll()
        {
            return _context.Pacients.ToList();
        }
    }
}

