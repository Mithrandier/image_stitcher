using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Panoramas.Matching;

namespace PanoramasBaseTests.Matching {
  [TestClass]
  public class MatchPresenterTest {
    [TestMethod]
    public void ItCanBeCreatedWithAMatch() {
      new PairPresenter(Factory.ASegmentsMatch());
    }

    [TestMethod]
    public void ItGeneratesABitmap() {
      var result = new PairPresenter(Factory.ASegmentsMatch()).Render();
      Assert.IsNotNull(result);
      Assert.IsInstanceOfType(result, typeof(Bitmap));
    }
  }
}
