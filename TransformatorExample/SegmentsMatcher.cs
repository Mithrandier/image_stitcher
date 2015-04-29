using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matcher;

namespace TransformatorExample {
  class SegmentsMatcher {
    FeaturedImage[] images;

    public SegmentsMatcher(FeaturedImage[] images) {
      this.images = images;
    }

    public FlannMatcher[] ComputeTransformations() {
      FlannMatcher[] matchers = new FlannMatcher[Count];
      double?[,] similarities = new double?[Count, Count];
      for (int iImage1 = 0; iImage1 < Count; iImage1++) {
        double? best_similarity = null;
        int i_best_match = -1;
        FlannMatcher best_matcher = null;
        for (int iImage2 = 0; iImage2 < Count; iImage2++) {
          if (iImage2 == iImage1)
            continue;
          double? similarity = similarities[iImage1, iImage2];
          FlannMatcher matcher = null;
          if (similarity == null) {
            matcher = new FlannMatcher(images[iImage1], images[iImage2]);
            matcher.Match();
            similarity = ComputeSimilarity(matcher);
            similarities[iImage1, iImage2] = similarity;
            similarities[iImage2, iImage1] = similarity;
          }
          if (best_similarity == null || similarity < best_similarity) {
            best_similarity = similarity;
            i_best_match = iImage2;
            best_matcher = matcher;
          }
        }
        if (best_matcher == null)
          best_matcher = new FlannMatcher(images[iImage1], images[i_best_match]);
        matchers[iImage1] = best_matcher;
      }
      return matchers;
    }

    double ComputeSimilarity(FlannMatcher matcher) {
      return matcher.Matches.Sum((m) => m.Distance);
    }

    int Count {
      get { return images.Length; }
    }
  }
}
