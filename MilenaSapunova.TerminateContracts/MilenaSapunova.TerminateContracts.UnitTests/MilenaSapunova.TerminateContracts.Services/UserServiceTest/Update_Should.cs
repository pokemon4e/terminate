using MilenaSapunova.TerminateContracts.Data.Repositories;
using MilenaSapunova.TerminateContracts.Data.SaveContext;
using MilenaSapunova.TerminateContracts.Model;
using MilenaSapunova.TerminateContracts.Services;
using Moq;
using NUnit.Framework;

namespace MilenaSapunova.TerminateContracts.UnitTests.MilenaSapunova.TerminateContracts.Services.UserServiceTest
{
    [TestFixture]
    public class Update_Should
    {
        [TestCase]
        public void CallUserRepoUpdate_WhenCalled()
        {
            // Arrange
            var user = new User();
            var userRepoMock = new Mock<IEfRepository<User>>();
            userRepoMock.Setup(c => c.Update(user)).Verifiable();
            var contextMock = new Mock<ISaveContext>();
            var sut = new UserService(userRepoMock.Object, contextMock.Object);

            // Act
            sut.Update(user);

            // Assert
            userRepoMock.Verify();
        }

        [TestCase]
        public void CallUserCommit_WhenCalled()
        {
            // Arrange
            var user = new User();
            var userRepoMock = new Mock<IEfRepository<User>>();
            var contextMock = new Mock<ISaveContext>();
            contextMock.Setup(c => c.Commit()).Verifiable();
            var sut = new UserService(userRepoMock.Object, contextMock.Object);

            // Act
            sut.Update(user);

            // Assert
            userRepoMock.Verify();
        }
    }
}