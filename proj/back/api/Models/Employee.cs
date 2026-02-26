using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty; // Должность
        public string Shift { get; set; } = string.Empty;  // Смена
        public long PhoneNumber { get; set; }

        public List<Facility> Facilities { get; set; } = new List<Facility>();
    }
}