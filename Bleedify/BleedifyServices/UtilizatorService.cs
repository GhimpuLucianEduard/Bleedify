using System.Linq;
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

		public bool Login(string username, string password)
		{
			var loginOk = false;
			_repository.GetAll().ToList().ForEach(utilizator =>
			{
				if (utilizator.Password.CompareTo(password) == 0 && utilizator.UserName.CompareTo(username) == 0)
				{
					loginOk = true;
				}
			});

			return loginOk;
		}

		public void Register(Utilizator utilizator)
		{
			_repository.Add(utilizator);
		}
	}
}