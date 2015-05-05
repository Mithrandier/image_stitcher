using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Panoramas.Matching;

namespace Panoramas {
  public class SegmentsMatch {
    public const int MIN_MATCHES_COUNT = 10;

    public Segment BaseSegment { get; private set; }
    public Segment QuerySegment { get; private set; }

    FlannMatcher matcher;    

    public SegmentsMatch(Segment base_segment, Segment query, FlannMatcher matcher = null) {
      this.BaseSegment = base_segment;
      this.QuerySegment = query;
      this.matcher = matcher != null ? matcher : new FlannMatcher(base_segment.Bitmap, query.Bitmap);
    }

    double? distance;
    public double Distance() {
      if (distance == null)
        distance = Matches().Sum((m) => m.Distance);
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

    Transformation transformation;
    public Transformation Transformation() {
      if (transformation == null)
        transformation = new Transformation(Matches());
      return transformation;
    }

    public void LimitMatchesBy(int percent) {
      this.Matches();
      var matches_count = Math.Max(MIN_MATCHES_COUNT, all_matches.Length * percent / 100);
      this.matches = all_matches.Take(matches_count).ToArray();
    }
  }
}
