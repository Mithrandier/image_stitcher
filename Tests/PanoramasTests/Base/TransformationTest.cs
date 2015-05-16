using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Panoramas;

namespace PanoramasBaseTests {
  [TestClass]
  public class TransformationTest {
    [TestMethod]
    public void ItCanBeCreated() {
      new Transformation();
    }

    [TestMethod]
    public void ItCanBeCreatedWithAnotherTransformation() {
      var old_trnsformation = Factory.ATransformation();
      var new_transformation = old_trnsformation.Clone();
      Assert.AreEqual(old_trnsformation, new_transformation);
    }

    [TestMethod]
    public void ItUsesOuterTransformation() {
      var first_version = Factory.ATransformation();
      var changed_version = first_version.Clone();
      Assert.AreEqual(first_version, changed_version);
      changed_version.Move(1, 1);
      Assert.AreNotEqual(first_version, changed_version);

      var distorted_version = first_version.Clone();
      Assert.AreEqual(first_version, distorted_version);
      distorted_version.Distort(first_version);
      Assert.AreEqual(first_version, distorted_version);
      distorted_version.Distort(changed_version);
      Assert.AreNotEqual(first_version, distorted_version);
    }

    [TestMethod]
    public void ItTransformsSegment() {
      var result = Factory.ATransformation().Transform(Factory.ABitmap());
      Assert.IsNotNull(result);
      Assert.IsInstanceOfType(result, typeof(System.Drawing.Bitmap));
    }
  }
}
