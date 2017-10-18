using MilenaSapunova.TerminateContracts.Web.Controllers;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace MilenaSapunova.TerminateContracts.UnitTests.MilenaSapunova.TerminateContracts.Web.Controllers.HomeControllerTest
{
    [TestFixture]
    public class Contact_Should
    {
        [TestCase]
        public void ReturnContactDefaultView()
        {
            // Arrange
            HomeController sut = new HomeController();

            // Act & Assert
            sut.WithCallTo(c => c.Contact())
                .ShouldRenderDefaultView();
        }

        [TestCase]
        public void ReturnContactDefaultViewWithMessageInViewBag()
        {
            // Arrange
            string msg = "Your contact page.";
            HomeController sut = new HomeController();

            // Act
            sut.WithCallTo(c => c.Contact())
                .ShouldRenderDefaultView();

            // Assert
            Assert.AreEqual(msg, sut.ViewBag.Message);
        }
    }
}
