using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas {
  public interface ITransformation {
    void Distort(ITransformation transformation);
    ITransformation Multiply(ITransformation transformation);
    void TransformOn(Bitmap image, Bitmap template);
    void Move(int x_diff, int y_diff);
    ITransformation Clone();
    void Reset();
  }
}
