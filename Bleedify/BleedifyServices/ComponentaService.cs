

using BleedifyModels.ModelsEF;
using BleedifyModels.Repositories;
using BleedifyModels.Validators;
using System;

namespace BleedifyServices
{
    public class ComponentaService
    {
        private IRepository<int, Componenta> _repository;

        public ComponentaService()
        {
            _repository = new ComponentaRepository(new ComponentaValidator());
        }

        public void PrelucreazaDonatie(Donatie donatie)
        {
            var compTrombocite = new Componenta()
            {
                TipComponenta = "Trombocite",
                IdDonatie = donatie.Id,
                DataDepunere = DateTime.Now,
                Stare = "In Asteptare"
            };
            var compGlobuleR = new Componenta()
            {
                TipComponenta = "Trombocite",
                IdDonatie = donatie.Id,
                DataDepunere = DateTime.Now,
                Stare = "In Asteptare"
            };
            var compPlasma = new Componenta()
            {
                TipComponenta = "Trombocite",
                IdDonatie = donatie.Id,
                DataDepunere = DateTime.Now,
                Stare = "In Asteptare"
            };
            try
            {
                _repository.Add(compTrombocite);
                _repository.Add(compGlobuleR);
                _repository.Add(compPlasma);
            }
            catch (ApplicationException)
            {
                throw new ServiceException("Something went wrong");
            }
        }
    }
}
