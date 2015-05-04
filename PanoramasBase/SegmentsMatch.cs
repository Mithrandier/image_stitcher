using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Panoramas.Matching;

namespace Panoramas {
  public class SegmentsMatch {
    public Segment BaseSegment { get; private set; }
    public Segment QuerySegment { get; private set; }
    public KeyPointsPair[] Matches;
    public Emgu.CV.HomographyMatrix Transformation {
      get {
        return matcher.DefineHomography(Matches);
      }
    }

    KeyPointsPair[] all_matches;
    FlannMatcher matcher;    

    public SegmentsMatch(Segment base_segment, Segment query, FlannMatcher matcher = null) {
      this.BaseSegment = base_segment;
      this.QuerySegment = query;
      this.matcher = matcher != null ? matcher : new FlannMatcher(base_segment.Bitmap, query.Bitmap);
      this.Matches = matcher.Match();
      this.all_matches = Matches;
      LimitMatchesBy(0);
    }

    public void LimitMatchesBy(int percent) {
      var matches_count = Math.Max(10, all_matches.Length * percent / 100);
      this.Matches = all_matches.Take(matches_count).ToArray();
    }

    public double Distance() {
      return Matches.Sum((m) => m.Distance);
    }

    public bool Includes(Segment segment) {
      return BaseSegment == segment || QuerySegment == segment;
    }
  }
}
