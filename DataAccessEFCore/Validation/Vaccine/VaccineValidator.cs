using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessEFCore.Validation.Vaccine
{
    public class VaccineValidator : AbstractValidator<Domain.Entities.Vaccination>
    {
        private ApplicationDbContext _context;
        public VaccineValidator(ApplicationDbContext context)
        {
            _context = context;
            RuleFor(x => x.PatientId).Must(x=> IsAlreadyExist(x)).WithMessage("You are already fully vaccinated");
            RuleFor(x => x.DoseNo).NotEmpty().WithMessage("Please specify Dose Number");
            RuleFor(x => x.VaccinationCenterName).NotEmpty().WithMessage("Please specify Vaccination Center Name").MinimumLength(4).MaximumLength(30);
            RuleFor(x => x.VaccinationDate).NotEmpty().WithMessage("Please specify a valid Date");
            RuleFor(x => x.PatientId).NotNull().WithMessage("Please specify Patient Id");
            RuleFor(x => x.VaccineName).NotEmpty().WithMessage("Please specify Vaccine Name");
        }

        private bool IsAlreadyExist(int patientId)
        {
            var vaccines = _context.Set<Vaccination>().Where(x => x.PatientId == patientId);
            if (vaccines.Count() > 1)
            {
                return false;
            }
            return true;
        }
    }
}
