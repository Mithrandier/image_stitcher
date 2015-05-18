using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas {
  public interface ITransformation {
    void Move(int x_diff, int y_diff);
    void Reset();
    void Distort(ITransformation transformation);
    ITransformation Multiply(ITransformation transformation);
    Bitmap TransformOn(Bitmap image, Bitmap template);
  }
}
