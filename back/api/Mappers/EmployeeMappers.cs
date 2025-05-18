using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Employee;
using api.Models;

namespace api.Mappers
{
    public static class EmployeeMappers
    {
        public static EmployeeDto ToEmployeeDto(this Employee employeeModel)
        {
            return new EmployeeDto
            {
                Id = employeeModel.Id,
                Name = employeeModel.Name,
                Surname = employeeModel.Surname,
                Position = employeeModel.Position,
                Shift = employeeModel.Shift,
                PhoneNumber = employeeModel.PhoneNumber,
                Facilities = employeeModel.Facilities.Select(c => c.ToFacilityDto()).ToList()
            };
        }

        public static Employee ToEmployeeFromCreateDTO(this CreateEmployeeRequestDto employeeDto)
        {
            return new Employee
            {
                Name = employeeDto.Name,
                Surname = employeeDto.Surname,
                Position = employeeDto.Position,
                Shift = employeeDto.Shift,
                PhoneNumber = employeeDto.PhoneNumber
            };
        }
        
    }
}