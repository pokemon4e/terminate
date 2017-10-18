using MilenaSapunova.TerminateContracts.Web.Controllers;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace MilenaSapunova.TerminateContracts.UnitTests.MilenaSapunova.TerminateContracts.Web.Controllers.HomeControllerTest
{
    [TestFixture]
    public class About_Should
    {
        [TestCase]
        public void ReturnAboutDefaultView()
        {
            // Arrange
            HomeController sut = new HomeController();
            
            // Act & Assert
            sut.WithCallTo(c => c.About())
                .ShouldRenderDefaultView();
        }

        [TestCase]
        public void ReturnAboutDefaultViewWithMSgInViewBag()
        {
            // Arrange
            string msg = "Your application description page.";
            HomeController sut = new HomeController();

            // Act
            sut.WithCallTo(c => c.About())
                .ShouldRenderDefaultView();

            // Assert
            Assert.AreEqual(msg, sut.ViewBag.Message);
        }
    }
}
