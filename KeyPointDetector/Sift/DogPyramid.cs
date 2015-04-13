using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphic;

namespace KeyPointDetector.Sift {
  class DogPyramid {
    GaussPyramid gauss_pyramid;
    public DogPyramid(GaussPyramid gauss_pyramid) {
      this.gauss_pyramid = gauss_pyramid;
    }

    public CorePoint[] FindExtrems() {
      return null;
    }

    void Build() {

    }
  }
}
