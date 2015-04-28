using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV.Features2D;

namespace TransformatorExample {
  class KeyPointsPair {
    public ImageFeature<float> FeatureLeft { get; private set; }
    public ImageFeature<float> FeatureRight { get; private set; }
    public double Distance { get; private set; }

    public KeyPointsPair(ImageFeature<float> feature_left, ImageFeature<float> feature_right, double distance) {
      this.FeatureLeft = feature_left;
      this.FeatureRight = feature_right;
      this.Distance = distance;
    }
  }
}
