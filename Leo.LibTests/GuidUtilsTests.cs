using Microsoft.VisualStudio.TestTools.UnitTesting;
using Leo.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leo.Lib.Tests
{
    [TestClass()]
    public class GuidUtilsTests
    {
        [TestMethod()]
        public void NewCombTest()
        {
            Guid guid = GuidUtils.NewComb();
            Assert.IsNotNull(guid);
        }

        [TestMethod()]
        public void GetDateFromCombTest()
        {
            Assert.Fail();
        }
    }
}