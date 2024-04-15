using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideoCallApp.Models;
using VideoCallApp.Data;
using Microsoft.AspNetCore.SignalR;

namespace VideoCallApp.Pages
{
    public class UpdatePasswordModel : PageModel
    {
        private VideoCallApplicationDbContext _dbContext;
        public UpdatePasswordModel(VideoCallApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [BindProperty]
        public UserViewModel theModel {  get; set; }
        [BindProperty]
        public User theChangedUser {  get; set; }
        public void OnGet(int UserId)
        {
            theChangedUser = _dbContext.Users.Find(UserId);
        }
        public IActionResult OnPost()
        {
            var theUserToChange = new User();
            var theSelectedUser = new User();
            theSelectedUser = _dbContext.Users.Find(theChangedUser.UserId);
            theUserToChange = _dbContext.Users.Find(theChangedUser.UserId);
            if (theModel is not null)
            {
                if( theModel.Password == theSelectedUser.Password ) {

                    theUserToChange.Username = theSelectedUser.Username;
                    theUserToChange.UserEmail = theSelectedUser.UserEmail;
                    theUserToChange.Password = theModel.PasswordNew;
                    theUserToChange.Gender = theSelectedUser.Gender;
                    theUserToChange.FirstName = theSelectedUser.FirstName;
                    theUserToChange.LastName = theSelectedUser.LastName;
                    theUserToChange.ImageId = theSelectedUser.ImageId;
                    theUserToChange.UserId = theSelectedUser.UserId;
                    _dbContext.SaveChanges();
                }
                else
                {
                    theUserToChange.Username = theSelectedUser.Username;
                    theUserToChange.UserEmail = theSelectedUser.UserEmail;
                    theUserToChange.Password = theModel.Password;
                    theUserToChange.Gender = theSelectedUser.Gender;
                    theUserToChange.FirstName = theSelectedUser.FirstName;
                    theUserToChange.LastName = theSelectedUser.LastName;
                    theUserToChange.ImageId = theSelectedUser.ImageId;
                    theUserToChange.UserId = theSelectedUser.UserId;
                    _dbContext.SaveChanges();
                }
            }
            return RedirectToPage("VideoCallProfile", theUserToChange);
        }
    }
}
