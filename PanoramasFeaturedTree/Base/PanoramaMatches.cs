using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Panoramas.FeaturedTree.Matching;

namespace Panoramas.FeaturedTree {
  public class PanoramaMatches : PanoramaSegments, IPanoramaMatches {
    List<SegmentsPair> relations;

    public PanoramaMatches(IPanoramaSegments base_panorama, List<SegmentsPair> relations)
      : base(base_panorama.Segments) {
        this.relations = relations.ToList();
    }

    public Segment ClosestTo(Segment segment) {
      return relations.
        Where((m) => m.Includes(segment)).
        OrderBy((m) => m.Distance()).
        First().
        PairOf(segment);
    }

    public Segment ClosestTo(Segment segment, Segment[] domain = null) {
      if (domain.Contains(segment))
        throw new ArgumentException();
      if (domain == null)
        domain = Segments;
      return relations.
        Where((m) => m.Includes(segment) && domain.Contains(m.PairOf(segment))).
        OrderBy((m) => m.Distance()).
        First().
        PairOf(segment);
    }

    public void ClosestTo(Segment[] group, Segment[] domain, out Segment closest, out Segment closest_from_group) {
      if (domain.Intersect(group).Count() > 0)
        throw new ArgumentException();
      if (domain == null)
        domain = Segments;
      var match = relations.
        Where((m) => m.Segments.Intersect(group).Count() > 0).
        Where((m) => m.Segments.Intersect(domain).Count() > 0).
        OrderBy((m) => m.Distance()).
        First();
      closest = match.Segments.Except(group).First();
      closest_from_group = match.Segments.Except(domain).First();
    }

    public SegmentsPair MatchBetween(Segment base_segment, Segment query_segment) {
      if (base_segment == query_segment || !Segments.Contains(base_segment) || !Segments.Contains(query_segment))
        throw new ArgumentException("Request for missing images");
      return relations.Find((m) => m.BaseSegment == base_segment && m.QuerySegment == query_segment);
    }

    public IRelationControl MatchBetween(String base_segment, String query_segment) {
      var all_files = Segments.Select((s) => s.Filename);
      if (base_segment == query_segment || !all_files.Contains(base_segment) || !all_files.Contains(query_segment))
        throw new ArgumentException("Request for missing images");
      return relations.Find((m) => m.BaseSegment.Filename == base_segment && m.QuerySegment.Filename == query_segment);
    }
   
    public void ResetSegmentsPositions() {
      foreach (var segment in Segments) {
        segment.ResetTransformation();
      }
    }

    public Segment Core() {
      return Segments.OrderBy((s) => distancesFor(s)).First();
    }

    double distancesFor(Segment segment) {
      return relations.Sum((m) => m.QuerySegment == segment ? m.Distance() : 0);
    }
  }
}
