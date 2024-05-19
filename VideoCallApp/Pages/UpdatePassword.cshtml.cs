using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideoCallApp.Models;
using VideoCallApp.Data;
using Microsoft.AspNetCore.SignalR;
using VideoCallApp.Repository.Interface;

namespace VideoCallApp.Pages
{
    public class UpdatePasswordModel : PageModel
    {
        private IUserRepository _users;
        public UpdatePasswordModel(IUserRepository _usersContext)
        {
            _users = _usersContext;
        }
        [BindProperty]
        public UserViewModel theModel {  get; set; }
        [BindProperty]
        public User theChangedUser {  get; set; }
        public void OnGet(int UserId)
        {
            theChangedUser = _users.GetById(UserId);
        }
        public IActionResult OnPost()
        {
            User theUserToChange = new User();
            User theSelectedUser = new User();
            List<User> Users = _users.GetAll();
            if (theModel is not null)
            {
                theSelectedUser = _users.GetById(theChangedUser.UserId);
                theUserToChange = _users.GetById(theChangedUser.UserId);
                if (Users.Where(e => e.Password == theModel.Password && e.UserId == theSelectedUser.UserId).Any())
                {
                    _users.UpdateUserPassword(theUserToChange,theModel.Password,theModel.PasswordNew, theSelectedUser);
                }
            }
            theSelectedUser = _users.GetById(theChangedUser.UserId);
            return StatusCode(200, theSelectedUser);
            //return RedirectToPage("VideoCallProfile", theUserToChange);
        }
    }
}
