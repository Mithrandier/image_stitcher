using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImagesMatching;

namespace Panoramas.Matching {
  public class MatchingController {
    public Segment[] AllSegments { get; private set; }
    public List<SegmentsPair> Matches { get; private set; }

    public MatchingController(Segment[] segments) {
      this.AllSegments = segments;
      this.Matches = GenerateMatches(segments);
    }

    public SegmentsPair MatchBetween(Segment base_segment, Segment query_segment) {
      if (base_segment == query_segment || !AllSegments.Contains(base_segment) || !AllSegments.Contains(query_segment))
        throw new ArgumentException("Request for missing images");
      return Matches.Find((m) => m.BaseSegment == base_segment && m.QuerySegment == query_segment);
    }

    public SegmentsPair MatchBetween(String base_segment, String query_segment) {
      var all_files = AllSegments.Select((s) => s.Filename);
      if (base_segment == query_segment || !all_files.Contains(base_segment) || !all_files.Contains(query_segment))
        throw new ArgumentException("Request for missing images");
      return Matches.Find((m) => m.BaseSegment.Filename == base_segment && m.QuerySegment.Filename == query_segment);
    }

    static List<SegmentsPair> GenerateMatches(Segment[] segments) {
      var featured_segments = segments.Select((s) => s.Bitmap).ToArray();
      var matches = new List<SegmentsPair>();
      var matched_segments = new List<Segment>();
      for (int iBase = 0; iBase < segments.Length; iBase++) {
        var base_segment = segments[iBase];
        for (int iQuery = 0; iQuery < segments.Length; iQuery++) {
          if (iBase == iQuery)
            continue;
          var matched_segment = segments[iQuery];
          var matcher = new ImagesMatching.Flann.Matcher(featured_segments[iBase], featured_segments[iQuery]);
          var match = new SegmentsPair(base_segment, matched_segment, matcher.Match());
          if (matched_segments.Contains(matched_segment)) {
            var prev_match = matches.Find((m) => m.BaseSegment == matched_segment && m.QuerySegment == base_segment);
            match.SetReversePair(prev_match);
          }
          matches.Add(match);
        }
        matched_segments.Add(base_segment);
      }
      return matches;
    }

    public Segment CoreSegment(Segment[] domain = null) {
      if (domain == null)
        domain = AllSegments;
      return domain.OrderBy((s) => DistancesFor(s)).First();
    }

    public Segment ClosestTo(Segment segment) {
      return Matches.
        Where((m) => m.Includes(segment)).
        OrderBy((m) => m.Distance()).
        First().
        PairOf(segment);
    }

    public Segment ClosestTo(Segment segment, Segment[] domain = null) {
      if (domain.Contains(segment))
        throw new ArgumentException();
      if (domain == null)
        domain = AllSegments;
      return Matches.
        Where((m) => m.Includes(segment) && domain.Contains(m.PairOf(segment))).
        OrderBy((m) => m.Distance()).
        First().
        PairOf(segment);
    }

    public void ClosestTo(Segment[] group, Segment[] domain, out Segment closest, out Segment closest_from_group) {
      if (domain.Intersect(group).Count() > 0)
        throw new ArgumentException();
      if (domain == null)
        domain = AllSegments;
      var match = Matches.
        Where((m) => m.Segments.Intersect(group).Count() > 0).
        Where((m) => m.Segments.Intersect(domain).Count() > 0).
        OrderBy((m) => m.Distance()).
        First();
      closest = match.Segments.Except(group).First();
      closest_from_group = match.Segments.Except(domain).First();
    }

    public Segment[] NeighboursOf(Segment segment, Segment[] domain = null) {
      if (domain == null)
        domain = AllSegments;
      return domain.Where((s) => ClosestTo(s) == segment).ToArray();
    }

    double DistancesFor(Segment segment) {
      return Matches.Sum((m) => m.QuerySegment == segment ? m.Distance() : 0);
    }
  }
}
