using BleedifyModels.ModelsEF;
using BleedifyModels.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BleedifyModels.Repositories
{
    public class GrupaDeSangeRepository : IRepository<int, GrupaDeSange>
    {
        private GrupaDeSangeValidator _validator;
        private BleedifyDB _context = ContextGetter.GetContext();


        public GrupaDeSangeRepository(GrupaDeSangeValidator validator)
        {
            _validator = validator;
        }

        public void Add(GrupaDeSange entity)
        {
            _validator.Validate(entity);
            _context.GrupaDeSanges.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.GrupaDeSanges.Remove(Find(id));
            _context.SaveChanges();
        }

        public GrupaDeSange Find(int id)
        {
            return _context.GrupaDeSanges.Find(id);
        }

        public IEnumerable<GrupaDeSange> GetAll()
        {
            return _context.GrupaDeSanges.ToList();
        }

        public void Update(GrupaDeSange entity)
        {
            _validator.Validate(entity);
            var oldEntity = Find(entity.Id);
            _context.Entry(oldEntity).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }
    }
}
