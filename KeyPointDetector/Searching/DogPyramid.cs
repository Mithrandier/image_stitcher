using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphic;

namespace Sift.Searching {
  class DogPyramid {
    GaussPyramid gauss_pyramid;
    public DogPyramid(GaussPyramid gauss_pyramid) {
      this.gauss_pyramid = gauss_pyramid;
    }

    public CorePoint[] FindExtrems() {
      return new CorePoint[] { new CorePoint(-1, -1) };
    }

    void Build() {

    }
  }
}
