using VideoCallApp.Models;

namespace VideoCallApp.Repository.Interface
{
    public interface IUserRepository
    {
        void AddUser(User theUserToAdd);
        List<User> GetAll();
        User GetById(int id);
        void UpdateUserPassword(User theUserToUpdatePassword, string password, string newPassword, User theSelectedUser);
    }
}
