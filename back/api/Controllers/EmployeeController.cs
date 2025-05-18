using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using api.Data;
using api.Dtos.Employee;
using api.Mappers;
using api.Interfaces;

namespace api.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IEmployeeRepository _employeeRepo;
        public EmployeeController(ApplicationDBContext context, IEmployeeRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var employees = await _employeeRepo.GetAllAsync();

            var employeeDto = employees.Select(s => s.ToEmployeeDto());

            return Ok(employees);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var employee = await _employeeRepo.GetByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee.ToEmployeeDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeRequestDto employeeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var employeeModel = employeeDto.ToEmployeeFromCreateDTO();

            await _employeeRepo.CreateAsync(employeeModel);
            
            return CreatedAtAction(nameof(GetById), new { id = employeeModel.Id }, employeeModel);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateEmployeeRequestDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var employeeModel = await _employeeRepo.UpdateAsync(id, updateDto);

            if (employeeModel == null)
            {
                return NotFound();
            }

            return Ok(employeeModel.ToEmployeeDto());

        }
        
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var employeeModel = await _employeeRepo.DeleteAsync(id);

            if (employeeModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}