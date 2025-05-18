using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Facility
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Название установки
        public string Type { get; set; } = string.Empty; // Тип установки
        public string ColumnType { get; set; } = string.Empty; // Тип колонн
        [Column(TypeName = "decimal(10,2)")]
        public decimal TemperatureTop { get; set; } // Температура верха колонны
        [Column(TypeName = "decimal(10,2)")]
        public decimal TemperatureBottom { get; set; } // Температура низа колонны
        [Column(TypeName = "decimal(10,2)")]
        public decimal PressureTop { get; set; } // Давление верха колонны
        public int? EmployeeId { get; set; } 
        public Employee? Employee { get; set; }
    }
}