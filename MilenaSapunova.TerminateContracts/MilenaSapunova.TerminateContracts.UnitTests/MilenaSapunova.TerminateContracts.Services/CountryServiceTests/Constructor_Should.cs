using NUnit.Framework;
using Moq;
using MilenaSapunova.TerminateContracts.Data.Repositories;
using MilenaSapunova.TerminateContracts.Model;
using MilenaSapunova.TerminateContracts.Data.SaveContext;
using MilenaSapunova.TerminateContracts.Services;
using System;

namespace MilenaSapunova.TerminateContracts.UnitTests.MilenaSapunova.TerminateContracts.Services.CountryServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [TestCase]
        public void ReturnsAnInstance_WhenParametersAreValid()
        {
            // Arrange
            var countryRepoMock = new Mock<IEfRepository<Country>>();
            var contextMock = new Mock<ISaveContext>();

            // Act
            var result = new CountryService(countryRepoMock.Object, contextMock.Object);

            // Assert
            Assert.IsNotNull(result);
        }
        
        [TestCase]
        public void ThrowsAnArgumentNullExceptionException_WhenContractRepoIsNull()
        {
            // Arrange
            var contextMock = new Mock<ISaveContext>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new CountryService(null, contextMock.Object));
        }

        [TestCase]
        public void ThrowsAnArgumentNullExceptionException_WhenContextIsNull()
        {
            // Arrange
            var countryRepoMock = new Mock<IEfRepository<Country>>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new CountryService(countryRepoMock.Object, null));
        }
    }
}
