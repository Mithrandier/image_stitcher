using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV.Features2D;

namespace TransformatorExample.Matchers {
  class SquareMatcher : IMatcher {
    FeaturedImage image1, image2;

    public SquareMatcher(FeaturedImage image1, FeaturedImage image2) {
      this.image1 = image1;
      this.image2 = image2;
    }

    public KeyPointsPair[] Match() {
      KeyPointsPair[] matches = new KeyPointsPair[image1.Features.Length];
      var modules1 = ComputeModules(image1.Features);
      var modules2 = ComputeModules(image2.Features);
      for (int iFeature1 = 1; iFeature1 < image1.Features.Length; iFeature1++) {
        var feature1 = image1.Features[iFeature1];
        double closest_distance = Ruler.Distance(feature1, image2.Features.First());
        int iClosest = 0;
        for (int iFeature2 = 1; iFeature2 < image2.Features.Length; iFeature2++) {
          var feature2 = image2.Features[iFeature2];
          var module_diff = Math.Abs(modules1[iFeature1] - modules2[iFeature2]);
          if (module_diff > closest_distance)
            continue;
          double distance = Ruler.Distance(feature1, feature2);
          if (distance < closest_distance) {
            closest_distance = distance;
            iClosest = iFeature2;
          }
        }
        matches[iFeature1] = new KeyPointsPair(feature1, image2.Features[iClosest], closest_distance);
      }
      return matches;
    }

    double[] ComputeModules(ImageFeature<float>[] features) {
      var modules = new double[features.Length];
      for (int iFeature = 0; iFeature < features.Length; iFeature++) {
        modules[iFeature] = Ruler.Module(features[iFeature]);
      }
      return modules;
    }
  }
}
