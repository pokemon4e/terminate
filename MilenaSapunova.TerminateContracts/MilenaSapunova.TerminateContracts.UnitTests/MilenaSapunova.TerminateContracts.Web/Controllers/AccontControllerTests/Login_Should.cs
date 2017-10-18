using MilenaSapunova.TerminateContracts.Auth.Contracts;
using MilenaSapunova.TerminateContracts.Services.Contracts;
using MilenaSapunova.TerminateContracts.Web.Controllers;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;


namespace MilenaSapunova.TerminateContracts.UnitTests.MilenaSapunova.TerminateContracts.Web.Controllers.AccontControllerTests
{
    [TestFixture]
    public class Login_Should
    {
        [TestCase]
        public void ReturnLoginDefaultView()
        {
            // Arrange
            var signInServiceMock = new Mock<ISignInService>();
            var userManager = new Mock<IUserManager>();
            var userServiceMock = new Mock<IUserService>();
            var returnUrl = "url";

            AccountController accountController = new AccountController(
                signInServiceMock.Object,
                userManager.Object,
                userServiceMock.Object);

            // Act & Assert
            accountController
                .WithCallTo(c => c.Login(returnUrl))
                .ShouldRenderDefaultView();
        }

        [TestCase]
        public void ReturnLoginDefaultViewWithUrlInViewBag()
        {
            // Arrange
            var signInServiceMock = new Mock<ISignInService>();
            var userManager = new Mock<IUserManager>();
            var userServiceMock = new Mock<IUserService>();

            string returnUrl = "url";

            AccountController accountController = new AccountController(
                signInServiceMock.Object,
                userManager.Object,
                userServiceMock.Object);

            // Act
            accountController
               .WithCallTo(c => c.Login(returnUrl))
               .ShouldRenderDefaultView();

            // Act
            Assert.AreEqual(returnUrl, accountController.ViewBag.ReturnUrl);
        }
    }
}