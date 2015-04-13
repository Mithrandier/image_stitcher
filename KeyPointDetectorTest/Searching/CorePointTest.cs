using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sift;
using Sift.Searching;

namespace KeyPointDetectorTest {
  [TestClass]
  public class CorePointTest {
    [TestMethod]
    public void HasCoordinates() {
      int x = 0, y = 0;
      var point = new CorePoint(x, y);
      Assert.AreEqual(point.X, x);
      Assert.AreEqual(point.Y, y);
    }
  }
}
