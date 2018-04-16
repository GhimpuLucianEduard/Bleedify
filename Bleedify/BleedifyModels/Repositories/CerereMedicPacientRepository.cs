using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BleedifyModels.ModelsEF;
using BleedifyModels.Validators;

namespace BleedifyModels.Repositories
{
    public class CerereMedicPacientRepository : IRepository<int, CerereMedicPacient>
    {
        private CerereMedicPacientValidator _validator;
        private BleedifyDB _context = ContextGetter.GetContext();

        public CerereMedicPacientRepository(CerereMedicPacientValidator validator)
        {
            _validator = validator;
        }

        public void Add(CerereMedicPacient entity)
        {
            _validator.Validate(entity);
            _context.CerereMedicPacients.Add(entity);
            _context.SaveChanges();
        }

        public void Update(CerereMedicPacient entity)
        {
            _validator.Validate(entity);
            var oldEntity = Find(entity.Id);
            _context.Entry(oldEntity).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.CerereMedicPacients.Remove(Find(id));
            _context.SaveChanges();
        }

        public CerereMedicPacient Find(int id)
        {
            return _context.CerereMedicPacients.Find(id);
        }

        public IEnumerable<CerereMedicPacient> GetAll()
        {
            return _context.CerereMedicPacients.ToList();
        }
    }
}
