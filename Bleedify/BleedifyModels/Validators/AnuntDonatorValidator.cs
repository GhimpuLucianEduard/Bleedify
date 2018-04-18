using BleedifyModels.ModelsEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BleedifyModels.Validators
{
    public class AnuntDonatorValidator : IValidator<AnuntDonator>
    {
        public void Validate(AnuntDonator entity)
        {
            var errorMessage = "";
            
            if (String.IsNullOrWhiteSpace(entity.Mesaj))
            {
                errorMessage += "Mesajul nu poate fi vid! \n";
            }

            if (String.IsNullOrWhiteSpace(entity.TipAnuntDonator))
            {
                errorMessage += "Tipul nu poate fi vid! \n";
            }

            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                throw new ValidationException(errorMessage);
            }
        }
    }
}
