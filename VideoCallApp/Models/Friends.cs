using System.ComponentModel.DataAnnotations;

namespace VideoCallApp.Models
{
    public class Friends
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public User User { get; set; }
        public int? UserId { get; set; }

        public Friends(string name, int age, string email)
        {
            Name = name;
            Age = age;
            Email = email;
        }
    }

    public class FriendsList
    {
        private List<Friends> friends;

        public FriendsList()
        {
            friends = new List<Friends>();
        }

        public void AddFriend(Friends friend)
        {
            friends.Add(friend);
        }

        public void RemoveFriend(Friends friend)
        {
            friends.Remove(friend);
        }

        public List<Friends> GetFriends()
        {
            return friends;
        }

        public Friends GetFriendByName(string name)
        {
            return friends.Find(friend => friend.Name == name);
        }
    }
}
