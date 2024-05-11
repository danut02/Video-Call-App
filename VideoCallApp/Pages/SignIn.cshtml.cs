using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VideoCallApp.Data;
using VideoCallApp.Models;
using System.IO; // Pentru FileStream

namespace VideoCallApp.Pages
{
    public class SignInModel : PageModel
    {
        private readonly VideoCallApplicationDbContext _dbContext;

        public SignInModel(VideoCallApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public UserViewModel theViewModel { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            Image _toAddImage = new Image();
            
            if (_dbContext.Users.Where(e => e.UserEmail == theViewModel.UserEmail).Any())
            {
                AuditLog.addSameEmailError();
                return RedirectToPage("Error");
            }
            
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
                string[] parts = theViewModel.ProfileImageUrl.FileName.Split('.');
                int final = parts.Length - 1;
                if (parts[final] == "jpg" || parts[final] == "jpeg" || parts[final] == "png" || parts[final] == "gif" || parts[final] == "jfif" || parts[final] == "pjpeg" || parts[final] == "pjp" || parts[final] == "svg" || parts[final] == "bmp")
                {
                    var image = new Image
                    {
                        Name = theViewModel.ProfileImageUrl.FileName
                    };
                    _toAddImage = new Image()
                    {
                        Name = theViewModel.ProfileImageUrl.FileName,
                    };
                    _dbContext.Images.Add(_toAddImage);
                    _dbContext.SaveChanges();
                    using (var fileStream = new FileStream("wwwroot/images/" + theViewModel.ProfileImageUrl.FileName, FileMode.Create))
                    {
                        theViewModel.ProfileImageUrl.CopyTo(fileStream);
                    }
                    var theImage = _dbContext.Images.ToList();
                    theImage = theImage.Where(e => e.Name == theViewModel.ProfileImageUrl.FileName).ToList();
                    user.ImageId = theImage.ElementAt(0).Id;
                }
            }
            else
            {
                if (theViewModel.Gender == "Female")
                {
                    user.ImageId = 1;
                }
                else
                {
                    user.ImageId = 2;
                }
            }
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return RedirectToPage("LogIn");
        }
    }
}

