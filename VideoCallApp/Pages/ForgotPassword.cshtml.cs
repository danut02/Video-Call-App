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
            var list = new List<User>();
            if (theModel is not null)
            {
                list = _dbContext.Users.Where(e => e.UserEmail == theModel.UserEmail).ToList();
            }
            if (list.Count > 0)
            {
                return RedirectToPage("Show", list.ElementAt(0));
            }
            else
            {
                return Page();
            }
        }
        
    }
}