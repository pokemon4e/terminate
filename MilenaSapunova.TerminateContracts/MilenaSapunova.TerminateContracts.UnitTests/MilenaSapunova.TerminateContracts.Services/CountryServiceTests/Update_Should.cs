using MilenaSapunova.TerminateContracts.Data.Repositories;
using MilenaSapunova.TerminateContracts.Data.SaveContext;
using MilenaSapunova.TerminateContracts.Model;
using MilenaSapunova.TerminateContracts.Services;
using Moq;
using NUnit.Framework;

namespace MilenaSapunova.TerminateContracts.UnitTests.MilenaSapunova.TerminateContracts.Services.CountryServiceTests
{
    [TestFixture]
    public class Update_Should
    {
        [TestCase]
        public void CallCountrytRepoUpdate_WhenCalled()
        {
            // Arrange
            var country = new Country();

            var countryRepoMock = new Mock<IEfRepository<Country>>();
            countryRepoMock.Setup(c => c.Update(country)).Verifiable();

            var contextMock = new Mock<ISaveContext>();
            var sut = new CountryService(countryRepoMock.Object, contextMock.Object);

            // Act
            sut.Update(country);

            // Assert
            countryRepoMock.Verify();

        }

        [TestCase]
        public void CallContextCommit_WhenCalled()
        {
            // Arrange
            var country = new Country();
            var countryRepoMock = new Mock<IEfRepository<Country>>();
            var contextMock = new Mock<ISaveContext>();
            contextMock.Setup(c => c.Commit()).Verifiable();

            var sut = new CountryService(countryRepoMock.Object, contextMock.Object);
          
            // Act
            sut.Update(country);

            // Assert
            countryRepoMock.Verify();

        }
    }

}