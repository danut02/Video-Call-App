using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoCallApp.Models;
using VideoCallApp.Pages;
using VideoCallApp.Repository.Interface;

namespace VideoCallTestMock
{
    [TestClass]
    public class UpdatePasswordTest
    {
        private Mock<IUserRepository> _mockRepo;
        public UpdatePasswordModel _updateController;
        public int UsersId;
        public UserViewModel userModel;
        public User theUserToUpdatePassword;
        public string password;
        public string newPassword;
        public User theSelectedUser;
        public User finalTheUserToUpdatePassword;
        public UserViewModel userWithPasswordIncorrect;
        public string passwordIncorrectly;
        public List<User> userList;
        public UpdatePasswordTest()
        {
            _mockRepo = new Mock<IUserRepository>();
            UsersId = 2;
            userWithPasswordIncorrect = new UserViewModel()
            {
                Password = "password6",
                PasswordNew = "passwordNewQuiteNew"
            };
            passwordIncorrectly = "password6";
            userModel = new UserViewModel()
            {
                Password = "password2",
                PasswordNew = "passwordNewQuiteNew",
            };
            theUserToUpdatePassword = new User()
            {
                UserId = 2,
                FirstName = "FirstName2",
                LastName = "LastName2",
                Username = "Username2",
                Password = "password2",
                UserEmail = "mail1@mail.com",
                Gender = "Male",
                ImageId = 2
            };
            password = "password2";
            newPassword = "passwordNewQuiteNew";
            theSelectedUser = new User()
            {
                UserId = 2,
                FirstName = "FirstName2",
                LastName = "LastName2",
                Username = "Username2",
                Password = "password2",
                UserEmail = "mail1@mail.com",
                Gender = "Male",
                ImageId = 2
            };
            finalTheUserToUpdatePassword = new User()
            {
                UserId = 2,
                FirstName = "FirstName2",
                LastName = "LastName2",
                Username = "Username2",
                Password = "passwordNewQuiteNew",
                UserEmail = "mail1@mail.com",
                Gender = "Male",
                ImageId = 2
            };
            userList = new List<User>()
            {
                new User(){UserId=1,FirstName="FirstName1",LastName="LastName1",Username="Username1",Password="password1",UserEmail="mail@mail.com",Gender="Male",ImageId=2},
                new User(){UserId=2,FirstName="FirstName2",LastName="LastName2",Username="Username2",Password="password2",UserEmail="mail1@mail.com",Gender="Male",ImageId=2},
                new User(){UserId=3,FirstName="FirstName3",LastName="LastName3",Username="Username3",Password="password3",UserEmail="mail2@mail.com",Gender="Male",ImageId=2},
                new User(){UserId=4,FirstName="FirstName4",LastName="LastName4",Username="Username4",Password="password4",UserEmail="mail3@mail.com",Gender="Male",ImageId=2},
                new User(){UserId=5,FirstName="FirstName5",LastName="LastName5",Username="Username5",Password="password5",UserEmail="mail4@mail.com",Gender="Male",ImageId=2},
                new User(){UserId=6,FirstName="FirstName6",LastName="LastName6",Username="Username6",Password="password6",UserEmail="mail5@mail.com",Gender="Male",ImageId=2},
                new User(){UserId=7,FirstName="FirstName7",LastName="LastName7",Username="Username7",Password="password7",UserEmail="mail6@mail.com",Gender="Male",ImageId=2},
                new User(){UserId=8,FirstName="FirstName8",LastName="LastName8",Username="Username8",Password="password8",UserEmail="mail7@mail.com",Gender="Male",ImageId=2},
                new User(){UserId=9,FirstName="FirstName9",LastName="LastName9",Username="Username9",Password="password9",UserEmail="mail8@mail.com",Gender="Male",ImageId=2},
                new User(){UserId=10,FirstName="FirstName10",LastName="LastName10",Username="Username10",Password="password10",UserEmail="mail10@mail.com",Gender="Male",ImageId=2},
            };
        }
        [TestMethod]
        public void UpdatePassword_When_Inserting_TheOlderPassword_Correctly_And_The_NewPassword()
        {
            _mockRepo.Setup(repo => repo.GetAll()).Returns(userList);
            _mockRepo.Setup(repo => repo.GetById(UsersId)).Returns((int UserWithId) =>
            {
                return userList.Find(e=>e.UserId == UserWithId);
            });
            _mockRepo.Setup(repo => repo.UpdateUserPassword(It.IsAny<User>(),It.IsAny<string>(),It.IsAny<string>(),It.IsAny<User>())).Callback((User updateUserPassword, string pass, string newPass, User theSelection) =>
            {
                if (pass == theSelection.Password)
                {
                    updateUserPassword.Username = theSelection.Username;
                    updateUserPassword.UserEmail = theSelection.UserEmail;
                    updateUserPassword.Password = newPass;
                    updateUserPassword.Gender = theSelection.Gender;
                    updateUserPassword.FirstName = theSelection.FirstName;
                    updateUserPassword.LastName = theSelection.LastName;
                    updateUserPassword.ImageId = theSelection.ImageId;
                    updateUserPassword.UserId = theSelection.UserId;
                    int index = userList.IndexOf(theSelection);
                    userList[index]=updateUserPassword;
                }
                else
                {
                    updateUserPassword.Username = theSelection.Username;
                    updateUserPassword.UserEmail = theSelection.UserEmail;
                    updateUserPassword.Password = pass;
                    updateUserPassword.Gender = theSelection.Gender;
                    updateUserPassword.FirstName = theSelection.FirstName;
                    updateUserPassword.LastName = theSelection.LastName;
                    updateUserPassword.ImageId = theSelection.ImageId;
                    updateUserPassword.UserId = theSelection.UserId;
                    int index = userList.IndexOf(theSelection);
                    userList[index] = updateUserPassword;
                }
            });
            _updateController = new UpdatePasswordModel(_mockRepo.Object);
            _updateController.theChangedUser = userList.First(e=>e.UserId == UsersId);
            _updateController.theModel = userModel;
            var result = _updateController.OnPost();
            var obj = result as ObjectResult;
            var content = obj.Value as User;
            Assert.AreEqual(finalTheUserToUpdatePassword.Password,content.Password);
        }
        [TestMethod]
        public void UpdatePassword_When_Inserting_TheOlderPassword_Incorrectly_And_The_NewPassword()
        {
            _mockRepo.Setup(repo => repo.GetAll()).Returns(userList);
            _mockRepo.Setup(repo => repo.GetById(It.IsAny<int>())).Returns((int UserWithId) =>
            {
                return userList.Find(e => e.UserId == UserWithId);
            });
            _mockRepo.Setup(repo => repo.UpdateUserPassword(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<User>())).Callback((User updateUserPassword, string pass, string newPass, User theSelection) =>
            {
                if (pass == theSelection.Password)
                {
                    updateUserPassword.Username = theSelection.Username;
                    updateUserPassword.UserEmail = theSelection.UserEmail;
                    updateUserPassword.Password = newPass;
                    updateUserPassword.Gender = theSelection.Gender;
                    updateUserPassword.FirstName = theSelection.FirstName;
                    updateUserPassword.LastName = theSelection.LastName;
                    updateUserPassword.ImageId = theSelection.ImageId;
                    updateUserPassword.UserId = theSelection.UserId;
                    int index = userList.IndexOf(theSelection);
                    userList[index] = updateUserPassword;
                }
                else
                {
                    updateUserPassword.Username = theSelection.Username;
                    updateUserPassword.UserEmail = theSelection.UserEmail;
                    updateUserPassword.Password = pass;
                    updateUserPassword.Gender = theSelection.Gender;
                    updateUserPassword.FirstName = theSelection.FirstName;
                    updateUserPassword.LastName = theSelection.LastName;
                    updateUserPassword.ImageId = theSelection.ImageId;
                    updateUserPassword.UserId = theSelection.UserId;
                    int index = userList.IndexOf(theSelection);
                    userList[index] = updateUserPassword;
                }
            });
            _updateController = new UpdatePasswordModel(_mockRepo.Object);
            _updateController.theChangedUser = userList.First(e => e.UserId == UsersId);
            _updateController.theModel = userWithPasswordIncorrect;
            var result = _updateController.OnPost();
            var obj = result as ObjectResult;
            var content = obj.Value as User;
            Assert.AreEqual(theSelectedUser.Password, content.Password);
        }

    }
}
