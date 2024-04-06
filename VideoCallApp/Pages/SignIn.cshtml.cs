using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideoCallApp.Data;
using VideoCallApp.Models;

namespace VideoCallApp.Pages
{
    public class SignInModel : PageModel
    {
        private VideoCallApplicationDbContext _dbContex;
        public SignInModel(VideoCallApplicationDbContext dbContex)
        {
            _dbContex = dbContex;
        }
        [BindProperty]
        public UserViewModel theViewModel { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            /*if (theViewModel.ProfileImageUrl is null || theViewModel.ProfileImageUrl.Length == 0)
            {
                if (theViewModel.Gender == "Female")
                {
                    //theViewModel.ProfileImageUrl = "/images/FemaleSexSymbol.png";
                }
                if (theViewModel.Gender == "Male")
                {
                    theViewModel.ProfileImageUrl = "/images/MaleSexSymbol.png";
                }
            }
            var _toAddUser = new User()
            {
                FirstName = theViewModel.FirstName,
                LastName = theViewModel.LastName,
                Username = theViewModel.Username,
                Password = theViewModel.Password,
                UserEmail = theViewModel.UserEmail,
                Gender = theViewModel.Gender,
            };
            _dbContex.Users.Add(_toAddUser);
            _dbContex.SaveChanges();
            var _toAddImage = new Image()
            {
                Name = theViewModel.ProfileImageUrl.FileName,
                UserId =_toAddUser.UserId,
            };
            _dbContex.Images.Add(_toAddImage);
            _dbContex.SaveChanges();
            */
        }
    }
}
