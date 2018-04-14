using BleedifyModels.ModelsEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BleedifyModels.Validators
{
    public class DonatorValidator : IValidator<Donator>
    {
        public void Validate(Donator entity)
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
