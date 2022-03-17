using Domain.Entities;
using Domain.Enum;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessEFCore.Repositories
{
    public class VaccinationRepository : IVaccinationRepository
    {
        private readonly ApplicationDbContext _context;
        public VaccinationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool AddVaccination(Vaccination vaccination)
        {
            var vaccines = _context.Set<Vaccination>().Where(x => x.PatientId == vaccination.PatientId);
            var patient = _context.Set<Patient>().FirstOrDefault(x => x.Id == vaccination.PatientId);

            if (!vaccines.Any())
                patient.Status = VacinationStatus.PartiallyVaccinated;

            if (vaccines.Count() == 1)
                patient.Status = VacinationStatus.FullyVaccinated;

            _context.Set<Patient>().Update(patient);
            _context.Set<Vaccination>().Add(vaccination);
            _context.SaveChanges();
            return true;
        }

        public void DeleteVaccination(int id)
        {
            Vaccination vaccination = _context.vaccinations.Find(id);
            if (vaccination != null)
            {
                _context.Set<Vaccination>().Remove(vaccination);
            }
        }

        public IList<Vaccination> GetAllVaccineInfo()
        {
            return _context.Set<Vaccination>().ToList();
        }

        public Vaccination GetVaccineInfoById(int id)
        {
            return _context.Set<Vaccination>().Where(x => x.Id == id).FirstOrDefault();
        }

        public void UpdateVaccination(Vaccination vaccination)
        {
            _context.Set<Vaccination>().Update(vaccination);
        }
    }
}
