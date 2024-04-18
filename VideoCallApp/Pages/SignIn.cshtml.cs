using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult OnPost()
        {
            Image _toAddImage = new Image();

            if (theViewModel.Password != theViewModel.PasswordCopy)
            {
                   AuditLog.addWrongPasswordSignUp();
                   return RedirectToPage("Error");
            }

            var user = new User
            {
                FirstName = theViewModel.FirstName,
                LastName = theViewModel.LastName,
                Username = theViewModel.Username,
                Password = theViewModel.Password,
                UserEmail = theViewModel.UserEmail,
                Gender = theViewModel.Gender
            };
            if (theViewModel.ProfileImageUrl != null)
            {
                var image = new Image
                {
                    Name = theViewModel.ProfileImageUrl.FileName
                };
                _toAddImage = new Image()
                {
                    Name = theViewModel.ProfileImageUrl.FileName,
                };
                _dbContex.Images.Add(_toAddImage);
                _dbContex.SaveChanges();
                using (var fileStream = new FileStream("wwwroot/images/" + theViewModel.ProfileImageUrl.FileName, FileMode.Create))
                {
                    theViewModel.ProfileImageUrl.CopyTo(fileStream);
                }
                /*
                foreach (var elemUserImage in _dbContex.Images)
                {
                    if (elemUserImage.Name == theViewModel.ProfileImageUrl.FileName)
                    {
                        user.ImageId = elemUserImage.Id;
                        break;
                    }
                }
                */
                var theImage = _dbContex.Images.ToList();
                theImage = theImage.Where(e=>e.Name == theViewModel.ProfileImageUrl.FileName).ToList();
                user.ImageId = theImage.ElementAt(0).Id;
            }
            else
            {
                if(theViewModel.Gender == "Female")
                {
                    user.ImageId = 1;
                }
                else
                {
                    user.ImageId = 2;
                }
            }

            _dbContex.Users.Add(user);
            _dbContex.SaveChanges();

            return RedirectToPage("LogIn");
        }
    }
}

