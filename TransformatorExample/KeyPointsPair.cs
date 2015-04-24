using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV.Features2D;

namespace TransformatorExample {
  class KeyPointsPair {
    public ImageFeature<float> Feature1 { get; private set; }
    public ImageFeature<float> Feature2 { get; private set; }
    public double Distance { get; private set; }

    public KeyPointsPair(ImageFeature<float> feature1, ImageFeature<float> feature2, double distance) {
      this.Feature1 = feature1;
      this.Feature2 = feature2;
      this.Distance = distance;
    }
  }
}
