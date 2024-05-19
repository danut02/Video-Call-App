using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideoCallApp.Data;
using VideoCallApp.Models;
using VideoCallApp.Repository.Interface;

namespace VideoCallApp.Pages
{
    public class ShowModel : PageModel
    {
        private IUserRepository _users;
        public ShowModel(IUserRepository _userContext)
        {
            _users = _userContext;
        }
        public List<User> theUsers { get; set; }
        public void OnGet(User theUser)
        {
            List<User> theUsersWithPasswords = new List<User>();
            theUsersWithPasswords = _users.GetAll(). Where(a => a.UserEmail == theUser.UserEmail).ToList();
            theUsers = theUsersWithPasswords;
        }
    }
}
