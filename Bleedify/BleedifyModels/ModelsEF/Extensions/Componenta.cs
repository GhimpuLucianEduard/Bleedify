using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BleedifyModels.ModelsEF
{
    partial class Componenta : IHasID<int>
    {
        public Componenta(int id, string tipComponenta, int idDonatie, DateTime dataDepunere, int? idPrimitor, string stare, string nume, string prenume)
        {
            Id = id;
            TipComponenta = tipComponenta;
            IdDonatie = idDonatie;
            DataDepunere = dataDepunere;
            IdPrimitor = idPrimitor;
            Stare = stare;
            Pacient = new Pacient()
            {
                Nume = nume,
                Prenume = prenume
            };
        }

        public Componenta()
        {

        }

        public Donatie DonatieObj
        {
            get { return Donatie; }
            set { Donatie = value; }
        }

        public Pacient PacientObj
        {
            get { return Pacient; }
            set { Pacient = value; }
        }

    }
}
