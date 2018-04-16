using BleedifyModels.ModelsEF;
using BleedifyModels.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BleedifyModels.Repositories
{
    public class DonatieRepository : IRepository<int, Donatie>
    {
        private DonatieValidator _validator;
        private BleedifyDB _context = ContextGetter.GetContext();

        public DonatieRepository(DonatieValidator validator)
        {
            _validator = validator;
        }

        public void Add(Donatie entity)
        {
            _validator.Validate(entity);
            _context.Donaties.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Donaties.Remove(Find(id));
            _context.SaveChanges();
        }

        public Donatie Find(int id)
        {
            return _context.Donaties.Find(id);
        }

        public IEnumerable<Donatie> GetAll()
        {
            return _context.Donaties.ToList();
        }

        public void Update(Donatie entity)
        {
            _validator.Validate(entity);
            var oldEntity = Find(entity.Id);
            _context.Entry(oldEntity).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }
    }
}
