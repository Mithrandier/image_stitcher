using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Panoramas;

namespace PanoramasBaseTests {
  [TestClass]
  public class StitcherTest {
    [TestMethod]
    public void ItCanBeCreatedWithImages() {
      var images = new Segment[] { Factory.ASegment(), Factory.ASegment() };
      new Stitcher(images);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void ItRequiresAtLeastTwoImages() {
      var images = new Segment[] { Factory.ASegment() };
      new Stitcher(images);
    }

    [TestMethod]
    public void ItProvidesResultOfMatchingImages() {
      var images = new Segment[] { Factory.ASegment(), Factory.ASegment() };
      var stitcher = new Stitcher(images);
      var match_result = stitcher.MatchTwo(images[0], images[1]);
      Assert.IsNotNull(match_result);
      Assert.IsInstanceOfType(match_result, typeof(Bitmap));
      match_result = stitcher.MatchTwo(images[1], images[0]);
      Assert.IsNotNull(match_result);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void ItRaisesErrorIfAskingForUnknownImages() {
      var images = new Segment[] { Factory.ASegment(), Factory.ASegment() };
      var stitcher = new Stitcher(images);
      var match_result = stitcher.MatchTwo(images[0], Factory.ASegment());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void ItRaisesErrorIfAskingForSameImage() {
      var images = new Segment[] { Factory.ASegment(), Factory.ASegment() };
      var stitcher = new Stitcher(images);
      var match_result = stitcher.MatchTwo(images[0], images[0]);
    }

    [TestMethod]
    public void ItAllowsToChangeParametersOfSomeMatch() {
      var images = new Segment[] { Factory.ASegment(), Factory.ASegment() };
      var stitcher = new Stitcher(images);
      stitcher.SetLimit(images[0], images[1], 100);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void ItRequiresValidParametersValues() {
      var images = new Segment[] { Factory.ASegment(), Factory.ASegment() };
      var stitcher = new Stitcher(images);
      stitcher.SetLimit(images[0], images[1], -1);
    }

    [TestMethod]
    public void ItComputesLikelinessBetweenTwoSegments() {
      var images = new Segment[] { Factory.ASegment(), Factory.ASegment() };
      var stitcher = new Stitcher(images);
      Assert.IsTrue(stitcher.DistanceBetween(images[0], images[1]) >= 0);
      Assert.IsTrue(stitcher.DistanceBetween(images[1], images[0]) >= 0);
    }

    [TestMethod]
    public void ItGeneratesPanorama() {
      var images = new Segment[] { Factory.ASegment(), Factory.ASegment() };
      var stitcher = new Stitcher(images);
      var pan = stitcher.StitchAll();
      Assert.IsNotNull(pan);
      Assert.IsInstanceOfType(pan, typeof(Bitmap));
    }
  }
}
