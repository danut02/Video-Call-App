using VideoCallApp;
using VideoCallApp.Models;

namespace VideoCallTest
{
    [TestClass]
    public class LogInTesting
    {
        [TestMethod]
        public void LogInSeeingUserInDatabaseOrNot()
        {
            List<UserViewModelTest> theUserss = new List<UserViewModelTest>() {
                new UserViewModelTest{FirstName = "NameOfUser1",LastName = "LastOfUser1",Username = "coolUserThatWritesThese1",Password = "password1",UserEmail = "mail@mail2com.com"},
                new UserViewModelTest{FirstName = "NameOfUser2",LastName = "LastOfUser2",Username = "coolUserThatWritesThese2",Password = "password2",UserEmail = "mail@mail3com.com"},
                new UserViewModelTest{FirstName = "NameOfUser3",LastName = "LastOfUser3",Username = "coolUserThatWritesThese3",Password = "password3",UserEmail = "mail@mail4com.com"},
                new UserViewModelTest{FirstName = "NameOfUser4",LastName = "LastOfUser4",Username = "coolUserThatWritesThese4",Password = "password4",UserEmail = "mail@mail5com.com"},
                new UserViewModelTest{FirstName = "NameOfUser5",LastName = "LastOfUser5",Username = "coolUserThatWritesThese5",Password = "password5",UserEmail = "mail@mail6com.com"},
                new UserViewModelTest{FirstName = "NameOfUser6",LastName = "LastOfUser6",Username = "coolUserThatWritesThese6",Password = "password6",UserEmail = "mail@mail7com.com"},
                new UserViewModelTest{FirstName = "NameOfUser7",LastName = "LastOfUser7",Username = "coolUserThatWritesThese7",Password = "password7",UserEmail = "mail@mail8com.com"},
                new UserViewModelTest{FirstName = "NameOfUser8",LastName = "LastOfUser8",Username = "coolUserThatWritesThese8",Password = "password8",UserEmail = "mail@mail9com.com"},
            };
            UserViewModelTest theUserToSignIn = new UserViewModelTest()
            {
                FirstName = "NameOfUser1",
                LastName = "LastOfUser1",
                Username = "coolUserThatWritesThese2",
                Password = "password2",
                UserEmail = "mail@mail2com.com"
            };
            List<UserViewModelTest> theUserss2 = new List<UserViewModelTest>() {
                new UserViewModelTest{FirstName = "NameOfUser11",LastName = "LastOfUser11",Username = "coolUserThatWritesThese11",Password = "password11",UserEmail = "mail@mail2com.com"},
                new UserViewModelTest{FirstName = "NameOfUser12",LastName = "LastOfUser12",Username = "coolUserThatWritesThese12",Password = "password12",UserEmail = "mail@mail3com.com"},
                new UserViewModelTest{FirstName = "NameOfUser13",LastName = "LastOfUser13",Username = "coolUserThatWritesThese13",Password = "password13",UserEmail = "mail@mail4com.com"},
                new UserViewModelTest{FirstName = "NameOfUser14",LastName = "LastOfUser14",Username = "coolUserThatWritesThese14",Password = "password14",UserEmail = "mail@mail5com.com"},
                new UserViewModelTest{FirstName = "NameOfUser15",LastName = "LastOfUser15",Username = "coolUserThatWritesThese15",Password = "password15",UserEmail = "mail@mail6com.com"},
                new UserViewModelTest{FirstName = "NameOfUser16",LastName = "LastOfUser16",Username = "coolUserThatWritesThese16",Password = "password16",UserEmail = "mail@mail7com.com"},
                new UserViewModelTest{FirstName = "NameOfUser17",LastName = "LastOfUser17",Username = "coolUserThatWritesThese17",Password = "password17",UserEmail = "mail@mail8com.com"},
                new UserViewModelTest{FirstName = "NameOfUser18",LastName = "LastOfUser18",Username = "coolUserThatWritesThese18",Password = "password18",UserEmail = "mail@mail9com.com"},
            };
            UserViewModelTest theUserToSignIn2 = new UserViewModelTest()
            {
                FirstName = "NameOfUser1",
                LastName = "LastOfUser1",
                Username = "coolUserThatWritesThese112",
                Password = "password112",
                UserEmail = "mail@mail2com.com"
            };
            LogInClass theTest = new LogInClass(theUserToSignIn, theUserss);
            LogInClass theTest2 = new LogInClass(theUserToSignIn2 , theUserss2);

            var result = theTest.LogInTestingWhenUserExists();
            var result2 = theTest2.LogInTestingWhenUserExists();

            Assert.IsTrue(result);
            Assert.IsFalse(result2);
        }
    }
}
