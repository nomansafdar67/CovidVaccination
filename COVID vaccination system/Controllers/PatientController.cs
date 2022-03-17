using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COVID_vaccination_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public PatientController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("GetAllPatients")]
        public IActionResult GetAllPatients()
        {
            return Ok(_unitOfWork.Patients.GetAllPatients());
        }

        [HttpGet("GetPatientById")]
        public IActionResult GetPatientById(int id)
        {
            return Ok(_unitOfWork.Patients.GetPatientById(id));
        }

        [HttpPost("Add")]
        public IActionResult Add(Patient patient)
        {
            _unitOfWork.Patients.AddPatient(patient);
            _unitOfWork.Complete();
            return Ok();
        }
        [HttpPut("Update")]
        public IActionResult update(Patient patient)
        {
            _unitOfWork.Patients.UpdatePatient(patient);
            _unitOfWork.Complete();
            return Ok();
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            _unitOfWork.Patients.DeletePatient(id);
            _unitOfWork.Complete();
            return Ok();
        }

    }
}
