using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic.Blurs {
  public class GaussianPlain :IBlur {
    IPicture image;
    double sigma;
    double[,] map;

    public GaussianPlain(IPicture image, double sigma) {
      if (sigma <= 1) throw new ArgumentOutOfRangeException("sigma");
      this.image = image;
      this.sigma = sigma;
    }

    int _radius = -1;
    public int Radius {
      get {
        if (_radius == -1)
          _radius = (int)(sigma * 3);
        return _radius;
      }
    }

    public IPicture Apply() {
      if (map == null)
        GenerateMap();
      var image_result = image.CopyTemplate();
      var raw_array = image.Array;
      for (int y = 0; y < image.Height; y++) {
        int y_offset = y * image.Width;
        for (int x = 0; x < image.Width; x++) {
          double sum = 0;
          for (int dy = -Radius; dy <= Radius; dy++) {
            int current_y = Math.Min(image.Height - 1, Math.Max(0, y + dy));
            int current_y_offset = current_y * image.Width;
            for (int dx = -Radius; dx <= Radius; dx++) {
              int current_x = Math.Min(image.Width - 1, Math.Max(0, x + dx));
              sum += map[dx + Radius, dy + Radius] * raw_array[current_y_offset + current_x];
            }
          }
          image_result[x, y] = (uint)sum;
        }
      }
      return image_result;
    }

    public IPicture ApplyOld() {
      if (map == null)
        GenerateMap();
      var image_result = image.CopyTemplate();
      image.EachPixel((x, y, p) => {
        image_result[x, y] = (UInt32)ApplyMapTo(x, y, p);
      });
      return image_result;
    }

    double ApplyMapTo(int x, int y, uint p) {
      double sum = 0;
      for (int dx = -Radius; dx <= Radius; dx++) {
        for (int dy = -Radius; dy <= Radius; dy++) {
          int current_x = Math.Min(image.Width - 1, Math.Max(0, x + dx));
          int current_y = Math.Min(image.Height - 1, Math.Max(0, y + dy));
          sum += map[dx + Radius, dy + Radius] * image[current_x, current_y];
        }
      }
      return sum;
    }

    void GenerateMap() {
      int side_length = Radius * 2 + 1;
      double[,] map = new double[side_length, side_length];
      double divider = (2 * Math.PI * sigma * sigma);
      double exp_divier = 2 * sigma * sigma;
      for (int y = 0; y < side_length; y++) {
        int yy = y * y;
        for (int x = 0; x < side_length; x++)
          map[x, y] = Math.Exp(-(x * x + yy) / exp_divier) / divider;
      }
      this.map = map;
    }
  }
}
