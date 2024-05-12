using System.ComponentModel.DataAnnotations;

namespace VideoCallApp.Models
{
    public class User
    {
        [Key]
        public int UserId {  get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public int ImageId {  get; set; }
        public Image theImage { get; set; }
        public Friends Friends { get; set; }
    }
}
