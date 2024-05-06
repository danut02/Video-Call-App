using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideoCallApp.Data;
using VideoCallApp.Models;
using static System.Net.Mime.MediaTypeNames;

namespace VideoCallApp.Pages
{
    public class ForgotPasswordModel : PageModel
    {
        private VideoCallApplicationDbContext _dbContext;
        public ForgotPasswordModel(VideoCallApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [BindProperty]
        public UserViewModel theModel { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost() 
        {
            var user = new User();
            if (theModel is not null)
            {
                user = _dbContext.Users.Single(e => e.UserEmail == theModel.UserEmail);
            }
            if (user is not null)
            {
                return RedirectToPage("Show", user);
            }
            else
            {
                return Page();
            }
        }
        
    }
}
