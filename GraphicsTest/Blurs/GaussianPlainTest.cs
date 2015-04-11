using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Graphic;
using Graphic.Blurs;

namespace GraphicsTest.Blurs {
  [TestClass]
  public class GaussianPlainTest :IBlurTest {
    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void RequiresCorrectSigma() {
      new GaussianPlain(image, 0.99);
    }

    protected override IBlur blur { get { return (IBlur)new GaussianPlain(image, 2); } }
  }
}
