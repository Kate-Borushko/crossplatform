using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace api.Models
{
    public class User
    {
        [Key]
        [Required]
        public int UserID { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Surname { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Position { get; set; } = string.Empty; // должность 

        [Required]
        public int? EmployeeID { get; set; }
        public Employee? Employee { get; set; }

        [Required]
        public string Login { get; set; } = string.Empty;

        [Required]
        public string Role => EmployeeID == 1 ? "Admin" : "User"; // права доступа (в приложении)

        [Required]
        public string Password { get; set; } = string.Empty;

        public bool IsAdmin => Role == "Admin";
    }
}
