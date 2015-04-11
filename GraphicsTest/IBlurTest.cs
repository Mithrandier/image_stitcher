using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Graphic;
using Graphic.Pictures;
using Graphic.Blurs;

namespace GraphicsTest {
  [TestClass]
  public abstract class IBlurTest {
    [TestMethod]
    public void GeneratesAnImageOfSameSize() {
      var result_image = blur.Apply();
      Assert.IsTrue(result_image is IPicture);
      Assert.AreEqual(result_image.Height, image.Height);
      Assert.AreEqual(result_image.Width, image.Width);
    }

    protected abstract IBlur blur { get; }
    protected IPicture image { get { return Factory.ARawImage; } }
  }
}
