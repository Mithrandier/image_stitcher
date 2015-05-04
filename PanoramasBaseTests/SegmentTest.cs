using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Panoramas;

namespace PanoramasBaseTests {
  [TestClass]
  public class SegmentTest {
    const string VALID_FILE_NAME = "..\\..\\Resources\\vt.png";
    const string INVALID_FILE_NAME = "..\\..\\Resources\\?.jpg";

    [TestMethod]
    public void ItCanBeCreatedWithFileName() {
      ASegment();
      new Segment(VALID_FILE_NAME);
    }

    [TestMethod]
    [ExpectedException(typeof(FileNotFoundException))]
    public void ItRaisesErrorIfFileNotFound() {
      new Segment(INVALID_FILE_NAME);
    }

    [TestMethod]
    public void ItCanBeCreatedWithAnotherSegment() {
      new Segment(ASegment());
    }

    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void ItRaisesErrorIfBaseSegmentNull() {
      new Segment(null as Segment);
    }

    [TestMethod]
    public void ItCanBeComparedToOtherSegment() {
      var the_segment = ASegment();
      Assert.AreEqual(the_segment, the_segment);
      Assert.AreNotEqual(the_segment, new Segment(the_segment));
      Assert.AreNotEqual(the_segment, AnotherSegment());
    }

    [TestMethod]
    public void ItGivesAccessToBitmap() {
      Assert.IsInstanceOfType(ASegment().Bitmap, typeof(System.Drawing.Bitmap));
    }

    public static Segment ASegment() {
      return new Segment(VALID_FILE_NAME);
    }
    public static Segment AnotherSegment() {
      return new Segment("..\\..\\Resources\\vt (2).png");
    }
  }
}
