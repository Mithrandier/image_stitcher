using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV.Features2D;

namespace TransformatorExample.Matchers {
  class Ruler {
    public static double Module(ImageFeature<float> feature) {
      double sum = 0;
      foreach (var component in feature.Descriptor)
        sum += component * component;
      return sum;
    }

    public static double Distance(ImageFeature<float> feature1, ImageFeature<float> feature2) {
      double sum = 0;
      for (int iComponent = 0; iComponent < feature1.Descriptor.Length && iComponent < feature2.Descriptor.Length; iComponent++) {
        var diff = feature1.Descriptor[iComponent] - feature2.Descriptor[iComponent];
        sum += diff * diff;
      }
      return sum;
    }
  }
}
