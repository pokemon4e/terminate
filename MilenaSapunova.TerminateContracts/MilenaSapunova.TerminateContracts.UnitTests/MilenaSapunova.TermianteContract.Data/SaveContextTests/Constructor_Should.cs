using MilenaSapunova.TerminateContracts.Data.SaveContext;
using NUnit.Framework;
using System;

namespace MilenaSapunova.TerminateContracts.UnitTests.MilenaSapunova.TermianteContract.Data.SaveContextTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [TestCase]
        public void ThrowsAnArgumentNullExceptionException_WhenContextIsNull()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new SaveContext(null));
        }
    }
}
