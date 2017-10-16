using MilenaSapunova.TerminateContracts.Data.Repositories;
using MilenaSapunova.TerminateContracts.Data.SaveContext;
using MilenaSapunova.TerminateContracts.Model;
using MilenaSapunova.TerminateContracts.Services;
using Moq;
using NUnit.Framework;

namespace MilenaSapunova.TerminateContracts.UnitTests.MilenaSapunova.TerminateContracts.Services.ContractServiceTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [TestCase]
        public void CallContractRepoAll_WhenCalled()
        {
            // Arrange
            var contractRepoMock = new Mock<IEfRepository<Contract>>();
            contractRepoMock.Setup(c => c.All).Verifiable();

            var contextMock = new Mock<ISaveContext>();
            var sut = new ContractService(contractRepoMock.Object, contextMock.Object);

            // Act
            sut.GetAll();

            // Assert
            contractRepoMock.Verify();
        }
    }
}
