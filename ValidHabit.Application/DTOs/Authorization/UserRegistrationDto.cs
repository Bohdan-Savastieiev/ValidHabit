using System.ComponentModel.DataAnnotations;

namespace ValidHabit.Application.DTOs.Authorization
{
    public class UserRegistrationDto
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [MinLength(5, ErrorMessage = "Username must be at least 5 characters long.")]
        [MaxLength(25, ErrorMessage = "Username cannot be more than 25 characters long.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [MinLength(1, ErrorMessage = "First name must be at least 1 character long.")]
        [MaxLength(50, ErrorMessage = "First name cannot be more than 50 characters long.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [MinLength(1, ErrorMessage = "Last name must be at least 1 character long.")]
        [MaxLength(50, ErrorMessage = "Last name cannot be more than 50 characters long.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        [MaxLength(50, ErrorMessage = "Password cannot be more than 50 characters long.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required.")]
        [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
