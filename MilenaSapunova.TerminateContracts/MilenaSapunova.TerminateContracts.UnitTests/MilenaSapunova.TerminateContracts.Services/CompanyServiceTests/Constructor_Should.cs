using NUnit.Framework;
using Moq;
using MilenaSapunova.TerminateContracts.Data.Repositories;
using MilenaSapunova.TerminateContracts.Model;
using MilenaSapunova.TerminateContracts.Data.SaveContext;
using MilenaSapunova.TerminateContracts.Services;
using System;

namespace MilenaSapunova.TerminateContracts.UnitTests.MilenaSapunova.TerminateContracts.Services.CompanyServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [TestCase]
        public void ReturnsAnInstance_WhenParametersAreValid()
        {
            // Arrange
            var companyRepoMock = new Mock<IEfRepository<Company>>();
            var contextMock = new Mock<ISaveContext>();

            // Act
            var result = new CompanyService(companyRepoMock.Object, contextMock.Object);

            // Assert
            Assert.IsNotNull(result);
        }
        
        [TestCase]
        public void ThrowsAnArgumentNullExceptionException_WhenCompanyRepoIsNull()
        {
            // Arrange
            var contextMock = new Mock<ISaveContext>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new CompanyService(null, contextMock.Object));
        }

        [TestCase]
        public void ThrowsAnArgumentNullExceptionException_WhenContextIsNull()
        {
            // Arrange
            var companyRepoMock = new Mock<IEfRepository<Company>>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new CompanyService(companyRepoMock.Object, null));
        }
    }
}
