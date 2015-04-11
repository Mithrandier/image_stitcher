using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Graphic;
using Graphic.Pictures;

namespace GraphicsTest {
  [TestClass]
  public class BitmapWrapTest: IPictureTest {
    [TestMethod]
    public void CanBeCreatedWithSizeOnly() {
      new BitmapWrap(16, 16);
    }

    protected override IPicture image { get { return Factory.AnImage; } }
  }
}
