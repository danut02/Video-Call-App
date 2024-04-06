using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideoCallApp.Data;
using VideoCallApp.Models;

namespace VideoCallApp.Pages
{
    public class VideoCallInterfaceModel : PageModel
    {
        private VideoCallApplicationDbContext _dbContex;
        public VideoCallInterfaceModel(VideoCallApplicationDbContext dbContex)
        {
            _dbContex = dbContex;
        }
        public UserViewModel theViewModelUser = new UserViewModel();
        public void OnGet(User theUser)
        {
        /*    theViewModelUser.Username = theUser.Username;
            theViewModelUser.ProfileImageUrl = theUser.ProfileImageUrl;
        */
        }
    }
}
