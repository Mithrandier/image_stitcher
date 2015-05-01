using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas {
  public class SegmentsMap {
    public Segment[] Segments { get; private set; }
    public List<SegmentsMatch> Matches { get; private set; }

    public SegmentsMap(Segment[] segments) {
      this.Segments = segments;
      this.Matches = new List<SegmentsMatch>();
      DefineMatches();
      OnlyBestMatches();
    }

    void DefineMatches() {
      foreach (var segment_base in Segments) {
        foreach (var segment_query in Segments) {
          if (segment_base == segment_query)
            continue;
          Matches.Add(new SegmentsMatch(segment_base, segment_query));
        }
      }
    }

    void OnlyBestMatches() {
      var ordered_matches = Matches.OrderBy((m) => m.Distance()).ToList();
      var best_matches = new List<SegmentsMatch>();
      best_matches.Add(ordered_matches.First());
      while (best_matches.Count < Segments.Length - 1) {
        foreach (var match in ordered_matches)
          if (!best_matches.Any((m) => m.Includes(match.BaseSegment)))
            best_matches.Add(match);
      }
      this.Matches = best_matches;
    }

    public SegmentsMatch MatchFor(Segment segment) {
      return Matches.First((m) => m.Includes(segment));
    }

    public SegmentsMatch MatchFor(Segment base_segment, Segment query_segment) {
      return Matches.Find((m) => m.Includes(base_segment) && m.Includes(query_segment));
    }
  }
}
