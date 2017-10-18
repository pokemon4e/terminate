using MilenaSapunova.TerminateContracts.Web.Controllers;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace MilenaSapunova.TerminateContracts.UnitTests.MilenaSapunova.TerminateContracts.Web.Controllers.HomeControllerTest
{
    [TestFixture]
    public class Index_Should
    {
        [TestCase]
        public void ReturnIndexDefaultView()
        {
            HomeController accountController = new HomeController();

            // Act & Assert
            accountController
                .WithCallTo(c => c.Index())
                .ShouldRenderDefaultView();
        }
    }
}
