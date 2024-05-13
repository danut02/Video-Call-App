using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
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
        public class MessageTests
        {
            [Test]
            public void Test1()
            {
                string expectedText = "test";
                int expectedID = 25;

                // Act
                var message = new MessageModel
                {
                    MsgID = expectedID,
                    MsgText = expectedText
                };

                // Assert
                Assert.AreEqual(expectedID, message.MsgID);
                Assert.AreEqual(expectedText, message.MsgText);


            }
            [Test]
            public void Test2()
            {

                DateTime date1= DateTime.Now;
                var message = new MessageModel
                {

                    MsgSendDate = date1
                };
                Assert.AreEqual(date1, message.MsgSendDate);
            }
        }
    }
}