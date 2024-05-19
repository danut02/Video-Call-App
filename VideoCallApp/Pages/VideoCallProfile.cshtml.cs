using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideoCallApp.Data;
using VideoCallApp.Models;
using VideoCallApp.Repository.Interface;
using static System.Net.Mime.MediaTypeNames;

namespace VideoCallApp.Pages
{
    public class VideoCallProfileModel : PageModel
    {
        private IUserRepository _users;
        private IImageRepository _images;
        public VideoCallProfileModel(IUserRepository _usersContext, IImageRepository _imageContext)
        {
            _users = _usersContext;
            _images = _imageContext;
        }
        public UserViewModel theViewModelUser = new UserViewModel();
        public User thatUser { get; set; }
        public void OnGet(int userId)
        {
            thatUser = _users.GetById(userId);
            theViewModelUser.Username = thatUser.Username;
            theViewModelUser.theImage = _images.GetById(thatUser.ImageId).Name;
        }
    }
}
