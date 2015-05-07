using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV.Features2D;

namespace ImagesMatching.Flann {
  public class Matcher {
    const int KNN = 1;
    const int SEARCH_ITERATIONS_COUNT = 24;

    FeaturedImage ImageBase;
    FeaturedImage ImageQuery;

    public Matcher(FeaturedImage image_base, FeaturedImage image_query) {
      this.ImageBase = image_base;
      this.ImageQuery = image_query;
    }
    public Matcher(Bitmap bitmap_base, Bitmap bitmap_query) :
      this(new FeaturedImage(bitmap_base), new FeaturedImage(bitmap_query)) { }

    public KeyPointsPair[] Match() {
      var index = new Emgu.CV.Flann.Index(FeaturesToMatrix(ImageBase.Features));
      var query = FeaturesToMatrix(ImageQuery.Features);
      int features_count = ImageQuery.Features.Length;
      var indices = new Emgu.CV.Matrix<int>(features_count, 1);
      var distances = new Emgu.CV.Matrix<float>(features_count, 1);
      index.KnnSearch(query, indices, distances, KNN, SEARCH_ITERATIONS_COUNT);
      var matches = new KeyPointsPair[features_count];
      for (int iQueryFeature = 0; iQueryFeature < features_count; iQueryFeature++) {
        var iBaseFeature = indices[iQueryFeature, 0];
        matches[iQueryFeature] = new KeyPointsPair(
          ImageBase.Features[iBaseFeature].KeyPoint,
          ImageQuery.Features[iQueryFeature].KeyPoint, 
          distances[iQueryFeature, 0]);
      }
      return matches.OrderBy((pair) => { return pair.Distance; }).ToArray();
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

    Emgu.CV.Util.VectorOfKeyPoint FeaturesToVector(ImageFeature<float>[] features) {
      var vector = new Emgu.CV.Util.VectorOfKeyPoint();
      vector.Push(features.Select((feat) => feat.KeyPoint).ToArray());
      return vector;
    }

    System.Drawing.PointF[] FeaturesToPoints(ImageFeature<float>[] features) {
      return features.Select((f) => f.KeyPoint.Point).ToArray();
    }
  }
}
