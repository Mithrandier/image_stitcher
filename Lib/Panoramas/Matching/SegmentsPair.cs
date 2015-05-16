using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImagesMatching;

namespace Panoramas.Matching {
  public class SegmentsPair : IImagesMatch {
    public const int MIN_MATCHES_COUNT = 10;

    SegmentsPair reverse_pair;
    int limit;
    double? distance;
    KeyPointsPair[] all_matches;
    bool active;

    public KeyPointsPair[] Matches { get; private set; }
    public Segment BaseSegment { get; private set; }
    public Segment QuerySegment { get; private set; }

    public SegmentsPair(Segment base_segment, Segment query, KeyPointsPair[] matches = null) {
      this.BaseSegment = base_segment;
      this.QuerySegment = query;
      if (matches == null) {
        var matcher = new ImagesMatching.Flann.Matcher(base_segment.Bitmap, query.Bitmap);
        this.all_matches = matcher.Match();
      } else {
        this.all_matches = matches;
      }
      setOptimalLimit();
    }

    public void SetReversePair(SegmentsPair pair) {
      this.reverse_pair = pair;
      pair.reverse_pair = this;
    }

    public bool Active {
      get { return active; }
      set {
        if (Matches.Length < MIN_MATCHES_COUNT && value == true) {
          this.active = false;
          return;
        }
        this.active = value;
        if (reverse_pair != null && reverse_pair.Active != active) {
          reverse_pair.Active = active;
        }
      }
    }

    public System.Drawing.Image ToImage() {
      return new MatchPresenter(this).Render();
    }

    void setOptimalLimit() {
      int count = MIN_MATCHES_COUNT;
      this.limit = count * 100 / all_matches.Length;
      this.active = true;
      setCountLimit(count);
    }

    public int LimitPercent {
      get {
        return limit;
      }
      set {
        var percent = value;
        this.limit = percent;
        if (percent < 0 || percent > 100)
          throw new ArgumentException("Invalid parameter value");
        var matches_count = all_matches.Length * percent / 100;
        if (matches_count < MIN_MATCHES_COUNT) {
          active = false;
        }
        if (reverse_pair != null && reverse_pair.LimitPercent != this.LimitPercent) {
          reverse_pair.LimitPercent = percent;
        }
        setCountLimit(matches_count);
      }
    }

    void setCountLimit(int count) {
      this.Matches = all_matches.Take(count).ToArray();
      ResetDistance();
    }

    public Segment[] Segments {
      get { return new Segment[] { BaseSegment, QuerySegment }; }
    }

    public double Distance() {
      if (distance == null || Double.IsNaN((double)distance))
        ResetDistance();
      return (double)distance;
    }

    void ResetDistance() {
      var sum = Matches.Sum((m) => m.Distance);
      this.distance = sum*sum / Matches.Length;
    }

    public Transformation GenerateTransformation() {
      return new Transformation(defineHomography());
    }

    public bool Includes(Segment segment) {
      return BaseSegment == segment || QuerySegment == segment;
    }

    public Segment PairOf(Segment segment) {
      if (segment == BaseSegment)
        return QuerySegment;
      else if (segment == QuerySegment)
        return BaseSegment;
      else
        return null;
    }

    Emgu.CV.HomographyMatrix defineHomography() {
      var points_dst = Matches.Select((m) => m.Left.Point).ToArray();
      var points_src = Matches.Select((m) => m.Right.Point).ToArray();
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
