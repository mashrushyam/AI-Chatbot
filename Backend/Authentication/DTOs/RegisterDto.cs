using System.ComponentModel.DataAnnotations;

namespace UserService.DTOs
{
    public class RegisterDto
    {
        [Required(ErrorMessage ="User name Field Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is Reruired")]
        [RegularExpression("^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$",ErrorMessage ="Email Format Incorrect")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Field Required")]
        public string Password { get; set; }

        [Required(ErrorMessage =("Confirm Password Filed Required"))]
        [Compare("Password",ErrorMessage ="Confirm Password and Password must be same")]
        public string ConfirmPassword { get; set; }
    }
}
