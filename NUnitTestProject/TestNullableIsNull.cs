// <copyright file="TestNullableIsNull.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NUnitTestProject
{
    using NET_01_09_MethodsInDetails;
    using NUnit.Framework;

    [TestFixture]
    public class TestNullableIsNull
    {
        [SetUp]
        public void SetUp()
        {
        }

        [TestCase]
        public void TestIsNullInt()
        {
            int? i = null;
            Assert.IsTrue(i.IsNull());
        }

        [TestCase]
        public void TestIsNullBool()
        {
            bool? i = null;
            Assert.IsTrue(i.IsNull());
            bool? i2 = false;
            Assert.IsFalse(i2.IsNull());
        }

        [TestCase]
        public void TestIsNullString()
        {
            var name = new string("Kathy");
            Assert.IsFalse(name.IsNull());
            string name2 = null;
            Assert.IsTrue(name2.IsNull());
        }
    }
}