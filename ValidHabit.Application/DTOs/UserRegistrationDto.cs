using System.ComponentModel.DataAnnotations;

namespace ValidHabit.Application.DTOs
{
    public class UserRegistrationDto
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


    }
}