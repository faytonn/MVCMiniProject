using System.ComponentModel.DataAnnotations;

namespace MVCMiniProject.Models
{
    public class RegisterViewModel
    {
        [MaxLength(25)]
        [MinLength(3)]
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [MaxLength(25)]
        [MinLength(3)]
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [EmailAddress]
        [MaxLength(25)]
        [MinLength(5)]
        [Required]
        public string Email { get; set; }

        [MinLength(8)]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [MinLength(8)]
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

    }
}
