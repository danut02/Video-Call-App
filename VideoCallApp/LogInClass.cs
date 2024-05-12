using VideoCallApp.Models;

namespace VideoCallApp
{
    public class LogInClass
    {
        public UserViewModel theUser { get; private set; }
        public List<UserViewModel> theUsers { get; set; }
        public LogInClass(UserViewModel user, List<UserViewModel> users)
        {
            theUsers = users;
            theUser = user;
        }
        public bool LogInTestingWhenUserExists()
        {
            if (theUsers.Where(e => e.Password == theUser.Password && e.Username == theUser.Username).Any() is true) 
            {
                return true;    
            }
            return false;
        }
    }
}
