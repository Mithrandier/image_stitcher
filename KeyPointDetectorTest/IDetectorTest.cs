using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Graphic;
using Graphic.Pictures;
using KeyPointDetector;

namespace KeyPointDetectorTest {
  [TestClass]
  public class IDetectorTest {
    public const String IMAGE_PATH = "..\\..\\Resources\\brikbrak-sample.jpg";

    [TestMethod]
    public void GeneratesListOfPoints() {
      var detector = CreateDetector();
      var result = detector.Apply();
      Assert.IsTrue(result is Array, "Array?");
      Assert.IsTrue(result.Length > 0, "Not empty?");
      Assert.IsTrue(result[0] is KeyPoint, "Of KeyPoints?");
    }

    IDetector CreateDetector() {
      return new KeyPointDetector.Sift.Detector(CreateImage());
    }

    IPicture CreateImage() {
      return new RawImage(IMAGE_PATH);
    }
  }
}
