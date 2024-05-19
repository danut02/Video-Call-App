using Microsoft.EntityFrameworkCore;
using VideoCallApp.Data;
using VideoCallApp.Models;
using VideoCallApp.Repository.Interface;

namespace VideoCallApp.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly VideoCallApplicationDbContext _applicationDb;
        public UserRepository(VideoCallApplicationDbContext applicationDbContext) {
            _applicationDb = applicationDbContext;
        }
        public void AddUser(User theUserToAdd)
        {
            _applicationDb.Users.Add(theUserToAdd);
            _applicationDb.SaveChanges();
        }
        public List<User> GetAll()
        {
            List<User> listUser = new List<User>(_applicationDb.Users);
            return listUser;
        }
        public User GetById(int id) 
        {
            User userById = new User();
            userById = _applicationDb.Users.Find(id);
            return userById;
        }
        public void UpdateUserPassword(User theUserToUpdatePassword,string password,string newPassword,User theSelectedUser)
        {
            if (password == theSelectedUser.Password)
            {

                theUserToUpdatePassword.Username = theSelectedUser.Username;
                theUserToUpdatePassword.UserEmail = theSelectedUser.UserEmail;
                theUserToUpdatePassword.Password = newPassword;
                theUserToUpdatePassword.Gender = theSelectedUser.Gender;
                theUserToUpdatePassword.FirstName = theSelectedUser.FirstName;
                theUserToUpdatePassword.LastName = theSelectedUser.LastName;
                theUserToUpdatePassword.ImageId = theSelectedUser.ImageId;
                theUserToUpdatePassword.UserId = theSelectedUser.UserId;
                _applicationDb.SaveChanges();
            }
            else
            {
                theUserToUpdatePassword.Username = theSelectedUser.Username;
                theUserToUpdatePassword.UserEmail = theSelectedUser.UserEmail;
                theUserToUpdatePassword.Password = password;
                theUserToUpdatePassword.Gender = theSelectedUser.Gender;
                theUserToUpdatePassword.FirstName = theSelectedUser.FirstName;
                theUserToUpdatePassword.LastName = theSelectedUser.LastName;
                theUserToUpdatePassword.ImageId = theSelectedUser.ImageId;
                theUserToUpdatePassword.UserId = theSelectedUser.UserId;
                _applicationDb.SaveChanges();
            }
        }
    }
}
