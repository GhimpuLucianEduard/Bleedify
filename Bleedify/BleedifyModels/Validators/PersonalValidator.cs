﻿using BleedifyModels.ModelsEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BleedifyModels.Validators
{
    public class PersonalValidator : IValidator<Personal>
    {
        public void Validate(Personal entity)
        {
            var errorMessage = "";

            if(String.IsNullOrWhiteSpace(entity.Nume))
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
