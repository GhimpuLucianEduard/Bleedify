using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BleedifyModels.ModelsEF;

namespace BleedifyModels.Validators
{
    public class CerereMedicPacientValidator
    {
        public void Validate(CerereMedicPacient entity)
        {
            var errorMessage = "";

            if (string.IsNullOrWhiteSpace(entity.TipComponenta))
            {
                errorMessage += "Tipul componentei trebuie setat! \n";
            }

            if (string.IsNullOrWhiteSpace(entity.Stare))
            {
                errorMessage += "Starea nu poate fi vida! \n";
            }

            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                throw new ValidationException(errorMessage);
            }
        }
    }
}
