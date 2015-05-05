using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Panoramas;

namespace PanoramasBaseTests {
  [TestClass]
  public class CropperTest {
    [TestMethod]
    public void ItCanBeCreatedWithABitmap() {
      new Cropper(Factory.ABitmap());
    }

    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void ItRequiresBItmapToBePresent() {
      new Cropper(null);
    }

    [TestMethod]
    public void ItGeneratesLesserBitmap() {
      var original_bitmap = Factory.ABitmap();
      var cropped_bitmap = new Cropper(original_bitmap).AutoCrop();
      Assert.IsTrue(original_bitmap.Width >= cropped_bitmap.Width);
      Assert.IsTrue(original_bitmap.Height >= cropped_bitmap.Height);
    }
  }
}
