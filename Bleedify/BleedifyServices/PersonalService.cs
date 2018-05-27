using System.Linq;
using BleedifyModels.ModelsEF;
using BleedifyModels.Repositories;

namespace BleedifyServices
{
	public class PersonalService
	{
		private IRepository<int, Personal> _repository;

		public Utilizator FindByIdUtilizator(int idUtilizator)
		{
			return _repository.GetAll().First(x => x.IdUtilizator == idUtilizator);
		}
	}
}