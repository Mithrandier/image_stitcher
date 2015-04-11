using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic {
  public delegate void PixelIterator(int x, int y, uint pixel);

  public interface IPicture {
    int Height { get; }
    int Width { get; }
    uint this[int x, int y] { get; set; }
    byte[] ByteArray { get; }
    uint[] Array { get; set; }

    void EachPixel(PixelIterator iterator);
    System.Drawing.Bitmap ToBitmap();
    IPicture CopyTemplate();
  }
}
