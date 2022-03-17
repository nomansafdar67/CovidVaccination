using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IVaccinationRepository
    {
        IList<Vaccination> GetAllVaccineInfo();
        Vaccination GetVaccineInfoById(int id);
        bool AddVaccination(Vaccination vaccination);
        void UpdateVaccination(Vaccination vaccination);
        void DeleteVaccination(int id);
    }
}
