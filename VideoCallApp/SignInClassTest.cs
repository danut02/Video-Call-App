using Microsoft.AspNetCore.Server.Kestrel.Transport.NamedPipes;
using VideoCallApp.Models;

namespace VideoCallApp
{
    public class SignInClassTest
    {
        public UserViewModel theUser { get; private set; }
        public List<UserViewModel> theUsers { get; set; }
        public SignInClassTest(UserViewModel user)
        {
            theUser = user;
        }
        public bool SignInTestCorect()
        {
            if (theUser.Password == theUser.PasswordCopy)
            {
                return true;
            }
            return false;
        }
        public bool SignInTestWithoutImage()
        {
            if (theUser.theImage is null)
            {
                return true;
            }
            if (theUser.theImage is null && theUser.Gender is "Male") { 
                return true;
            }
            if (theUser.theImage is null && theUser.Gender is "Female")
            {
                return true;
            }
            return false;
        }
        public bool SignInTestWithImage()
        {
            string[] arrayOfStrings = theUser.theImage.Split('.');
            string theExtension = arrayOfStrings[arrayOfStrings.Length-1];
            if (theUser.theImage is not null)
            {
                if (theExtension == "jpg" || theExtension == "jpeg" || theExtension == "png" || theExtension == "gif" || theExtension == "jfif" || theExtension == "pjpeg" || theExtension == "pjp" || theExtension == "svg" || theExtension == "bmp")
                {
                    return true;
                }
            }
            return false;
        }
        public bool SignInWithTheSameMailOrNot()
        {
            UserViewModel theFoundUser = theUsers.FirstOrDefault(e => e.UserEmail == theUser.UserEmail);
            if (theFoundUser is not null)
            {
                return true;
            }
            return false;
        }
    }
}
