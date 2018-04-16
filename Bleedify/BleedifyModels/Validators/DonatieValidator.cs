using BleedifyModels.ModelsEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BleedifyModels.Validators
{
    public class DonatieValidator : IValidator<Donatie>
    {
        public void Validate(Donatie entity)
        {
            var errorMessage = "";
            
            if (String.IsNullOrWhiteSpace(entity.EtapaDonare))
            {
                errorMessage += "EtapaDonare nu poate fi vid! \n";
            }
            
            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                throw new ValidationException(errorMessage);
            }
        }
    }
}
