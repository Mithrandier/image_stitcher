using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Panoramas;

namespace PanoramasBaseTests {
  [TestClass]
  public class StitcherTest {
    [TestMethod]
    public void ItCanBeCreatedWithFilenames() {
      AStitcher();
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void ItRequiresAtLeastTwoFiles() {
      var files = new String[] { Factory.VALID_FILE_NAME };
      new Stitcher(files);
    }

    [TestMethod]
    public void ItProvidesResultOfMatchingImages() {
      var files = sampleFiles();
      var stitcher = new Stitcher(files);
      var match_result = stitcher.MatchBetween(files[0], files[1]);
      Assert.IsNotNull(match_result);
      Assert.IsInstanceOfType(match_result, typeof(IRelationController));
      match_result = stitcher.MatchBetween(files[1], files[0]);
      Assert.IsNotNull(match_result);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void ItRaisesErrorIfAskingForUnknownImages() {
      var files = sampleFiles();
      var stitcher = new Stitcher(files);
      var match_result = stitcher.MatchBetween(files[0], "?.jpg");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void ItRaisesErrorIfAskingForSameImage() {
      var files = sampleFiles();
      var stitcher = new Stitcher(files);
      var match_result = stitcher.MatchBetween(files[0], files[0]);
    }

    [TestMethod]
    public void ItGeneratesPanorama() {
      var stitcher = AStitcher();
      var pan = stitcher.StitchAll();
      Assert.IsNotNull(pan);
      Assert.IsInstanceOfType(pan, typeof(Bitmap));
    }

    String[] sampleFiles() {
      return new String[] { Factory.VALID_FILE_NAME, Factory.VALID_FILE_NAME_2 };
    }

    Stitcher AStitcher() {
       return new Stitcher(sampleFiles());
    }
  }
}
