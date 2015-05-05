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

    public Segment CoreSegment() {
      return Segments.OrderBy((s) => DistancesFor(s)).First();
    }

    public Segment ClosestTo(Segment segment) {
      return Matches.
        Where((m) => m.Includes(segment)).
        OrderBy((m) => m.Distance()).
        First().
        PairOf(segment);
    }

    public Segment ClosestTo(Segment segment, Segment[] domain) {
      if (domain.Contains(segment))
        throw new ArgumentException();
      return Matches.
        Where((m) => m.Includes(segment) && domain.Contains(m.PairOf(segment))).
        OrderBy((m) => m.Distance()).
        First().
        PairOf(segment);
    }

    public Segment[] DomainOf(Segment segment) {
      return Segments.Where((s) => ClosestTo(s) == segment).ToArray();
    }

    double DistancesFor(Segment segment) {
      return Matches.Sum((m) => m.QuerySegment == segment ? m.Distance() : 0);
    }
  }
}
