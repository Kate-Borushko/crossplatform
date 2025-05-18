using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Employee;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDBContext _context;
        public EmployeeRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Employee> CreateAsync(Employee employeeModedl)
        {
            await _context.Employees.AddAsync(employeeModedl);
            await _context.SaveChangesAsync();
            return employeeModedl;
        }

        public async Task<Employee?> DeleteAsync(int id)
        {
            var employeeModel = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employeeModel == null)
            {
                return null;
            }

            _context.Employees.Remove(employeeModel);
            await _context.SaveChangesAsync();
            return employeeModel;
        }

        public Task<bool> EmployeeExists(int id)
        {
            return _context.Employees.AnyAsync(s => s.Id == id);
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees.Include(c => c.Facilities).ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employees.Include(c => c.Facilities).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Employee?> UpdateAsync(int id, UpdateEmployeeRequestDto employeeDto)
        {
            var existingEmployee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (existingEmployee == null)
            {
                return null;
            }

            existingEmployee.Name = employeeDto.Name;
            existingEmployee.Surname = employeeDto.Surname;
            existingEmployee.Position = employeeDto.Position;
            existingEmployee.Shift = employeeDto.Shift;
            existingEmployee.PhoneNumber = employeeDto.PhoneNumber;

            await _context.SaveChangesAsync();

            return existingEmployee;
        }
    }
}