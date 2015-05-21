using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Panoramas.Defaults;

namespace PanoramasBaseTests {
  [TestClass]
  public class SegmentTest {
    [TestMethod]
    public void ItCanBeCreatedWithAFilenameOfImage() {
      var segment = new Segment(TestFactory.VALID_FILE_NAME);
      Assert.AreEqual(segment.Name, TestFactory.VALID_FILE_NAME);
    }

    [TestMethod]
    [ExpectedException(typeof(System.IO.FileNotFoundException))]
    public void ItFailsToBeCreatedWithInvalidFilename() {
      new Segment(TestFactory.INVALID_FILE_NAME);
    }

    [TestMethod]
    public void ItCanBeCreatedWithAnyNameAndBitmap() {
      var bitmap = TestFactory.Bitmap();
      var segment = new Segment(TestFactory.INVALID_FILE_NAME, bitmap);
      Assert.AreEqual(segment.Name, TestFactory.INVALID_FILE_NAME);
      Assert.AreEqual(segment.Bitmap, bitmap);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ItRequiresPresentName() {
      new Segment(null, TestFactory.Bitmap());
    }

    [TestMethod]
    public void ItCanBeCreatedWithImageAndTransformation() {
      var transformation = TestFactory.Transformation();
      var segment = new Segment(TestFactory.Image(), transformation);
      Assert.AreEqual(segment.Transformation, transformation);
    }
  }
}
