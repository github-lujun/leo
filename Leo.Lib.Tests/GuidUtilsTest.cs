// <copyright file="GuidUtilsTest.cs" company="HP Inc.">Copyright © HP Inc. 2019</copyright>
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Leo.Lib.Tests
{
    /// <summary>此类包含 GuidUtils 的参数化单元测试</summary>
    [PexClass(typeof(GuidUtils))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class GuidUtilsTest
    {
        /// <summary>测试 NewComb() 的存根</summary>
        [PexMethod]
        public Guid NewCombTest()
        {
            Guid result = GuidUtils.NewComb();
            return result;
            // TODO: 将断言添加到 方法 GuidUtilsTest.NewCombTest()
        }

        /// <summary>测试 GetDateFromComb(Guid) 的存根</summary>
        [PexMethod]
        public DateTime GetDateFromCombTest(Guid guid)
        {
            DateTime result = GuidUtils.GetDateFromComb(guid);
            return result;
            // TODO: 将断言添加到 方法 GuidUtilsTest.GetDateFromCombTest(Guid)
        }
    }
}
