using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphic;
using Graphic.Pictures;
using Graphic.Blurs;

namespace GraphicsTest {
  class Factory {
    public const String IMAGE_PATH = "..\\..\\Resources\\brick.jpg";

    public static IPicture AnImage {
      get { return new BitmapWrap(IMAGE_PATH); }
    }
    public static IPicture ARawImage {
      get { return new RawImage(IMAGE_PATH); }
    }

    public static System.Drawing.Bitmap ABitmap {
      get { return GraphicsTest.Properties.Resources.brick1; }
    }

    public static IBlur AGaussian {
      get { return new GaussianPlain(AnImage, 2); }
    }
  }
}
