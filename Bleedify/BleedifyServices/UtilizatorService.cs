using System.Linq;
using BleedifyModels.Enums;
using BleedifyModels.ModelsEF;
using BleedifyModels.Repositories;
using BleedifyModels.Validators;

namespace BleedifyServices.Services
{
	public class UtilizatorService
	{
		private IRepository<int, Utilizator> _repository;

		public UtilizatorService()
		{
			_repository = new UtilizatorRepository(new UtilizatorValidator());
		}

		public void Add(Utilizator utilizator)
		{
			_repository.Add(utilizator);
		}

		public Utilizator Login(string username, string password, TipUtilizator tipUtilizator)
		{
			Utilizator toFind = null;
			_repository.GetAll().ToList().ForEach(utilizator =>
			{
				if (utilizator.Password.CompareTo(password) == 0 && utilizator.UserName.CompareTo(username) == 0)
				{
					toFind = utilizator;
				}
			});

			if (toFind == null)
			{
				return null;
			}

			if (tipUtilizator.Equals(TipUtilizator.Medic))
			{
				return AppService.Instance.MedicService.FindByIdUtilizator(toFind.Id);
			}
			else if (tipUtilizator.Equals(TipUtilizator.Donator))
			{
				return AppService.Instance.DonatorService.FindByIdUtilizator(toFind.Id);
			}
			else
			{
				return AppService.Instance.PersonalService.FindByIdUtilizator(toFind.Id);
			}

			return null;
		}

		public void Register(Utilizator utilizator)
		{
			_repository.Add(utilizator);
		}
	}
}