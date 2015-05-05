using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Panoramas.Morphing;

namespace PanoramasBaseTests {
  [TestClass]
  public class MassMorpherTest {
    private TestContext testContextInstance;

    [TestMethod]
    public void ItCanBeCreatedWithAMap() {
      new MassMorpher(Factory.ASegmentsMap());
    }

    [TestMethod]
    public void ItMorphsMapIntoPanorama() {
      var panorama = new MassMorpher(Factory.ASegmentsMap()).Stitch();
      Assert.IsNotNull(panorama);
      Assert.IsInstanceOfType(panorama, typeof(System.Drawing.Bitmap));
    }
  }
}
