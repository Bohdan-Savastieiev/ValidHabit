using System.ComponentModel.DataAnnotations;

namespace ValidHabit.Application.DTOs.Authorization
{
    public class UserLoginDto
    {
        // Username/Email
        [Required(ErrorMessage = "Username or Email is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}