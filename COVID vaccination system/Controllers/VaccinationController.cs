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
    public class VaccinationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public VaccinationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("GetAllInfo")]
        public IActionResult GetAllVacInfo()
        {
            return Ok(_unitOfWork.Vaccinations.GetAllVaccineInfo());
        }
        [HttpGet("GetById")]
        public IActionResult GetVacInfoById(int id)
        {
            
            return Ok(_unitOfWork.Vaccinations.GetVaccineInfoById(id));
        }
        [HttpPost("AddVac")]
        public IActionResult AddVaccine(Vaccination vaccination)
        {
            _unitOfWork.Vaccinations.AddVaccination(vaccination);
            _unitOfWork.Complete();
            return Ok();
        }
        [HttpPut("UpdateVac")]
        public IActionResult UpdateVac(Vaccination vaccination)
        {
            _unitOfWork.Vaccinations.UpdateVaccination(vaccination);
            _unitOfWork.Complete();
            return Ok();
        }
        [HttpDelete("DeleteVac")]
        public IActionResult DeleteVac(int id)
        {
            _unitOfWork.Vaccinations.DeleteVaccination(id);
            _unitOfWork.Complete();
            return Ok();
        }
    }
}
