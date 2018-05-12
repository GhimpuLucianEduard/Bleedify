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
    public class DonatieService
    {
        private IRepository<int, Donatie> _repository;

        public DonatieService()
        {
            _repository = new DonatieRepository(new DonatieValidator());
        }

        public void Add(Donatie entity)
        {
            _repository.Add(entity);
        }

        public IEnumerable<Donatie> GetAll()
        {
	
            return _repository.GetAll();
        }

	    public void Delete(int id)
	    {
		    _repository.Delete(id);
	    }

	    public IEnumerable<Donatie> GetAllByDonator(int idDonator)
	    {
		    return _repository.GetAll().Where(x => x.IdDonator == idDonator).ToList();
	    }

        public void Update(Donatie donatie)
        {
            Donatie oldDonatie = _repository.Find(donatie.Id);
            if (!oldDonatie.EtapaDonare.Equals(donatie))
            {
                // s-a schimbat etapa de donare, anuntam donatorul
                AnuntDonator anunt = new AnuntDonator();
                anunt.IdDonator = donatie.IdDonator;                

                anunt.Mesaj = "Etapa donarii tale s-a schimbat din " + oldDonatie.EtapaDonare +
                    " in " + donatie.EtapaDonare + ". ";
                if (null == donatie.MotivRefuz)
                {
                    anunt.TipAnuntDonator = "Informare";
                }
                else
                {
                    anunt.TipAnuntDonator = "Refuz";
                    anunt.Mesaj += "Motivul refuzului: " + donatie.MotivRefuz + ".";
                }
                anunt.DataAnunt = DateTime.Now;

                AppService.Instance.AnuntDonatorService.Add(anunt);
            }
            _repository.Update(donatie);
        }

        public IEnumerable<Donatie> Filter(string etapaDonare, Nullable<int> grupaDeSange = null)
        {          
            return _repository.GetAll()
                .Where(x => {
                    if (null == grupaDeSange || !grupaDeSange.HasValue)
                        return true;
                    return x.GrupaDeSange.HasValue && x.GrupaDeSange.Value == grupaDeSange;
                    })
                .Where(x =>
                {
                    if (string.IsNullOrEmpty(etapaDonare))
                        return true;
                    return x.EtapaDonare.ToLower().Equals(etapaDonare.ToLower());
                });
        }
    }
}
