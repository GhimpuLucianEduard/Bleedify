

using BleedifyModels.ModelsEF;
using BleedifyModels.Repositories;
using BleedifyModels.Validators;
using System;
using System.Collections.Generic;
using System.Linq;

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
                TipComponenta = "Globule Rosii",
                IdDonatie = donatie.Id,
                DataDepunere = DateTime.Now,
                Stare = "In Asteptare"
            };
            var compPlasma = new Componenta()
            {
                TipComponenta = "Plasma",
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
        public IEnumerable<Componenta> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<Componenta> Filter(string tipComponenta, string stare)
        {
            return _repository.GetAll()
                .Where(x =>
                {
                    if (string.IsNullOrEmpty(tipComponenta))
                        return true;
                    return x.TipComponenta.ToLower().Equals(tipComponenta.ToLower());
                })
                .Where(x =>
                {
                    if (string.IsNullOrEmpty(stare))
                        return true;
                    return x.Stare.ToLower().Equals(stare.ToLower());
                })
                .ToList();
        }
    }
}
