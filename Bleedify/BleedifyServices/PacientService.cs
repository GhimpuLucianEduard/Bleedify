using BleedifyModels.ModelsEF;
using BleedifyModels.Repositories;
using BleedifyModels.Validators;
using System.Collections.Generic;
using System.Linq;

namespace BleedifyServices
{
    public class PacientService
    {
        private IRepository<int, Pacient> _repository;

        public PacientService()
        {
            _repository = new PacientRepository(new PacientValidator());
        }

        public void Add(Pacient entity)
        {
            _repository.Add(entity);
        }

        public Pacient Find(int id)
        {
            return _repository.Find(id);
        }

        public IEnumerable<Pacient> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(Pacient entity)
        {
            _repository.Update(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<Pacient> GetPacientByFullName(string Nume, string Prenume)
        {
            return _repository.GetAll().Where(x => x.Nume.CompareTo(Nume) == 0 && x.Prenume.CompareTo(Prenume) == 0).ToList(); ;
        }
    }
}
