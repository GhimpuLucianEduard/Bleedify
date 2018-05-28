using System.Linq;
using BleedifyModels.ModelsEF;
using BleedifyModels.Repositories;
using BleedifyModels.Validators;

namespace BleedifyServices
{
	public class PersonalService
	{
		private IRepository<int, Personal> _repository;

		public PersonalService()
		{
			_repository = new PersonalRepository(new PersonalValidator());
		}

		public Utilizator FindByIdUtilizator(int idUtilizator)
		{
			return _repository.GetAll().First(x => x.IdUtilizator == idUtilizator);
		}

		public void Add(Personal entity)
		{
			var utilizator = new Utilizator();
			utilizator.TipUtilizator = entity.TipUtilizator;
			utilizator.InstitutieAsociata = entity.InstitutieAsociata;
			utilizator.UserName = entity.UserName;
			utilizator.Password = entity.Password;
			AppService.Instance.UtilizatorService.Add(utilizator);
			entity.IdUtilizator = utilizator.Id;
			_repository.Add(entity);
		}
	}
}