using MilenaSapunova.TerminateContracts.Data.Repositories;
using MilenaSapunova.TerminateContracts.Data.SaveContext;
using MilenaSapunova.TerminateContracts.Model;
using MilenaSapunova.TerminateContracts.Services;
using Moq;
using NUnit.Framework;

namespace MilenaSapunova.TerminateContracts.UnitTests.MilenaSapunova.TerminateContracts.Services.ContractServiceTests
{
    [TestFixture]
    public class Update_Should
    {
        [TestCase]
        public void CallContractRepoUpdate_WhenCalled()
        {
            // Arrange
            var contract = new Contract();

            var contractRepoMock = new Mock<IEfRepository<Contract>>();
            contractRepoMock.Setup(c => c.Update(contract)).Verifiable();

            var contextMock = new Mock<ISaveContext>();
            var sut = new ContractService(contractRepoMock.Object, contextMock.Object);

            // Act
            sut.Update(contract);

            // Assert
            contractRepoMock.Verify();

        }

        [TestCase]
        public void CallContextCommit_WhenCalled()
        {
            // Arrange
            var contract = new Contract();
            var contractRepoMock = new Mock<IEfRepository<Contract>>();
            var contextMock = new Mock<ISaveContext>();
            contextMock.Setup(c => c.Commit()).Verifiable();

            var sut = new ContractService(contractRepoMock.Object, contextMock.Object);
          
            // Act
            sut.Update(contract);

            // Assert
            contractRepoMock.Verify();

        }
    }

}