using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImagesMatching;

namespace Panoramas.Matching {
  public class SegmentsMatch {
    public const int MIN_MATCHES_COUNT = 10;

    public Segment BaseSegment { get; private set; }
    public Segment QuerySegment { get; private set; }

    ImagesMatching.Flann.Matcher matcher;

    public SegmentsMatch(Segment base_segment, Segment query, ImagesMatching.Flann.Matcher matcher = null) {
      this.BaseSegment = base_segment;
      this.QuerySegment = query;
      this.matcher = matcher != null ? matcher : new ImagesMatching.Flann.Matcher(base_segment.Bitmap, query.Bitmap);
    }

    public Segment[] Segments {
      get {
        return new Segment[] { BaseSegment, QuerySegment };
      }
    }

    double? distance;
    public double Distance() {
      if (distance == null)
        distance = Matches().Sum((m) => m.Distance) / Matches().Length;
      return (double)distance;
    }

    KeyPointsPair[] all_matches;
    KeyPointsPair[] matches;
    public KeyPointsPair[] Matches() {
      if (all_matches == null) {
        this.all_matches = this.matcher.Match();
        LimitMatchesBy(0);
      }
      return matches;
    }

    public Transformation GenerateTransformation() {
      return new Transformation(DefineHomography());
    }

    public void LimitMatchesBy(int percent) {
      if (percent < 0 || percent > 100)
        throw new ArgumentException("Invalid parameter value");
      this.Matches();
      var matches_count = Math.Max(MIN_MATCHES_COUNT, all_matches.Length * percent / 100);
      this.matches = all_matches.Take(matches_count).ToArray();
    }

    public bool Includes(Segment segment) {
      return BaseSegment == segment || QuerySegment == segment;
    }

    public bool IncludesAnyOf(Segment[] segments) {
      foreach (var segment in segments) {
        if (Includes(segment)) return true;
      }
      return false;
    }

    public Segment PairOf(Segment segment) {
      if (segment == BaseSegment)
        return QuerySegment;
      else if (segment == QuerySegment)
        return BaseSegment;
      else
        return null;
    }

    Emgu.CV.HomographyMatrix DefineHomography() {
      var points_dst = Matches().Select((m) => m.Left.Point).ToArray();
      var points_src = Matches().Select((m) => m.Right.Point).ToArray();
      var matrix = Emgu.CV.CameraCalibration.FindHomography(
        points_src,
        points_dst,
        Emgu.CV.CvEnum.HOMOGRAPHY_METHOD.RANSAC,
        2 // RANSAC reprojection error
        );
      return matrix;
    }
  }
}
