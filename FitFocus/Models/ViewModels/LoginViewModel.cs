using System.ComponentModel.DataAnnotations;

namespace FitFocus.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set;}

        [Required]
        [MinLength(6, ErrorMessage = "Password must be at least 6 charators.")]
        public string Password { get; set;}

        public string? ReturnUrl { get; set;}
    }
}
