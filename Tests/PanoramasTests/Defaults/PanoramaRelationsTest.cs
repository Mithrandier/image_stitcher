using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Panoramas;
using Panoramas.Defaults;

namespace PanoramasBaseTests.Defaults {
  [TestClass]
  public class PanoramaRelationsTest {
    [TestMethod]
    public void ItCanBeCreatedWithPanoramaImagesAndImageRelations() {
      var pan_images = TestFactory.PanoramaImages();
      var pan_relations = new PanoramaRelations(pan_images, TestFactory.ImagesRelations(pan_images.Images.ToList()));
      Assert.AreEqual(pan_images.Images, pan_relations.Images);
    }

    [TestMethod]
    public void ItDefinesACoreImage() {
      var images = TestFactory.Images();
      var pan_relations = TestFactory.PanoramaRelations(images);
      var core = pan_relations.Core();
      Assert.IsNotNull(core);
      Assert.IsTrue(images.Contains(core));
    }

    [TestMethod]
    public void ItMatchesImagesByNamesOrLinks() {
      var images = TestFactory.Images();
      var pan_relations = TestFactory.PanoramaRelations(images);
      var match_1 = pan_relations.MatchBetween(images[0].Name, images[1].Name);
      Assert.IsNotNull(match_1);
      Assert.IsTrue(match_1 is IImagesRelation);
      Assert.AreEqual(match_1, pan_relations.MatchBetween(images[0], images[1]));
      var match_2 = pan_relations.MatchBetween(images[1].Name, images[0].Name);
      Assert.IsNotNull(match_2);
      Assert.AreNotEqual(match_1, match_2);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void ItCannotMatchImageWithItself() {
      var images = TestFactory.Images();
      var pan_relations = TestFactory.PanoramaRelations(images);
      var match = pan_relations.MatchBetween(images[0].Name, images[0].Name);
      Assert.IsNull(match);
    }

  }
}
