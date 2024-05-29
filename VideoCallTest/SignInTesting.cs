using Microsoft.VisualStudio.TestTools.UnitTesting;
using VideoCallApp.Models;
using VideoCallApp;
using System.Diagnostics;
namespace VideoCallTest
{
    [TestClass]
    public class SignInTesting
    {
        [TestMethod]
        public void SignInTestCorect_And_IncorectPassword()
        {
            UserViewModelTest theUser = new UserViewModelTest()
            {
                FirstName = "NameOfUser",
                LastName = "LastOfUser",
                Username = "coolUserThatWritesThese",
                Password = "password",
                PasswordCopy = "password",
                UserEmail = "mail@mail2com.com",
                Gender = "Male",
            };
            UserViewModelTest theUser2 = new UserViewModelTest()
            {
                FirstName = "NameOfUser",
                LastName = "LastOfUser",
                Username = "coolUserThatWritesThese",
                Password = "password",
                PasswordCopy = "passwordCopy",
                UserEmail = "mail@mail2com.com",
                Gender = "Male",
            };
            SignInClassTest theTest = new SignInClassTest(theUser);
            SignInClassTest theNextTest = new SignInClassTest(theUser2);
            
            var result = theTest.SignInTestCorect();
            var result2 = theNextTest.SignInTestCorect();

            Assert.IsTrue(result);
            Assert.IsFalse(result2);
        }
        [TestMethod]
        public void SignInWithout_Image()
        {
            UserViewModelTest theUser = new UserViewModelTest()
            {
                FirstName = "NameOfUser",
                LastName = "LastOfUser",
                Username = "coolUserThatWritesThese",
                Password = "password",
                PasswordCopy = "passwordCopy",
                UserEmail = "mail@mail2com.com",
                Gender = "Male",
                theImage = null,
            };
            UserViewModelTest theUser2 = new UserViewModelTest()
            {
                FirstName = "NameOfUser",
                LastName = "LastOfUser",
                Username = "coolUserThatWritesThese",
                Password = "password",
                PasswordCopy = "passwordCopy",
                UserEmail = "mail@mail2com.com",
                Gender = "Female",
                theImage = null,
            };
            UserViewModelTest theUser3 = new UserViewModelTest()
            {
                FirstName = "NameOfUser",
                LastName = "LastOfUser",
                Username = "coolUserThatWritesThese",
                Password = "password",
                PasswordCopy = "passwordCopy",
                UserEmail = "mail@mail2com.com",
                Gender = "Female",
                theImage = "null.jpg",
            };
            SignInClassTest theTest = new SignInClassTest(theUser);
            SignInClassTest theTest2 = new SignInClassTest(theUser2);
            SignInClassTest theTest3 = new SignInClassTest(theUser3);

            var result = theTest.SignInTestWithoutImage();
            var result2 = theTest2.SignInTestWithoutImage();
            var result3 = theTest3.SignInTestWithoutImage();

            Assert.IsTrue(result);
            Assert.IsTrue(result2);
            Assert.IsFalse(result3);
        }
        [TestMethod]
        public void SignIn_WithImages()
        {
            var theUser = new UserViewModelTest()
            {
                FirstName = "NameOfUser",
                LastName = "LastOfUser",
                Username = "coolUserThatWritesThese",
                Password = "password",
                PasswordCopy = "passwordCopy",
                UserEmail = "mail@mail2com.com",
                Gender = "Male",
                theImage = "null.jpg",
            };
            var theUser2 = new UserViewModelTest()
            {
                FirstName = "NameOfUser",
                LastName = "LastOfUser",
                Username = "coolUserThatWritesThese",
                Password = "password",
                PasswordCopy = "passwordCopy",
                UserEmail = "mail@mail2com.com",
                Gender = "Male",
                theImage = "null.pdf",
            };
            var theUser3 = new UserViewModelTest()
            {
                FirstName = "NameOfUser",
                LastName = "LastOfUser",
                Username = "coolUserThatWritesThese",
                Password = "password",
                PasswordCopy = "passwordCopy",
                UserEmail = "mail@mail2com.com",
                Gender = "Male",
                theImage = "null.png",
            };
            var theUser4 = new UserViewModelTest()
            {
                FirstName = "NameOfUser",
                LastName = "LastOfUser",
                Username = "coolUserThatWritesThese",
                Password = "password",
                PasswordCopy = "passwordCopy",
                UserEmail = "mail@mail2com.com",
                Gender = "Female",
                theImage = "FemaleSexSymbol.png",
            };
            var test = new SignInClassTest(theUser);
            var test2 = new SignInClassTest(theUser2);
            var test3 = new SignInClassTest(theUser3);
            var test4 = new SignInClassTest(theUser4);

            var result = test.SignInTestWithImage();
            var result2 = test2.SignInTestWithImage();
            var result3 = test3.SignInTestWithImage();
            var result4 = test4.SignInTestWithImage();

            Assert.IsTrue(result);
            Assert.IsFalse(result2);
            Assert.IsTrue(result3);
            Assert.IsTrue(result4);
        }
        [TestMethod]
        public void SignIn_WithTheSameMailOrNot()
        {
            List<UserViewModelTest> theUserss = new List<UserViewModelTest>() {
                new UserViewModelTest{FirstName = "NameOfUser",LastName = "LastOfUser",Username = "coolUserThatWritesThese",Password = "password",PasswordCopy = "password",UserEmail = "mail@mail2com.com"},
                new UserViewModelTest{FirstName = "NameOfUser",LastName = "LastOfUser",Username = "coolUserThatWritesThese",Password = "password",PasswordCopy = "password",UserEmail = "mail@mail3com.com"},
                new UserViewModelTest{FirstName = "NameOfUser",LastName = "LastOfUser",Username = "coolUserThatWritesThese",Password = "password",PasswordCopy = "password",UserEmail = "mail@mail4com.com"},
                new UserViewModelTest{FirstName = "NameOfUser",LastName = "LastOfUser",Username = "coolUserThatWritesThese",Password = "password",PasswordCopy = "password",UserEmail = "mail@mail5com.com"},
                new UserViewModelTest{FirstName = "NameOfUser",LastName = "LastOfUser",Username = "coolUserThatWritesThese",Password = "password",PasswordCopy = "password",UserEmail = "mail@mail6com.com"},
                new UserViewModelTest{FirstName = "NameOfUser",LastName = "LastOfUser",Username = "coolUserThatWritesThese",Password = "password",PasswordCopy = "password",UserEmail = "mail@mail7com.com"},
                new UserViewModelTest{FirstName = "NameOfUser",LastName = "LastOfUser",Username = "coolUserThatWritesThese",Password = "password",PasswordCopy = "password",UserEmail = "mail@mail8com.com"},
                new UserViewModelTest{FirstName = "NameOfUser",LastName = "LastOfUser",Username = "coolUserThatWritesThese",Password = "password",PasswordCopy = "password",UserEmail = "mail@mail9com.com"},
            };
            UserViewModelTest theUserToSignIn = new UserViewModelTest()
            {
                FirstName = "NameOfUser",
                LastName = "LastOfUser",
                Username = "coolUserThatWritesThese",
                Password = "password",
                PasswordCopy = "password",
                UserEmail = "mail@mail2com.com"
            };
            List<UserViewModelTest> theUserss2 = new List<UserViewModelTest>() {
                new UserViewModelTest{FirstName = "NameOfUser",LastName = "LastOfUser",Username = "coolUserThatWritesThese",Password = "password",PasswordCopy = "password",UserEmail = "mail@mail2com.com"},
                new UserViewModelTest{FirstName = "NameOfUser",LastName = "LastOfUser",Username = "coolUserThatWritesThese",Password = "password",PasswordCopy = "password",UserEmail = "mail@mail3com.com"},
                new UserViewModelTest{FirstName = "NameOfUser",LastName = "LastOfUser",Username = "coolUserThatWritesThese",Password = "password",PasswordCopy = "password",UserEmail = "mail@mail4com.com"},
                new UserViewModelTest{FirstName = "NameOfUser",LastName = "LastOfUser",Username = "coolUserThatWritesThese",Password = "password",PasswordCopy = "password",UserEmail = "mail@mail5com.com"},
                new UserViewModelTest{FirstName = "NameOfUser",LastName = "LastOfUser",Username = "coolUserThatWritesThese",Password = "password",PasswordCopy = "password",UserEmail = "mail@mail6com.com"},
                new UserViewModelTest{FirstName = "NameOfUser",LastName = "LastOfUser",Username = "coolUserThatWritesThese",Password = "password",PasswordCopy = "password",UserEmail = "mail@mail7com.com"},
                new UserViewModelTest{FirstName = "NameOfUser",LastName = "LastOfUser",Username = "coolUserThatWritesThese",Password = "password",PasswordCopy = "password",UserEmail = "mail@mail8com.com"},
                new UserViewModelTest{FirstName = "NameOfUser",LastName = "LastOfUser",Username = "coolUserThatWritesThese",Password = "password",PasswordCopy = "password",UserEmail = "mail@mail9com.com"},
            };
            UserViewModelTest theUserToSignIn2 = new UserViewModelTest()
            {
                FirstName = "NameOfUser",
                LastName = "LastOfUser",
                Username = "coolUserThatWritesThese",
                Password = "password",
                PasswordCopy = "password",
                UserEmail = "mail@mail20com.com"
            };
            SignInClassTest theTest = new SignInClassTest(theUserToSignIn);
            theTest.theUsers = theUserss;
            SignInClassTest theTest2 = new SignInClassTest(theUserToSignIn2);
            theTest2.theUsers = theUserss2;

            var result = theTest.SignInWithTheSameMailOrNot();
            var result2 = theTest2.SignInWithTheSameMailOrNot();

            Assert.IsTrue(result);
            Assert.IsFalse(result2);
        }
    }
}