using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace VideoCallApp.UnitTest
{
    public class Tests
    {
        public Message message;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}