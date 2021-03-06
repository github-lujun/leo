using System.Net.Mail;
// <copyright file="MailHelperTest.cs" company="HP Inc.">Copyright © HP Inc. 2019</copyright>

using System;
using Leo.Lib;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Leo.Lib.Tests
{
    /// <summary>此类包含 MailHelper 的参数化单元测试</summary>
    [TestClass]
    [PexClass(typeof(MailHelper))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class MailHelperTest
    {

        /// <summary>测试 SendMail(String, String[], String, String, String, String) 的存根</summary>
        [PexMethod]
        public void SendMailTest(
            string from,
            string[] to,
            string subject,
            string body,
            string username,
            string password
        )
        {
            MailHelper.SendMail(from, to, subject, body, username, password);
            // TODO: 将断言添加到 方法 MailHelperTest.SendMailTest(String, String[], String, String, String, String)
        }

        /// <summary>测试 SendMail(MailAddress, String[], String, String, String, String) 的存根</summary>
        [PexMethod]
        public void SendMailTest01(
            MailAddress from,
            string[] to,
            string subject,
            string body,
            string username,
            string password
        )
        {
            MailHelper.SendMail(from, to, subject, body, username, password);
            // TODO: 将断言添加到 方法 MailHelperTest.SendMailTest01(MailAddress, String[], String, String, String, String)
        }
    }
}
