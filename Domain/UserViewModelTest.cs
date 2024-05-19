using System.ComponentModel.DataAnnotations;

namespace VideoCallApp.Models
{
    public class UserViewModelTest
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PasswordNew { get; set; } = string.Empty;
        public string PasswordCopy { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string theImage {  get; set; } = string.Empty;
    }
}
