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
<<<<<<< HEAD
            Image _toAddImage = new Image();

            if(_dbContex.Users.Where(e => e.UserEmail == theViewModel.UserEmail).Any())
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
                    _dbContex.Images.Add(_toAddImage);
                    _dbContex.SaveChanges();
                    using (var fileStream = new FileStream("wwwroot/images/" + theViewModel.ProfileImageUrl.FileName, FileMode.Create))
                    {
                        theViewModel.ProfileImageUrl.CopyTo(fileStream);
                    }
                    var theImage = _dbContex.Images.ToList();
                    theImage = theImage.Where(e => e.Name == theViewModel.ProfileImageUrl.FileName).ToList();
                    user.ImageId = theImage.ElementAt(0).Id;
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
=======
            if (!ModelState.IsValid)
            {
                // Revenim la pagina de signin dacă modelul nu este valid
                return Page();
>>>>>>> main
            }

            if (theViewModel.Password != theViewModel.PasswordCopy)
            {
<<<<<<< HEAD
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

=======
                // Afișăm o eroare și revenim la pagina de signin
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
                    theViewModel.ProfileImageUrl.CopyTo(fileStream);
                }

                _dbContext.Images.Add(image);
                _dbContext.SaveChanges();

                // Setăm id-ul imaginii asociate utilizatorului
                user.ImageId = image.Id;
            }

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            // Redirectăm către pagina de login după înregistrare
>>>>>>> main
            return RedirectToPage("LogIn");
        }
    }
}

