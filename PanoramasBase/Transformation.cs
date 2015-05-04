using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas {
  public class Transformation {
    public Emgu.CV.HomographyMatrix Matrix;

    public Transformation(Emgu.CV.HomographyMatrix matrix) {
      this.Matrix = matrix;
    }
  }
}
