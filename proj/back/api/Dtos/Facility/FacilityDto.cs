using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Facility
{
    public class FacilityDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Название установки
        public string Type { get; set; } = string.Empty; // Тип установки
        public string ColumnType { get; set; } = string.Empty; // Тип колонн
        public decimal TemperatureTop { get; set; } // Температура верха колонны
        public decimal TemperatureBottom { get; set; } // Температура низа колонны
        public decimal PressureTop { get; set; } // Давление верха колонны
        public int? EmployeeId { get; set; } 
    }
}