using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaekJoon.Problems;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaekJoon.Problems.Tests
{
    [TestClass()]
    public class P1074Tests
    {
        [TestMethod()]
        public void GetOrderTest()
        {
            Assert.AreEqual(11, P1074.Instance.GetOrder(2, 3, 1));
            Assert.AreEqual(63, P1074.Instance.GetOrder(3, 7, 7));
        }
    }
}