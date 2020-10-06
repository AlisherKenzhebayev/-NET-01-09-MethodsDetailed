// <copyright file="TestBinaryGCD.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NUnitTestProject
{
    using NET_01_09_MethodsInDetails;
    using NUnit.Framework;

    [TestFixture]
    public class TestBinaryGCD
    {
        [SetUp]
        public void SetUp()
        {
        }

        [TestCase(35, -14, ExpectedResult = 7)]
        public int TestGcdTwo(int x, int y)
        {
            return new GcdFinder().BinaryGcd(x, y);
        }

        [TestCase(20, -50, 30, ExpectedResult = 10)]
        public int TestGcdThree(int x, int y, int z)
        {
            return new GcdFinder().BinaryGcd(x, y, z);
        }

        [TestCase]
        public void TestGcdArray()
        {
            var input = new[]
            {
                45, -55, -35, -25,
            };
            var expected = 5;
            Assert.AreEqual(new GcdFinder().BinaryGcd(input), expected);
        }
    }
}