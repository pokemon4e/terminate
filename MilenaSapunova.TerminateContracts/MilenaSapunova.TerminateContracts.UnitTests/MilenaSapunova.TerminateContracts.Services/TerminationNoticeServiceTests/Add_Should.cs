using MilenaSapunova.TerminateContracts.Data.Repositories;
using MilenaSapunova.TerminateContracts.Data.SaveContext;
using MilenaSapunova.TerminateContracts.Model;
using MilenaSapunova.TerminateContracts.Services;
using Moq;
using NUnit.Framework;


namespace MilenaSapunova.TerminateContracts.UnitTests.MilenaSapunova.TerminateContracts.Services.TerminationNoticeServiceTests
{
    [TestFixture]
    public class Add_Should
    {
        [TestCase]
        public void CallTerminationNoticeRepoAdd_WhenCalled()
        {
            // Arrange
            var terminationNotice = new TerminationNotice();

            var terminationNoticeRepoMock = new Mock<IEfRepository<TerminationNotice>>();
            terminationNoticeRepoMock.Setup(c => c.Add(terminationNotice)).Verifiable();

            var contextMock = new Mock<ISaveContext>();
            var sut = new TerminationNoticeService(terminationNoticeRepoMock.Object, contextMock.Object);

            // Act
            sut.Add(terminationNotice);

            // Assert
            terminationNoticeRepoMock.Verify();
        }

       
        [TestCase]
        public void CallContextCommit_WhenCalled()
        {
            // Arrange
            var terminationNotice = new TerminationNotice();
            var terminationNoticeRepoMock = new Mock<IEfRepository<TerminationNotice>>();
            var contextMock = new Mock<ISaveContext>();
            contextMock.Setup(c => c.Commit()).Verifiable();

            var sut = new TerminationNoticeService(terminationNoticeRepoMock.Object, contextMock.Object);

            // Act
            sut.Update(terminationNotice);

            // Assert
            terminationNoticeRepoMock.Verify();

        }
    }
}
