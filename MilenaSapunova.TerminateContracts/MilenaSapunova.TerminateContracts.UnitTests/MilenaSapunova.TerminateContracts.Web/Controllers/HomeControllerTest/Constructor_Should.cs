using MilenaSapunova.TerminateContracts.Web.Controllers;
using NUnit.Framework;

namespace MilenaSapunova.TerminateContracts.UnitTests.MilenaSapunova.TerminateContracts.Web.Controllers.HomeControllerTest
{
    [TestFixture]
    public class Constructor_Should
    {
        [TestCase]
        public void ReturnsAnInstance()
        {
            // Arrange & Act
            var result = new HomeController();

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
