using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Graphic;

namespace GraphicsTest {
  [TestClass]
  public abstract class IPictureTest {
    [TestMethod]
    public void HasCorrectGabarites() {
      Assert.IsTrue(image.Height == bitmap.Height);
      Assert.IsTrue(image.Width == bitmap.Width);
    }

    [TestMethod]
    public void ProvidesAccessToAnyPixel() {
      int x = 0, y = 0;
      Assert.IsTrue(image[x, y] is uint);
    }

    [TestMethod]
    public void AllowToSetAnyPixel() {
      int x = 0, y = 0;
      var image = this.image;
      int x_source = image.Width - 1, y_source = image.Height - 1;
      Assert.AreNotEqual(image[x, y], image[x_source, y_source]);
      image[x, y] = image[x_source, y_source];
      Assert.AreEqual(image[x, y], image[x_source, y_source]);
    }

    [TestMethod]
    [ExpectedException(typeof(IndexOutOfRangeException))]
    public void RaisesExceptionIfPixelOutOfRange() {
      var flawedPixel = image[bitmap.Height, bitmap.Width];
    }

    [TestMethod]
    public void ConvertsImageToByteArray() {
      var bytes_array = image.ByteArray;
      Assert.IsTrue(bytes_array.Length > 0, "Not empty bytes array");
      Assert.IsTrue(bytes_array[0] is byte, "bytes?");
    }

    [TestMethod]
    public void ConvertsImageToIntArray() {
      var ints_array = image.Array;
      Assert.IsTrue(ints_array.Length > 0, "Not empty ints array");
      Assert.IsTrue(ints_array[0] is uint, "ints?");
    }

    [TestMethod]
    public void AllowsToIterateThroughPixels() {
      image.EachPixel((x, y, p) => Assert.IsNotNull(p));
    }

    [TestMethod]
    public void AllowsToIterateThroughPixelsManually() {
      var image = this.image;
      for (int y = 0; y < image.Height; y++) {
        int y_offset = y * image.Width;
        for (int x = 0; x < image.Width; x++) {
          var z = image.Array[y_offset + x];
        }
      }
    }

    [TestMethod]
    public void CopiesItsBlankTemplate() {
      var template = image.CopyTemplate();
      Assert.IsTrue(template is IPicture);
      Assert.AreEqual(template.Height, image.Height);
      Assert.AreEqual(template.Width, image.Width);
    }

    protected abstract IPicture image { get; }
    protected System.Drawing.Bitmap bitmap { get { return Factory.ABitmap; } }
  }
}
