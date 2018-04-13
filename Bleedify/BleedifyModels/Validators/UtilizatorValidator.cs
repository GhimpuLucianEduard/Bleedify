using BleedifyModels.ModelsEF;

namespace BleedifyModels.Validators
{
	public class UtilizatorValidator : IValidator<Utilizator>
	{
		public void Validate(Utilizator entity)
		{
			var errorMessage = "";

			if (string.IsNullOrWhiteSpace(entity.UserName))
			{
				errorMessage += "Username-ul nu poate fi vid! \n";
			}

			if (string.IsNullOrWhiteSpace(entity.Password))
			{
				errorMessage += "Parola nu poate fi vida \n";
			}

			if (string.IsNullOrWhiteSpace(entity.UserName))
			{
				errorMessage += "Username-ul nu poate fi vid! \n";
			}

			if (!string.IsNullOrWhiteSpace(errorMessage))
			{
				throw new ValidationException(errorMessage);
			}
		}
	}
}