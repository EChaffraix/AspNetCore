using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using SoaWebsite.Services;

namespace Application.Tests
{
    [TestFixture]
    public class SimpleTest
    {
        [Test]
        public void NUnitWorksFine()
        {
            int result = Program.NUnitTestFunction();
            Assert.AreEqual(35, result);
        }
    }
}
