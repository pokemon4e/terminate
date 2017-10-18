using MilenaSapunova.TerminateContracts.Data.Repositories;
using MilenaSapunova.TerminateContracts.Data.SaveContext;
using MilenaSapunova.TerminateContracts.Model;
using MilenaSapunova.TerminateContracts.Services;
using Moq;
using NUnit.Framework;

namespace MilenaSapunova.TerminateContracts.UnitTests.MilenaSapunova.TerminateContracts.Services.TerminationNoticeServiceTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [TestCase]
        public void CallTerminationNoticeRepoAll_WhenCalled()
        {
            // Arrange
            var terminationNoticeRepoMock = new Mock<IEfRepository<TerminationNotice>>();
            terminationNoticeRepoMock.Setup(c => c.All).Verifiable();

            var contextMock = new Mock<ISaveContext>();
            var sut = new TerminationNoticeService(terminationNoticeRepoMock.Object, contextMock.Object);

            // Act
            sut.GetAll();

            // Assert
            terminationNoticeRepoMock.Verify();
        }
    }
}
