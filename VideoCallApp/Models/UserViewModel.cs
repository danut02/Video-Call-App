using System.ComponentModel.DataAnnotations;

namespace VideoCallApp.Models
{
    public class UserViewModel
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string UserEmail { get; set; } = string.Empty;
        [Required]
        public string Gender { get; set; } = string.Empty;
        public IFormFile ProfileImageUrl { get; set; }
    }
}
