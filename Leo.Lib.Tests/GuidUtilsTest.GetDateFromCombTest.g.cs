using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// <copyright file="GuidUtilsTest.GetDateFromCombTest.g.cs" company="HP Inc.">Copyright © HP Inc. 2019</copyright>
// <auto-generated>
// 此文件包含自动生成的测试。
// 不要手动修改此文件。
// 
// 如果此文件的内容过时，你可以将它删除。
// 例如，它不再编译。
// </auto-generated>
using System;

namespace Leo.Lib.Tests
{
    public partial class GuidUtilsTest
    {

[TestMethod]
[PexGeneratedBy(typeof(GuidUtilsTest))]
public void GetDateFromCombTest713()
{
    DateTime dt;
    Guid s0
       = new Guid(default(int), (short)32, (short)32, default(byte), default(byte), 
                  default(byte), default(byte), default(byte), 
                  default(byte), default(byte), default(byte));
    dt = this.GetDateFromCombTest(s0);
}
    }
}
