using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic.Pictures {
  public class BitmapWrap: Picture, IPicture {
    public BitmapWrap(int width, int height) {
      this.original_image = new System.Drawing.Bitmap(width, height);
    }

    public BitmapWrap(String file_name) {
      LoadImage(file_name);
    }

    public override uint this[int x, int y] {
      get {
        if (!PixelInRange(x, y)) throw new IndexOutOfRangeException();
        return ConvertToIntensity(GetPixel(x, y)); 
      }
      set {
        if (!PixelInRange(x, y)) throw new IndexOutOfRangeException();
        SetPixel(x, y, ConvertToPixel((int)value)); 
      }
    }
    public System.Drawing.Color GetPixel(int x, int y) {
      return original_image.GetPixel(x, y);
    }
    public void SetPixel(int x, int y, System.Drawing.Color pixel) {
      original_image.SetPixel(x, y, pixel);
    }

    public bool CheckBounds(int x, int y) {
      return (x >= 0 && x < Width && y >= 0 && y < Height);
    }

    public System.Drawing.Bitmap ToBitmap() {
      return original_image;
    }

    public IPicture CopyTemplate() {
      return new BitmapWrap(Width, Height);
    }

    void LoadImage(String file_name) {
      original_image = System.Drawing.Bitmap.FromFile(file_name) as System.Drawing.Bitmap;
      return;
    }

    uint ConvertToIntensity(System.Drawing.Color pixel) {
      return (uint)(0.2989 * pixel.R + 0.5870 * pixel.G + 0.1140 * pixel.B);
    }

    System.Drawing.Color ConvertToPixel(int intensity) {
      //if (intensity < 0 || intensity > 254) throw new ArgumentOutOfRangeException("intensity");
      return System.Drawing.Color.FromArgb(intensity, intensity, intensity);
    }
  }
}
