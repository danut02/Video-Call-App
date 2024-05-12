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
            public void Constructor_ShouldSetPropertiesCorrectly()
            {
                // Arrange
                string name = "Alice";
                int age = 25;
                string email = "alice@example.com";

                // Act
                var friend = new Friends(name, age, email);

                // Assert
                Assert.AreEqual(name, friend.Name);
                Assert.AreEqual(age, friend.Age);
                Assert.AreEqual(email, friend.Email);
            }
        }
    }
}