using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaekJoon.Problems;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaekJoon.Problems.Tests
{
    [TestClass()]
    public class P1052Tests
    {
        [TestMethod()]
        public void SolveTest()
        {
            Assert.AreEqual(1, P1052.Instance.GetAnswer(3, 1));
            Assert.AreEqual(1, P1052.Instance.GetAnswer(3, 1));
            Assert.AreEqual(0, P1052.Instance.GetAnswer(3, 2));
            Assert.AreEqual(1, P1052.Instance.GetAnswer(7, 2));
            Assert.AreEqual(3, P1052.Instance.GetAnswer(13, 2));
            Assert.AreEqual(0, P1052.Instance.GetAnswer(0, 1));
            Assert.AreEqual(0, P1052.Instance.GetAnswer(4, 1));
            Assert.AreEqual(0, P1052.Instance.GetAnswer(2, 1));
            Assert.AreEqual(0, P1052.Instance.GetAnswer(1, 1));
            Assert.AreEqual(0, P1052.Instance.GetAnswer(4, 0));
            Assert.AreEqual(0, P1052.Instance.GetAnswer(2, 0));
            Assert.AreEqual(0, P1052.Instance.GetAnswer(1, 0));
        }
    }
}