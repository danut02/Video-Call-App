using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideoCallApp.Data;
using VideoCallApp.Models;
using VideoCallApp.Repository.Interface;
using static System.Net.Mime.MediaTypeNames;

namespace VideoCallApp.Pages
{
    public class ForgotPasswordModel : PageModel
    {
        private IUserRepository _users;
        public ForgotPasswordModel(IUserRepository theUsers)
        {
            _users=theUsers;
        }
        [BindProperty]
        public UserViewModel theModel { get; set; }
        public void OnGet()
        {
        }
        public ActionResult OnPost() 
        {
            var user = new User();
            if (theModel is not null)
            {
                try
                {
                    user = _users.GetAll().Single(e => e.UserEmail == theModel.UserEmail);
                }catch(Exception ex)
                {
                    return StatusCode(404, user);
                }
            }
            if (user is not null)
            {
                //return StatusCode(200,user);
                return RedirectToPage("Show", user);
            }
            else
            {
                return Page();
            }
        }
        
    }
}
