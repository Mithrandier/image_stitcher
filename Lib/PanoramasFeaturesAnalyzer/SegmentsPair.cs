using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas.FeaturesAnalyzer {
  public class SegmentsPair : IImagesRelation {
    public const int MIN_MATCHES_COUNT = 10;

    int limit;
    double? distance;
    KeyPointsPair[] all_matches;
    bool active;

    public KeyPointsPair[] Matches { get; private set; }
    public IImage BaseSegment { get; private set; }
    public IImage QuerySegment { get; private set; }
    public IImage[] Segments {
      get { return new IImage[] { BaseSegment, QuerySegment }; }
    }
    public bool Active {
      get { return active; }
      set {
        if (Matches.Length < MIN_MATCHES_COUNT && value == true) {
          this.active = false;
          return;
        }
        this.active = value;
        if (ReversePair != null && ReversePair.Active != active) {
          ReversePair.Active = active;
        }
      }
    }
    public IImagesRelation ReversePair { get; set; }

    public SegmentsPair(IImage base_segment, IImage query) {
      this.BaseSegment = base_segment;
      this.QuerySegment = query;
      var matcher = new Flann.Matcher(BaseSegment.Bitmap, QuerySegment.Bitmap);
      this.all_matches = matcher.Match();
      setOptimalLimit();
    }

    public void SetReversePair(IImagesRelation pair) {
      this.ReversePair = pair;
      pair.ReversePair = this;
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
        if (ReversePair != null && ReversePair.LimitPercent != this.LimitPercent) {
          ReversePair.LimitPercent = percent;
        }
        setCountLimit(matches_count);
      }
    }

    public System.Drawing.Bitmap ToImage() {
      return new PairPresenter(this).Render();
    }

    public double Similarity() {
      if (distance == null || Double.IsNaN((double)distance))
        resetDistance();
      return (double)distance;
    }

    public ITransformation GenerateTransformation() {
      var points_dst = this.Matches.Select((m) => m.Left.Point).ToArray();
      var points_src = this.Matches.Select((m) => m.Right.Point).ToArray();
      return Panoramas.HomographyTransformer.Transformation.Generate(points_dst, points_src);
    }

    public bool Includes(IImage segment) {
      return BaseSegment == segment || QuerySegment == segment;
    }

    public IImage PairOf(IImage segment) {
      if (segment == BaseSegment)
        return QuerySegment;
      else if (segment == QuerySegment)
        return BaseSegment;
      else
        return null;
    }

    void setOptimalLimit() {
      int count = MIN_MATCHES_COUNT;
      this.limit = count * 100 / all_matches.Length;
      this.active = true;
      setCountLimit(count);
    }

    void setCountLimit(int count) {
      this.Matches = all_matches.Take(count).ToArray();
      resetDistance();
    }

    void resetDistance() {
      var sum = Matches.Sum((m) => m.Distance);
      this.distance = sum / Matches.Length;
    }
  }
}
