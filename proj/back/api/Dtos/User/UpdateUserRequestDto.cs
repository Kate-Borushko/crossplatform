using System.ComponentModel.DataAnnotations;

namespace api.Dtos.User
{
    public class UpdateUserRequestDto
    {
        [Required]
        [MinLength(1, ErrorMessage = "Name must be at least 1 character")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MinLength(1, ErrorMessage = "Surname must be at least 1 character")]
        public string Surname { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = string.Empty;

        [Required]
        [MinLength(2, ErrorMessage = "Position must be at least 2 characters")]
        [MaxLength(200, ErrorMessage = "Position must be less than 200 characters")]
        public string Position { get; set; } = string.Empty;

        [Required]
        public int? EmployeeID { get; set; }
    }
}
