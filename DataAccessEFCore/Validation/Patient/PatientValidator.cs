using Domain.Entities;
using Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessEFCore.Validation.Patient
{
    public class PatientValidator : AbstractValidator<Domain.Entities.Patient>
    {
        public PatientValidator(ApplicationDbContext context)
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Please specify a first name").MinimumLength(4).MaximumLength(12);
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Please specify a first name").MinimumLength(4).MaximumLength(12);
            RuleFor(x => x.EmiratesId).NotEmpty().WithMessage("Please specify a valid Emirates Id");
            RuleFor(x => x.Address).Length(20, 250);
            RuleFor(x => x.Age).InclusiveBetween(12 , 60).WithMessage("Age Must be between 12 and 60");
            RuleFor(x => x.PhoneNo).NotEmpty().MaximumLength(15).WithMessage("Please specify a Phone Number");
        }
    }
}
