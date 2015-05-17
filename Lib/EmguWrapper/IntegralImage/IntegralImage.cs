using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV.Structure;

namespace EmguWrapper.IntegralImage
{
    public class IntegralImage : IIntegralImage
    {
      Emgu.CV.Image<Bgr, double> integral;

      public IntegralImage(Bitmap bitmap) {
        this.integral = new Emgu.CV.Image<Bgr, double>(bitmap).Integral();
      }

      public double this[int x, int y] {
        get {
          var pixel = integral[y, x];
          var intensity = (pixel.Red + pixel.Green + pixel.Blue) / 3;
          return intensity;
        }
      }

      public int Width {
        get { return integral.Width; }
      }

      public int Height {
        get { return integral.Height; }
      }
    }
}
