using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StitcherTest {
  [TestClass]
  public class EmguStitcherTest {
    [TestMethod]
    public void CanBeCreated() {
      var stitcher = this.stitcher;
    }

    [TestMethod]
    public void ProducesCombinedImage() {
      stitcher.Stitch(null);
    }

    Stitcher.EmguStitcher _stitcher;
    Stitcher.EmguStitcher stitcher { get {
      if (_stitcher == null)
        _stitcher = new Stitcher.EmguStitcher();
      return _stitcher;
    } }
  }
}
