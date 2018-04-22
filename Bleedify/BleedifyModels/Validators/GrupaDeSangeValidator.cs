using BleedifyModels.ModelsEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BleedifyModels.Validators
{
    public class GrupaDeSangeValidator : IValidator<GrupaDeSange>
    {
        public void Validate(GrupaDeSange entity)
        {
            var errorMessage = "";

            if (String.IsNullOrWhiteSpace(entity.Nume))
            {
                errorMessage += "Nume nu poate fi vid! \n";
            }

            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                throw new ValidationException(errorMessage);
            }
        }
    }
}
