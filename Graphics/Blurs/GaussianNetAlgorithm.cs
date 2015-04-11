using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic.Blurs {
  /// <summary>
  /// https://github.com/fschultz/NetImageLibrary/blob/master/Filters/GaussianBlurFilter.cs
  /// </summary>
  public class GaussianNetAlgorithm :IBlur {
    IPicture image;
    double sigma;

    public GaussianNetAlgorithm(IPicture image, double sigma) {
      if (sigma <= 1)
        throw new ArgumentOutOfRangeException("sigma");
      this.image = image;
      this.sigma = sigma;
    }

    public int Radius { get { return (int)(sigma * 3); } }

    public IPicture Apply() {
      var inPixels = image.Array;
      var kernel = CreateKernel();
      var iter_one = ConvolveAndTranspose(kernel, inPixels, image.Width, image.Height);
      image.Array = ConvolveAndTranspose(kernel, iter_one, image.Height, image.Width);
      return image;
    }

    uint[] ConvolveAndTranspose(double[] kernel, uint[] inPixels, int width, int height) {
      int cols = Radius * 2 + 1;
      var outPixels = new uint[inPixels.Length];
      for (int y = 0; y < height; y++) {
        int ioffset = y * width;
        for (int x = 0, index = y; x < width; x++, index += height) {
          double r = 0, g = 0, b = 0;
          for (int col = -Radius; col <= Radius; col++) {
            double weight = kernel[Radius + col];
            if (weight == 0)
              continue;
            int dx = Clamp(x + col, width - 1);
            int rgb = (int)inPixels[ioffset + dx];
            r += weight * ((rgb >> 16) & 0xff);
            g += weight * ((rgb >> 8) & 0xff);
            b += weight * (rgb & 0xff);
          }
          int ia = 0xff;
          int ir = Clamp((int)(r + 0.5), 255);
          int ig = Clamp((int)(g + 0.5), 255);
          int ib = Clamp((int)(b + 0.5), 255);
          outPixels[index] = (uint)((ia << 24) | (ir << 16) | (ig << 8) | ib);
        }
      }
      return outPixels;
    }

    int Clamp(int value, int max, int min = 0) {
      return Math.Max(min, Math.Min(max, value));
    }

    double[] CreateKernel() {
      var r = (int)Math.Ceiling((double)Radius);
      int rows = r * 2 + 1;
      var matrix = new double[rows];
      double exp_divider = 2 * sigma * sigma;
      var divider = (float)Math.Sqrt(2 * Math.PI * sigma);
      float radius2 = Radius * Radius;
      double total = 0;
      for (int dr = -r; dr <= r; dr++) {
        float distance = dr * dr;
        double weight;
        if (distance > radius2)
          weight = 0;
        else
          weight = (float)Math.Exp(-(distance) / exp_divider) / divider;
        total += weight;
        matrix[dr + r] = weight;
      }
      for (int i = 0; i < rows; i++) {
        matrix[i] /= total;
      }
      return matrix;
    }
  }
}
