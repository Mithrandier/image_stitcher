using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Panoramas;
using Panoramas.Defaults;

namespace PanoramasBaseTests {
  [TestClass]
  public class PanoramaImagesTest {
    [TestMethod]
    public void ItCanBeCreatedWithImages() {
      var images = TestFactory.Images().ToArray();
      var pan_images = new PanoramaImages(images);
      Assert.AreEqual(pan_images.Images, images);
    }

    [TestMethod]
    public void ItCanBeCreatedWithAnotherInstance() {
      var instance = TestFactory.PanoramaImages();
      var new_instance = new PanoramaImages(instance);
      Assert.AreEqual(instance.Images, new_instance.Images);
    }
  }
}
