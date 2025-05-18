using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Facility
{
    public class UpdateFacilityRequestDto
    {
        [Required]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters")]
        [MaxLength(100, ErrorMessage = "Name cannot be over 100 characters")]
        public string Name { get; set; } = string.Empty; // Название установки
        [Required]
        [MinLength(2, ErrorMessage = "Type must be at least 2 characters")]
        [MaxLength(100, ErrorMessage = "Type cannot be over 100 characters")]
        public string Type { get; set; } = string.Empty; // Тип установки
        [Required]
        [MinLength(2, ErrorMessage = "ColumnType must be at least 2 characters")]
        [MaxLength(100, ErrorMessage = "ColumnType cannot be over 100 characters")]
        public string ColumnType { get; set; } = string.Empty; // Тип колонн
        public decimal TemperatureTop { get; set; } // Температура верха колонны
        public decimal TemperatureBottom { get; set; } // Температура низа колонны
        public decimal PressureTop { get; set; } // Давление верха колонны
    }
}