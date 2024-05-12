using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
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
                // Arrange
                string text = "test";
                int ID = 25;
                

                // Act
                var message = new Message(ID,text);

                // Assert
                Assert.AreEqual(ID, message.ID);
                Assert.AreEqual(text, message.text);


            }
        }
    }
}