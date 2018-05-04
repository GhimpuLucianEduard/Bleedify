using BleedifyModels.ModelsEF;
using System;



namespace BleedifyModels.Validators
{
    public class PacientValidator : IValidator<Pacient>
    {
        public void Validate(Pacient entity)
        {
            var errorMessage = "";

            if (String.IsNullOrWhiteSpace(entity.Nume))
            {
                errorMessage += "Numele nu poate fi vid! \n";
            }

            if (String.IsNullOrWhiteSpace(entity.Prenume))
            {
                errorMessage += "Prenumele nu poate fi vid! \n";
            }

            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                throw new ValidationException(errorMessage);
            }
        }
    }
}
