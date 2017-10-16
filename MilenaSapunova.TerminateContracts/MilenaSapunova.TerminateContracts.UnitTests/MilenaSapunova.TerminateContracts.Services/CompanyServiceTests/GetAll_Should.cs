using MilenaSapunova.TerminateContracts.Data.Repositories;
using MilenaSapunova.TerminateContracts.Data.SaveContext;
using MilenaSapunova.TerminateContracts.Model;
using MilenaSapunova.TerminateContracts.Services;
using Moq;
using NUnit.Framework;

namespace MilenaSapunova.TerminateContracts.UnitTests.MilenaSapunova.TerminateContracts.Services.CompanyServiceTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [TestCase]
        public void CallCompanyRepoAll_WhenCalled()
        {
            // Arrange
            var companyRepoMock = new Mock<IEfRepository<Company>>();
            companyRepoMock.Setup(c => c.All).Verifiable();

            var contextMock = new Mock<ISaveContext>();
            var sut = new CompanyService(companyRepoMock.Object, contextMock.Object);

            // Act
            sut.GetAll();

            // Assert
            companyRepoMock.Verify();
        }
    }
}
