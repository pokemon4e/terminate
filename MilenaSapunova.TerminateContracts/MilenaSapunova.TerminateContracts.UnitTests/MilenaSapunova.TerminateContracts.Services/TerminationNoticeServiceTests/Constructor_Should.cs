using NUnit.Framework;
using Moq;
using MilenaSapunova.TerminateContracts.Data.Repositories;
using MilenaSapunova.TerminateContracts.Model;
using MilenaSapunova.TerminateContracts.Data.SaveContext;
using MilenaSapunova.TerminateContracts.Services;
using System;

namespace MilenaSapunova.TerminateContracts.UnitTests.MilenaSapunova.TerminateContracts.Services.TerminationNoticeServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [TestCase]
        public void ReturnsAnInstance_WhenParametersAreValid()
        {
            // Arrange
            var terminationNoticeRepoMock = new Mock<IEfRepository<TerminationNotice>>();
            var contextMock = new Mock<ISaveContext>();

            // Act
            var result = new TerminationNoticeService(terminationNoticeRepoMock.Object, contextMock.Object);

            // Assert
            Assert.IsNotNull(result);
        }
        
        [TestCase]
        public void ThrowsAnArgumentNullExceptionException_WhenContractRepoIsNull()
        {
            // Arrange
            var contextMock = new Mock<ISaveContext>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new TerminationNoticeService(null, contextMock.Object));
        }

        [TestCase]
        public void ThrowsAnArgumentNullExceptionException_WhenContextIsNull()
        {
            // Arrange
            var terminationNoticeRepoMock = new Mock<IEfRepository<TerminationNotice>>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new TerminationNoticeService(terminationNoticeRepoMock.Object, null));
        }
    }
}
