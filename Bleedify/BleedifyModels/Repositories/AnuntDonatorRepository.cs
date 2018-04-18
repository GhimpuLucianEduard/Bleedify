using BleedifyModels.ModelsEF;
using BleedifyModels.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BleedifyModels.Repositories
{
    public class AnuntDonatorRepository : IRepository<int, AnuntDonator>
    {
        private AnuntDonatorValidator _validator;
        private BleedifyDB _context = ContextGetter.GetContext();

        public AnuntDonatorRepository(AnuntDonatorValidator validator)
        {
            _validator = validator;
        }

        public void Add(AnuntDonator entity)
        {
            _validator.Validate(entity);
            _context.AnuntDonators.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.AnuntDonators.Remove(Find(id));
            _context.SaveChanges();
        }

        public AnuntDonator Find(int id)
        {
            return _context.AnuntDonators.Find(id);
        }

        public IEnumerable<AnuntDonator> GetAll()
        {
            return _context.AnuntDonators.ToList();
        }

        public void Update(AnuntDonator entity)
        {
            _validator.Validate(entity);
            var oldEntity = Find(entity.Id);
            _context.Entry(oldEntity).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }
    }
}
