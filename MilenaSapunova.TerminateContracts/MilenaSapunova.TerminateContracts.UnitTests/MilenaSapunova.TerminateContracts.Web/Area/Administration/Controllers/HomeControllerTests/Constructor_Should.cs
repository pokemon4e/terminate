using MilenaSapunova.TerminateContracts.Data.SaveContext;
using MilenaSapunova.TerminateContracts.Services.Contracts;
using MilenaSapunova.TerminateContracts.Web.Areas.Administration.Controllers;
using Moq;
using NUnit.Framework;
using System;

namespace MilenaSapunova.TerminateContracts.UnitTests.MilenaSapunova.TerminateContracts.Web.Area.Administration.Controllers.HomeControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [TestCase]
        public void ReturnsAnInstance_WhenParametersAreNotNull()
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();
            var contextMock = new Mock<ISaveContext>();

            // Act
            var result = new HomeController(userServiceMock.Object, contextMock.Object);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestCase]
        public void ThrowsAnArgumentNullException_WhenUserUserServiceIsNull()
        {
            // Arrange
            var contextMock = new Mock<ISaveContext>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new HomeController(null, contextMock.Object));
        }

        [TestCase]
        public void ThrowsAnArgumentNullException_WhenContextRepoIsNull()
        {
            // Arrange
            var userRepoMock = new Mock<IUserService>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new HomeController(userRepoMock.Object, null));
        }
    }
}
