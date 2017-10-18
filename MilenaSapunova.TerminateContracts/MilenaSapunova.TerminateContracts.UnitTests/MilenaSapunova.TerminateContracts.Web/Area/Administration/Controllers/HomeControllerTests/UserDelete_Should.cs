using MilenaSapunova.TerminateContracts.Data.SaveContext;
using MilenaSapunova.TerminateContracts.Services.Contracts;
using MilenaSapunova.TerminateContracts.Web.Areas.Administration.Controllers;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace MilenaSapunova.TerminateContracts.UnitTests.MilenaSapunova.TerminateContracts.Web.Area.Administration.Controllers.HomeControllerTests
{
    [TestFixture]
    public class UserDelete_Should
    {
        [TestCase]
        public void ReturnIndexDefaultView()
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();
            var contextMock = new Mock<ISaveContext>();
            HomeController accountController = new HomeController(userServiceMock.Object, contextMock.Object);

            // Act & Assert
            accountController
                .WithCallTo(c => c.UserDelete(null))
                .ShouldReturnJson();
        }
    }
}
