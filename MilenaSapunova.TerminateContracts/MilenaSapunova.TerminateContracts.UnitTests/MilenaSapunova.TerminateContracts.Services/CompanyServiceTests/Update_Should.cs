using MilenaSapunova.TerminateContracts.Data.Repositories;
using MilenaSapunova.TerminateContracts.Data.SaveContext;
using MilenaSapunova.TerminateContracts.Model;
using MilenaSapunova.TerminateContracts.Services;
using Moq;
using NUnit.Framework;

namespace MilenaSapunova.TerminateContracts.UnitTests.MilenaSapunova.TerminateContracts.Services.CompanyServiceTests
{
    [TestFixture]
    public class Update_Should
    {
        [TestCase]
        public void CallCompanyRepoUpdate_WhenCalled()
        {
            // Arrange
            var company = new Company();

            var companyRepoMock = new Mock<IEfRepository<Company>>();
            companyRepoMock.Setup(c => c.Update(company)).Verifiable();

            var contextMock = new Mock<ISaveContext>();
            var sut = new CompanyService(companyRepoMock.Object, contextMock.Object);

            // Act
            sut.Update(company);

            // Assert
            companyRepoMock.Verify();

        }

        [TestCase]
        public void CallContextCommit_WhenCalled()
        {
            // Arrange
            var company = new Company();
            var companyRepoMock = new Mock<IEfRepository<Company>>();
            var contextMock = new Mock<ISaveContext>();
            contextMock.Setup(c => c.Commit()).Verifiable();

            var sut = new CompanyService(companyRepoMock.Object, contextMock.Object);
          
            // Act
            sut.Update(company);

            // Assert
            companyRepoMock.Verify();

        }
    }

}