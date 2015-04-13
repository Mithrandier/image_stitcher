using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyPointDetector.Sift {
  class CorePoint {
    public double X { get; private set; }
    public double Y { get; private set; }
    public CorePoint(double x, double y) {
      this.X = x;
      this.Y = y;
    }
  }
}
