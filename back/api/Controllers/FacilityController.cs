using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Facility;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/facility")]
    [ApiController]
    public class FacilityController : ControllerBase
    {
        private readonly IFacilityRepository _facilityRepo;
        private readonly IEmployeeRepository _employeeRepo;
        public FacilityController(IFacilityRepository facilityRepo, IEmployeeRepository employeeRepo)
        {
            _facilityRepo = facilityRepo;
            _employeeRepo = employeeRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var facilities = await _facilityRepo.GetAllAsync(query);

            var facilityDto = facilities.Select(s => s.ToFacilityDto());

            return Ok(facilityDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var facility = await _facilityRepo.GetByIdAsync(id);

            if (facility == null)
            {
                return NotFound();
            }

            return Ok(facility.ToFacilityDto());
        }

        [HttpPost("{employeeId:int}")]
        public async Task<IActionResult> Create([FromRoute] int employeeId, CreateFacilityDto facilityDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _employeeRepo.EmployeeExists(employeeId))
            {
                return BadRequest("Employee does not exist");
            }

            var facilityModel = facilityDto.ToFacilityFromCreate(employeeId);
            await _facilityRepo.CreateAsync(facilityModel);
            return CreatedAtAction(nameof(GetById), new { id = facilityModel.Id }, facilityModel.ToFacilityDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateFacilityRequestDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var facility = await _facilityRepo.UpdateAsync(id, updateDto.ToFacilityFromUpdate());

            if (facility == null)
            {
                return NotFound("Facility not found");
            }

            return Ok(facility.ToFacilityDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var facilityModel = await _facilityRepo.DeleteAsync(id);

            if (facilityModel == null)
            {
                return NotFound("Facility does not exist");
            }

            return Ok(facilityModel);
        }
    }
}