using MilenaSapunova.TerminateContracts.Data.Repositories;
using MilenaSapunova.TerminateContracts.Data.SaveContext;
using MilenaSapunova.TerminateContracts.Model;
using MilenaSapunova.TerminateContracts.Services;
using Moq;
using NUnit.Framework;

namespace MilenaSapunova.TerminateContracts.UnitTests.MilenaSapunova.TerminateContracts.Services.CountryServiceTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [TestCase]
        public void CallCountryRepoAll_WhenCalled()
        {
            // Arrange
            var countryRepoMock = new Mock<IEfRepository<Country>>();
            countryRepoMock.Setup(c => c.All).Verifiable();

            var contextMock = new Mock<ISaveContext>();
            var sut = new CountryService(countryRepoMock.Object, contextMock.Object);

            // Act
            sut.GetAll();

            // Assert
            countryRepoMock.Verify();
        }
    }
}
