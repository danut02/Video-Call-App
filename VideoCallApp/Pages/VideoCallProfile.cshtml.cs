using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideoCallApp.Data;
using VideoCallApp.Models;
using static System.Net.Mime.MediaTypeNames;

namespace VideoCallApp.Pages
{
    public class VideoCallProfileModel : PageModel
    {
        private VideoCallApplicationDbContext _dbContex;
        public VideoCallProfileModel(VideoCallApplicationDbContext dbContex)
        {
            _dbContex = dbContex;
        }
        public UserViewModel theViewModelUser = new UserViewModel();
        public User thatUser { get; set; }
        public void OnGet(int userId)
        {
            thatUser = _dbContex.Users.Find(userId);
            theViewModelUser.Username = thatUser.Username;
            theViewModelUser.theImage = _dbContex.Images.Find(thatUser.ImageId).Name;
        }
    }
}
