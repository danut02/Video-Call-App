using Microsoft.AspNetCore.Mvc;
using Moq;
using VideoCallApp.Models;
using VideoCallApp.Pages;
using VideoCallApp.Repository.Interface;

namespace VideoCallTestMock
{
    [TestClass]
    public class ForgetPasswordTest
    {
        private Mock<IUserRepository> _mockRepo;
        private ForgotPasswordModel _forgetController;
        public ForgetPasswordTest()
        {
            _mockRepo = new Mock<IUserRepository>();
        }
        [TestMethod]
        public void ForgetPassword_When_Inserting_Email_ToFindIt()
        {
            var userModel = new UserViewModel()
            {
                UserEmail = "mail2@mail.com"
            };
            var userList = new List<User>()
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
            _mockRepo.Setup(repo => repo.GetAll()).Returns(userList);
            _forgetController = new ForgotPasswordModel(_mockRepo.Object);
            _forgetController.theModel = userModel;
            var result = _forgetController.OnPost();
            var obj = result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);
        }
        [TestMethod]
        public void ForgetPassword_When_Inserting_Email_And_Is_Not_Existent()
        {
            var userModel = new UserViewModel()
            {
                UserEmail = "mail100@mail.com"
            };
            var userList = new List<User>()
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
            _mockRepo.Setup(repo => repo.GetAll()).Returns(userList);
            _forgetController = new ForgotPasswordModel(_mockRepo.Object);
            _forgetController.theModel = userModel;
            var result = _forgetController.OnPost();
            var obj = result as ObjectResult;
            Assert.AreEqual(404, obj.StatusCode);
        }
    }
}