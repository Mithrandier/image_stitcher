using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV.Features2D;

namespace TransformatorExample.Matchers {
  class FlannMatcher : IMatcher {
    public KeyPointsPair[] Match(FeaturedImage image1, FeaturedImage image2) {
      var index = new Emgu.CV.Flann.Index(FeaturesToMatrix(image2.Features));
      var query = FeaturesToMatrix(image1.Features);
      int features_count = image1.Features.Length;
      var indices = new Emgu.CV.Matrix<int>(features_count, 1);
      var distances = new Emgu.CV.Matrix<float>(features_count, 1);
      index.KnnSearch(query, indices, distances, 1, 24);
      KeyPointsPair[] pairs = new KeyPointsPair[features_count];
      for (int iFeature1 = 0; iFeature1 < features_count; iFeature1++) {
        var match = image2.Features[indices[iFeature1, 0]];
        pairs[iFeature1] = new KeyPointsPair(image1.Features[iFeature1], match, distances[iFeature1, 0]);
      }
      return pairs;
    }

    Emgu.CV.Matrix<float> FeaturesToMatrix(ImageFeature<float>[] features) {
      float[,] matrix = new float[features.Length, features[0].Descriptor.Length];
      for (int iFeature = 0; iFeature < features.Length; iFeature++) {
        var descriptor = features[iFeature].Descriptor;
        for (int iComponent = 0; iComponent < descriptor.Length; iComponent++)
          matrix[iFeature, iComponent] = descriptor[iComponent];
      }
      return new Emgu.CV.Matrix<float>(matrix);
    }
  }
}
