using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Panoramas;

namespace PanoramasBaseTests {
  [TestClass]
  public class SegmentTest {
    [TestMethod]
    public void ItCanBeCreatedWithFileName() {
      Factory.ASegment();
    }

    [TestMethod]
    [ExpectedException(typeof(FileNotFoundException))]
    public void ItRaisesErrorIfFileNotFound() {
      new Segment(Factory.INVALID_FILE_NAME);
    }

    [TestMethod]
    public void ItCanBeCreatedWithAnotherSegment() {
      new Segment(Factory.ASegment());
    }

    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void ItRaisesErrorIfBaseSegmentNull() {
      new Segment(null as Segment);
    }

    [TestMethod]
    public void ItContainsTransformation() {
      var transformation = Factory.ASegment().Transformation;
      Assert.IsNotNull(transformation);
      Assert.IsInstanceOfType(transformation, typeof(Transformation));
    }

    [TestMethod]
    public void ItCanBeComparedToOtherSegment() {
      var the_segment = Factory.ASegment();
      Assert.AreEqual(the_segment, the_segment);
      Assert.AreNotEqual(the_segment, new Segment(the_segment));
      Assert.AreNotEqual(the_segment, AnotherSegment());
    }

    [TestMethod]
    public void ItGivesAccessToBitmap() {
      Assert.IsInstanceOfType(Factory.ASegment().Bitmap, typeof(System.Drawing.Bitmap));
    }
    public static Segment AnotherSegment() {
      return new Segment("..\\..\\Resources\\vt (2).png");
    }
  }
}
