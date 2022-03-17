using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enum;

namespace Domain.Entities
{
    public class Vaccination
    {
        [Key]
        public int Id { get; set; }
        public string VaccineName { get; set; }
        public string VaccinationCenterName { get; set; }
        public int DoseNo { get; set; }
        public DateTime VaccinationDate { get; set; }
        [ForeignKey(nameof(Id))]
        public int PatientId { get; set; }
    }
}
