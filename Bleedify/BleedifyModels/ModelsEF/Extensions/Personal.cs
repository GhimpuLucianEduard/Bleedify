﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BleedifyModels.ModelsEF
{
    partial class Personal : Utilizator
    {
        public Utilizator UtilizatorObj
        {
            get { return Utilizator; }
            set { Utilizator = value; }
        }
    }
}
