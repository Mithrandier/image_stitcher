using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic.Pictures {
  public class RawImage : Picture, IPicture {
    public RawImage(String filename) {
      this.original_image = (Bitmap)Bitmap.FromFile(filename);
    }

    public RawImage(Bitmap image) {
      this.original_image = image;
    }

    public RawImage(int width, int height) {
      this.original_image = new Bitmap(width, height);
    }

    public override uint this[int x, int y] { 
      get {
        if (!PixelInRange(x, y)) throw new IndexOutOfRangeException();
        return Array[y*Width + x]; 
      }
      set {
        if (!PixelInRange(x, y)) throw new IndexOutOfRangeException();
        Array[y * Width + x] = value; 
      }
    }

    public System.Drawing.Bitmap ToBitmap() {
      var bitmap = (Bitmap)original_image.Clone();
      EachPixel((x, y, p) => {
        bitmap.SetPixel(x, y, Color.FromArgb((int)p));
      });
      return bitmap;
    }

    public IPicture CopyTemplate() {
      return new RawImage(Width, Height);
    }

    public byte[] GetPixelBytes(int x, int y) {
      int start_index = y * Width * 4 + x * 4;
      return ExtractPixelFromPosition(start_index);
    }

    byte[] ExtractPixelFromPosition(int position) {
      byte[] raw_pixel = new byte[4];
      for (int iByte = 0; iByte < 4; iByte++)
        raw_pixel[iByte] = ByteArray[position + iByte];
      return raw_pixel;
    }
  }
}
