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
            User _toAddUser = new User();
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (theViewModel.Password != theViewModel.PasswordCopy)
            {
                ModelState.AddModelError(string.Empty, "Password and Confirm Password do not match.");
                return Page();
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

                using (var fileStream = new FileStream("wwwroot/images/" + theViewModel.ProfileImageUrl.FileName, FileMode.Create))
                {
                    _toAddImage = new Image()
                    {
                        Name = theViewModel.ProfileImageUrl.FileName,
                    };
                    _dbContex.Images.Add(_toAddImage);
                    _dbContex.SaveChanges();
                    foreach (var elemUserImage in _dbContex.Images)
                    {
                        if (elemUserImage.Name == theViewModel.ProfileImageUrl.FileName)
                        {
                            _toAddUser.ImageId = elemUserImage.Id;
                        }
                    }
                    theViewModel.ProfileImageUrl.CopyTo(fileStream);
                }

                _dbContex.Images.Add(image);
                _dbContex.SaveChanges();

                user.ImageId = image.Id;
            }

            _dbContex.Users.Add(user);
            _dbContex.SaveChanges();

            return RedirectToPage("LogIn");
        }
    }
}

