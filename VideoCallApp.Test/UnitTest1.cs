using Moq;
using NUnit.Framework;
using System;
using VideoCallApp.Models;

namespace VideoCallApp.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        public interface IMessageService
        {
            MessageModel GetMessage(int id);
            void SendMessage(MessageModel message);
        }

        [TestFixture]
        public class MessageTests
        {
            [Test]
            public void Test_GetMessage_ReturnsExpectedMessage()
            {
               
                var mockService = new Mock<IMessageService>();
                string expectedText = "Hello";
                int expectedID = 100;

                mockService.Setup(service => service.GetMessage(It.IsAny<int>()))
                    .Returns(new MessageModel { MsgID = expectedID, MsgText = expectedText });

               
                var message = mockService.Object.GetMessage(expectedID);

               
                Assert.AreEqual(expectedID, message.MsgID);
                Assert.AreEqual(expectedText, message.MsgText);
            }

            [Test]
            public void Test_SendMessage_SetsMessageProperties()
            {
               
                var mockService = new Mock<IMessageService>();
                DateTime date1 = DateTime.Now;

                MessageModel sentMessage = null;
                mockService.Setup(service => service.SendMessage(It.IsAny<MessageModel>()))
                    .Callback<MessageModel>(msg => sentMessage = msg);

                var message = new MessageModel
                {
                    MsgSendDate = date1
                };

               
                mockService.Object.SendMessage(message);

                
                Assert.IsNotNull(sentMessage);
                Assert.AreEqual(date1, sentMessage.MsgSendDate);
            }
        }
    }
}