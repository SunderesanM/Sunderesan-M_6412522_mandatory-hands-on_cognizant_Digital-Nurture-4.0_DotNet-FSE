using NUnit.Framework;
using Moq;
using CustomerCommLib;

namespace CustomerComm.Tests
{
    [TestFixture]
    public class CustomerCommTests
    {
        private Mock<IMailSender> _mailMock;
        private CustomerCommLib.CustomerComm _comm;

        [OneTimeSetUp]
        public void Init()
        {
            //creating the mock for IMailSender
            _mailMock = new Mock<IMailSender>();

            _mailMock
                .Setup(m => m.SendMail(
                    It.IsAny<string>(),
                    It.IsAny<string>()))
                .Returns(true);

            //inject the mock into the class under test
            _comm = new CustomerCommLib.CustomerComm(_mailMock.Object);
        }

        [TestCase]
        public void SendMailToCustomer_ShouldReturnTrue_WhenMailerSucceeds()
        {
            bool result = _comm.SendMailToCustomer();

            //assert: the method returned true
            Assert.That(result, Is.True);

            //verify that SendMail was called exactly once
            _mailMock.Verify(
                m => m.SendMail(
                    It.IsAny<string>(),
                    It.IsAny<string>()),
                Times.Once);
        }
    }
}
