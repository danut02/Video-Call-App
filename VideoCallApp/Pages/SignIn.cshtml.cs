using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
            if (!ModelState.IsValid)
            {
                // Revenim la pagina de signin dacă modelul nu este valid
                return Page();
            }

            if (theViewModel.Password != theViewModel.PasswordCopy)
            {
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
            return RedirectToPage("LogIn");
        }
    }
}
