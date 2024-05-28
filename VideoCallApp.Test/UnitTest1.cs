using Moq;
using VideoCallApp.Models;

namespace VideoCallApp.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestFixture]
        public class FriendsTests
        {
            [Test]
            public void FriendsTestConstructor()
            {
                
                string name = "Alice";
                int age = 25;
                string email = "alice@example.com";

                
                var friend = new Friends(name, age, email);

               
                Assert.AreEqual(name, friend.Name);
                Assert.AreEqual(age, friend.Age);
                Assert.AreEqual(email, friend.Email);
            }

            [Test]
            public void AddFriend_ShouldAddFriendToList()
            {
                
                var friendsList = new FriendsList();
                var friend = new Friends("Alice", 25, "alice@example.com");

                
                friendsList.AddFriend(friend);

                
                var friends = friendsList.GetFriends();
                Assert.Contains(friend, friends);
            }

            [Test]
            public void Friends_ShouldSetUser()
            {
                var mockUser = new Mock<User>();
                var friend = new Friends("Alice", 25, "alice@example.com")
                {
                    User = mockUser.Object
                };

                Assert.AreEqual(mockUser.Object, friend.User);
            }

            [Test]
            public void FriendsList_ShouldInteractWithMockUser()
            {
                var mockUser = new Mock<User>();
                var friend = new Friends("Bob", 30, "bob@example.com")
                {
                    User = mockUser.Object
                };

                var friendsList = new FriendsList();
                friendsList.AddFriend(friend);

                var retrievedFriend = friendsList.GetFriendByName("Bob");
                Assert.AreEqual(mockUser.Object, retrievedFriend.User);
            }
        }
    }
}