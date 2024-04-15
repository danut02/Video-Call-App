using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideoCallApp.Data;
using VideoCallApp.Models;

namespace VideoCallApp.Pages
{
    public class ShowModel : PageModel
    {
        private VideoCallApplicationDbContext _dbContext;
        public ShowModel(VideoCallApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<User> theUsers { get; set; }
        public void OnGet(User theUser)
        {
            List<User> theUsersWithPasswords = new List<User>();
            theUsersWithPasswords = _dbContext.Users.Where(a => a.UserEmail == theUser.UserEmail).ToList();
            theUsers = theUsersWithPasswords;
        }
    }
}
