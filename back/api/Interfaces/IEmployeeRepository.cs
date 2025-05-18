using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Employee;
using api.Models;

namespace api.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllAsync();
        Task<Employee?> GetByIdAsync(int id);
        Task<Employee> CreateAsync(Employee employeeModedl);
        Task<Employee?> UpdateAsync(int id, UpdateEmployeeRequestDto employeeDto);
        Task<Employee?> DeleteAsync(int id);
        Task<bool> EmployeeExists(int id);
    }
}