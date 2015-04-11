using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Graphic;
using Graphic.Blurs;

namespace GraphicsTest.Blurs {
  [TestClass]
  public class GaussianNetAlgorithmTest :IBlurTest {
    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void RequiresCorrectSigma() {
      new GaussianNetAlgorithm(image, 0.99);
    }

    protected override IBlur blur { get { return (IBlur)new GaussianNetAlgorithm(image, 2); } }
  }
}
