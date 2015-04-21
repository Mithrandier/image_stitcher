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
      if (width <= 0 || height <= 0)
        throw new ArgumentOutOfRangeException();
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

    public IPicture ScaleTo(int width, int height) {
      var result = new RawImage(width, height);
      double scale = Width * 1.0 / width;
      result.EachPixel((x, y, p) => {
        result[x, y] = GetPixelSafe((int)(x * scale), (int)(y * scale));
      });
      return result;
    }

    public uint GetPixelSafe(int x, int y) {
      x = Math.Max(0, Math.Min(Width - 1, x));
      y = Math.Max(0, Math.Min(Height - 1, y));
      return this[x, y];
    }

    public IPicture Scale(double scale) {
      var result = new RawImage((int)(Width * scale), (int)(Height * scale));
      result.EachPixel((x, y, p) => {
        result[x, y] = GetPixelSafe((int)(x / scale), (int)(y / scale));
      });
      return result;
    }
  }
}
