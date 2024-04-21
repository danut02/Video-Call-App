using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideoCallApp.Data;
using VideoCallApp.Models;

namespace VideoCallApp.Pages
{
    public class VideoCallOtherUserModel : PageModel
    {
        private VideoCallApplicationDbContext _dbContex;
        public VideoCallOtherUserModel(VideoCallApplicationDbContext dbContex)
        {
            _dbContex = dbContex;
        }
        public User thatUser { get; set; }
        public List<Image> images { get; set; }

        public void OnGet(int userId)
        {
            thatUser = _dbContex.Users.Find(userId);
            images = _dbContex.Images.ToList();
        }
    }
}