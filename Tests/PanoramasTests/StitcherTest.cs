using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Panoramas;
using Panoramas.Defaults;

namespace PanoramasBaseTests {
  [TestClass]
  public class StitcherTest {
    [TestMethod]
    public virtual void ItCanBeCreatedWithFactoryAndImages() {
      var images = new IImage[] { TestFactory.Image(), TestFactory.Image() };
      TestFactory.PanoramasFactory().Stitcher(images);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public virtual void ItRequiresNoLessThanTwoImages() {
      var images = new IImage[] { TestFactory.Image() };
      TestFactory.PanoramasFactory().Stitcher(images);
    }

    [TestMethod]
    public virtual void ItReturnsRelationBetweenImagesByNames() {
      var images = TestFactory.Images();
      Assert.IsNotNull(images[0].Name);
      Assert.IsNotNull(images[1].Name);
      Assert.AreNotEqual(images[0].Name, images[1].Name);
      var stitcher = TestFactory.PanoramasFactory().Stitcher(images.ToArray());
      var relation = stitcher.MatchBetween(images[0].Name, images[1].Name);
      Assert.IsNotNull(relation);
      Assert.IsTrue(relation is IImagesRelation);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public virtual void ItRequiresExistantImageNamesToReturnRelation() {
      var images = new IImage[] { TestFactory.Image(), TestFactory.Image() };
      var stitcher = TestFactory.PanoramasFactory().Stitcher(images);
      var relation = stitcher.MatchBetween(images[0].Name, "BAD_NAME.jpg");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public virtual void ItRequiresDifferentImagesToReturnRelation() {
      var images = new IImage[] { TestFactory.Image(), TestFactory.Image() };
      var stitcher = TestFactory.PanoramasFactory().Stitcher(images);
      var relation = stitcher.MatchBetween(images[0].Name, images[0].Name);
    }

    [TestMethod]
    public virtual void ItStitchesAllIntoABitmap() {
      var images = TestFactory.Images();
      var stitcher = TestFactory.PanoramasFactory().Stitcher(images.ToArray());
      var result = stitcher.StitchAll();
      Assert.IsNotNull(result);
      Assert.IsInstanceOfType(result, typeof(System.Drawing.Bitmap));
    }
  }
}
