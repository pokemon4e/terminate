using NUnit.Framework;
using Moq;
using MilenaSapunova.TerminateContracts.Data.Repositories;
using MilenaSapunova.TerminateContracts.Model;
using MilenaSapunova.TerminateContracts.Data.SaveContext;
using MilenaSapunova.TerminateContracts.Services;
using System;

namespace MilenaSapunova.TerminateContracts.UnitTests.MilenaSapunova.TerminateContracts.Services.ContractServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [TestCase]
        public void ReturnsAnInstance_WhenParametersAreValid()
        {
            // Arrange
            var contractRepoMock = new Mock<IEfRepository<Contract>>();
            var contextMock = new Mock<ISaveContext>();

            // Act
            var result = new ContractService(contractRepoMock.Object, contextMock.Object);

            // Assert
            Assert.IsNotNull(result);
        }
        
        [TestCase]
        public void ThrowsAnArgumentNullExceptionException_WhenContractRepoIsNull()
        {
            // Arrange
            var contextMock = new Mock<ISaveContext>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ContractService(null, contextMock.Object));
        }

        [TestCase]
        public void ThrowsAnArgumentNullExceptionException_WhenContextIsNull()
        {
            // Arrange
            var contractRepoMock = new Mock<IEfRepository<Contract>>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ContractService(contractRepoMock.Object, null));
        }
    }
}
