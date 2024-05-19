using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideoCallApp.Data;
using VideoCallApp.Models;
using VideoCallApp.Repository.Interface;

namespace VideoCallApp.Pages
{
    public class VideoCallOtherUserModel : PageModel
    {
        private IUserRepository _users;
        private IImageRepository _images;
        public VideoCallOtherUserModel(IUserRepository _userContex, IImageRepository _imageContext)
        {
            _users = _userContex;
            _images = _imageContext;
        }
        public User thatUser { get; set; }
        public List<Image> images { get; set; }

        public void OnGet(int userId)
        {
            thatUser = _users.GetById(userId);
            images = _images.GetAll();
        }
    }
}