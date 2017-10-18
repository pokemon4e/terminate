using MilenaSapunova.TerminateContracts.Data.Repositories;
using MilenaSapunova.TerminateContracts.Data.SaveContext;
using MilenaSapunova.TerminateContracts.Model;
using MilenaSapunova.TerminateContracts.Services;
using Moq;
using NUnit.Framework;

namespace MilenaSapunova.TerminateContracts.UnitTests.MilenaSapunova.TerminateContracts.Services.UserServiceTest { 

    [TestFixture]
    public class GetAll_Should
    {
        [TestCase]
        public void CallUserRepoAll_WhenCalled()
        {
            // Arrange
            var userRepoMock = new Mock<IEfRepository<User>>();
            userRepoMock.Setup(c => c.All).Verifiable();
            var contextMock = new Mock<ISaveContext>();
            var sut = new UserService(userRepoMock.Object, contextMock.Object);

            // Act
            sut.GetAll();

            // Assert
            userRepoMock.Verify();
        }
    }
}