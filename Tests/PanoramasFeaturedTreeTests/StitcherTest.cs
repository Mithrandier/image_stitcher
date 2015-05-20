using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PanoramasFeaturedTreeTests {
  [TestClass]
  public class StitcherTest : PanoramasBaseTests.StitcherTest {
    [TestMethod]
    public override void ItCanBeCreatedWithFactoryAndImages() {
      base.ItCanBeCreatedWithFactoryAndImages();
    }

    [TestMethod]
    public override void ItRequiresDifferentImagesToReturnRelation() {
      base.ItRequiresDifferentImagesToReturnRelation();
    }

    [TestMethod]
    public override void ItRequiresExistantImageNamesToReturnRelation() {
      base.ItRequiresExistantImageNamesToReturnRelation();
    }

    [TestMethod]
    public override void ItRequiresNoLessThanTwoImages() {
      base.ItRequiresNoLessThanTwoImages();
    }

    [TestMethod]
    public override void ItReturnsRelationBetweenImagesByNames() {
      base.ItReturnsRelationBetweenImagesByNames();
    }

    [TestMethod]
    public override void ItStitchesAllIntoABitmap() {
      base.ItStitchesAllIntoABitmap();
    }

    protected override Panoramas.IFactory PanoramasFactory() {
      return new Panoramas.FeaturedTrees.PrivateFactory();
    }
  }
}
