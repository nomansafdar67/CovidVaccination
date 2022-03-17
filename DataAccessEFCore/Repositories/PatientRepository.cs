using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessEFCore.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _context;
        public PatientRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddPatient(Patient patient)
        {
            patient.Status = Domain.Enum.VacinationStatus.NotVaccinated;
            _context.Set<Patient>().Add(patient);
        }

        public void DeletePatient(int id)
        {
            Patient patient = _context.patients.Find(id);
            if(patient !=null)
            {
                _context.Set<Patient>().Remove(patient);
            }

        }

        public IList<Patient> GetAllPatients()
        {
            return _context.Set<Patient>().ToList();
        }

        public Patient GetPatientById(int id)
        {
            return _context.Set<Patient>().Where(x => x.Id == id).FirstOrDefault();
        }

        public void UpdatePatient(Patient patient)
        {
            _context.Set<Patient>().Update(patient);
        }
    }
}
