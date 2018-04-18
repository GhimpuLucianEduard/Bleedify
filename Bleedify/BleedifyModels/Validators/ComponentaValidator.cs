using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BleedifyModels.ModelsEF;

namespace BleedifyModels.Validators
{
    public class ComponentaValidator : IValidator<Componenta>
    {
        public void Validate(Componenta entity)
        {
            var errorMessage = "";

            if (String.IsNullOrWhiteSpace(entity.Stare))
            {
                errorMessage += "Stare nu poate fi vid! \n";
            }

            if (String.IsNullOrWhiteSpace(entity.TipComponenta))
            {
                errorMessage += "Tip Componenta nu poate fi vid! \n";
            }

            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                throw new ValidationException(errorMessage);
            }
        }
    }
}
