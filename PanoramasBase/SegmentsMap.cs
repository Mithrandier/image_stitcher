using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Panoramas.Matching;

namespace Panoramas {
  public class SegmentsMap {
    public Segment[] Segments { get; private set; }
    public List<SegmentsMatch> Matches { get; private set; }

    public SegmentsMap(Segment[] segments) {
      this.Segments = segments;
      GenerateMatches();
    }

    public SegmentsMatch MatchBetween(Segment base_segment, Segment query_segment) {
      return Matches.Find((m) => m.BaseSegment == base_segment && m.QuerySegment == query_segment);
    }

    public Segment CoreSegment() {
      var x = Segments.OrderBy((s) => DistancesFor(s)).First();
      return x;
    }

    void GenerateMatches() {
      var featured_segments = Segments.Select((s) => new FeaturedImage(s.Bitmap)).ToArray();
      var matches = new List<SegmentsMatch>();
      for (int iBase = 0; iBase < Segments.Length; iBase++)
        for (int iQuery = 0; iQuery < Segments.Length; iQuery++) {
          if (iBase == iQuery)
            continue;
          var matcher = new FlannMatcher(featured_segments[iBase], featured_segments[iQuery]);
          matches.Add(new SegmentsMatch(Segments[iBase], Segments[iQuery], matcher));
        }
      this.Matches = matches;
    }

    double DistancesFor(Segment segment) {
      return Matches.Sum((m) => m.QuerySegment == segment ? m.Distance() : 0);
    }
  }
}
