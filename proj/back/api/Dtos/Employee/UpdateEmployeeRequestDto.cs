using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Employee
{
    public class UpdateEmployeeRequestDto
    {
        [Required]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MinLength(2, ErrorMessage = "Surname must be at least 2 characters")]
        public string Surname { get; set; } = string.Empty;
        [Required]
        [MinLength(2, ErrorMessage = "Position must be at least 2 characters")]
        [MaxLength(100, ErrorMessage = "Position cannot be over 100 characters")]
        public string Position { get; set; } = string.Empty; // Должность
        [Required]
        [MinLength(2, ErrorMessage = "Shift must be at least 2 characters")]
        [MaxLength(100, ErrorMessage = "Shift cannot be over 100 characters")]
        public string Shift { get; set; } = string.Empty;  // Смена
        public long PhoneNumber { get; set; }
    }
}