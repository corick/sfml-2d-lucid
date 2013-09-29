using System;
using Lucid.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Framework
{
    [TestClass]
    public class DynamicPropertiesTests
    {
        private dynamic properties;

        [TestInitialize]
        public void SetUp()
        {
            properties = new DynamicProperties();
        }

        [TestMethod]
        public void TestAssign()
        {
            properties.Test = "pass";
        }

        [TestMethod]
        public void TestAssignGet()
        {
            properties.Test2 = "pass";
            Assert.AreEqual(properties.Test2, "pass");
        }

        [TestMethod]
        [ExpectedException(typeof(Microsoft.CSharp.RuntimeBinder.RuntimeBinderException))]
        public void TestGetPropertyNotInTheTable()
        {
            dynamic x = properties.NotInTheTable;
        }
    }
}
