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
        public IActionResult OnPost()
        {
            Image _toAddImage = new Image();
            User _toAddUser = new User();
            if(theViewModel.Password == theViewModel.PasswordCopy)
            {
                if (theViewModel.ProfileImageUrl is null)
                {
                    _toAddUser = new User()
                    {
                        FirstName = theViewModel.FirstName,
                        LastName = theViewModel.LastName,
                        Username = theViewModel.Username,
                        Password = theViewModel.Password,
                        UserEmail = theViewModel.UserEmail,
                        Gender = theViewModel.Gender,
                    };
                    if (theViewModel.Gender == "Female")
                    {
                        _toAddUser.ImageId = 1;
                    }
                    if (theViewModel.Gender == "Male")
                    {
                        _toAddUser.ImageId = 2;
                    }
                }
                if (theViewModel.ProfileImageUrl is not null)
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
                }
                _dbContex.Users.Add(_toAddUser);
                _dbContex.SaveChanges();
            }
            else
            {
                AuditLog.addWrongPasswordSignUp();
                return RedirectToPage("Error");
            }
            return RedirectToPage("LogIn");
        }
    }
}
