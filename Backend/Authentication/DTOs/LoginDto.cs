using System.ComponentModel.DataAnnotations;

namespace UserService.DTOs
{
    public class LoginDto
    {
        [Required(ErrorMessage ="Email is Required")]
        [RegularExpression("^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$",ErrorMessage ="Email Format Incorrect")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Field Required")]
        public string Password { get; set; }
    }
}
