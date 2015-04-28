using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV.Features2D;

namespace TransformatorExample.Matchers {

  class FlannMatcher : IMatcher {
    const int BEST_MATCHES_COUNT = 20;
    const int KNN = 1;
    const int SEARCH_ITERATIONS_COUNT = 24;

    Emgu.CV.Matrix<int> indices;
    Emgu.CV.Matrix<float> distances;
    KeyPointsPair[] matches;
    FeaturedImage image_base, image_query;

    public FlannMatcher(FeaturedImage image_base, FeaturedImage image_query) {
      this.image_base = image_base;
      this.image_query = image_query;
    }

    public KeyPointsPair[] Match() {
      var index = new Emgu.CV.Flann.Index(FeaturesToMatrix(image_base.Features));
      var query = FeaturesToMatrix(image_query.Features);
      int features_count = image_query.Features.Length;
      this.indices = new Emgu.CV.Matrix<int>(features_count, 1);
      this.distances = new Emgu.CV.Matrix<float>(features_count, 1);
      index.KnnSearch(query, indices, distances, KNN, SEARCH_ITERATIONS_COUNT);
      this.matches = new KeyPointsPair[features_count];
      for (int iQueryFeature = 0; iQueryFeature < features_count; iQueryFeature++) {
        var iBaseFeature = indices[iQueryFeature, 0];
        matches[iQueryFeature] = new KeyPointsPair(
          image_base.Features[iBaseFeature], 
          image_query.Features[iQueryFeature], 
          distances[iQueryFeature, 0]);
      }
      return matches;
    }

    public Emgu.CV.HomographyMatrix DefineHomography() {
      var best_matches = matches.OrderBy((p) => p.Distance).Take(BEST_MATCHES_COUNT);
      var points_src = best_matches.Select((m) => m.FeatureLeft.KeyPoint.Point).ToArray();
      var points_dst = best_matches.Select((m) => m.FeatureRight.KeyPoint.Point).ToArray();
      var matrix = Emgu.CV.CameraCalibration.FindHomography(
        points_src, points_dst, Emgu.CV.CvEnum.HOMOGRAPHY_METHOD.RANSAC, 2
        );
      return matrix;
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
