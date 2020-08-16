using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaekJoon.Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaekJoon.Problems.Tests
{
    [TestClass()]
    public class P10817Tests
    {
        [TestMethod()]
        public void Sol10817Test()
        {
            Assert.AreEqual("20", P10817.Instance.GetMiddleNumber(20, 30, 10));
            Assert.AreEqual("30", P10817.Instance.GetMiddleNumber(30, 30, 10));
            Assert.AreEqual("40", P10817.Instance.GetMiddleNumber(40, 40, 40));
            Assert.AreEqual("10", P10817.Instance.GetMiddleNumber(20, 10, 10));
        }
    }
}