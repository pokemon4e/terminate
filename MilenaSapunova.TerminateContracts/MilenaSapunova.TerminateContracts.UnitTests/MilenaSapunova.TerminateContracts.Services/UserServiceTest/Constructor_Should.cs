using MilenaSapunova.TerminateContracts.Data.Repositories;
using MilenaSapunova.TerminateContracts.Data.SaveContext;
using MilenaSapunova.TerminateContracts.Model;
using MilenaSapunova.TerminateContracts.Services;
using Moq;
using NUnit.Framework;
using System;

namespace MilenaSapunova.TerminateContracts.UnitTests.MilenaSapunova.TerminateContracts.Services.UserServiceTest
{
    [TestFixture]
    public class Constructor_Should
    {
        [TestCase]
        public void ReturnsAnInstance_WhenParametersAreNotNull()
        {
            // Arrange
            var userRepoMock = new Mock<IEfRepository<User>>();
            var contextMock = new Mock<ISaveContext>();

            // Act
            var result = new UserService(userRepoMock.Object, contextMock.Object);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestCase]
        public void ThrowsAnArgumentNullException_WhenUserRepoIsNull()
        {
            // Arrange
            var contextMock = new Mock<ISaveContext>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new UserService(null, contextMock.Object));
        }

        [TestCase]
        public void ThrowsAnArgumentNullException_WhenContextRepoIsNull()
        {
            // Arrange
            var userRepoMock = new Mock<IEfRepository<User>>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new UserService(userRepoMock.Object, null));
        }
    }
}
