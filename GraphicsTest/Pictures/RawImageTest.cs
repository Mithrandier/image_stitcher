using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Graphic;
using Graphic.Pictures;

namespace GraphicsTest {
  [TestClass]
  public class RawImageTest : IPictureTest {
    protected override IPicture image { get { return new RawImage(bitmap); } }
  }
}
