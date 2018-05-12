using BleedifyModels.ModelsEF;
using BleedifyModels.Repositories;
using BleedifyModels.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BleedifyServices
{
    public class AnuntDonatorService
    {
        private IRepository<int, AnuntDonator> _repository;

        public AnuntDonatorService()
        {
            _repository = new AnuntDonatorRepository(new AnuntDonatorValidator());
        }

        public IEnumerable<AnuntDonator> GetAll()
        {
            return _repository.GetAll();
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public void Add(AnuntDonator entity)
        {
            _repository.Add(entity);
        }

        public void BatchAdd(int grupaDeSange, string mesaj, Pacient pacient)
        {
            foreach (Donator donator in AppService.Instance.DonatorService.Filter(grupaDeSange, null, true))
            {
                AnuntDonator entity = new AnuntDonator();
                entity.IdDonator = donator.Id;
                entity.DataAnunt = DateTime.Now;
                entity.TipAnuntDonator = "Cerere";
                entity.Mesaj = "Salut, " + donator.Prenume + "\n\t";
                entity.Mesaj += "Avem nevoie de donatori grupa " + AppService.Instance.GrupaDeSangeService.Find(grupaDeSange).Nume;
                if (null != pacient) entity.Mesaj += " pentru " + pacient.Nume + " " + pacient.Prenume;
                entity.Mesaj += ".\n\n";
                if (null != mesaj)
                    entity.Mesaj += mesaj;

                AppService.Instance.AnuntDonatorService.Add(entity);
            }
        }

        public IEnumerable<AnuntDonator> Filter(string tipAnunt)
        {
            return _repository.GetAll()
                .Where(x =>
                {
                    if (string.IsNullOrEmpty(tipAnunt))
                        return true;
                    return x.TipAnuntDonator.ToLower().Equals(tipAnunt.ToLower());
                })
                .ToList();
        }
    }
}
