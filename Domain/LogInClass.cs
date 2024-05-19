using VideoCallApp.Models;

namespace VideoCallApp
{
    public class LogInClass
    {
        public UserViewModelTest theUser { get; private set; }
        public List<UserViewModelTest> theUsers { get; set; }
        public LogInClass(UserViewModelTest user, List<UserViewModelTest> users)
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
