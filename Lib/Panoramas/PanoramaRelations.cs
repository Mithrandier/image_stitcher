using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas {
  public class PanoramaRelations: PanoramaSegments, IPanoramaRelations {
    public List<ISegmentsRelation> Relations { get; private set; }

    public PanoramaRelations(IPanoramaSegments panorama, List<ISegmentsRelation> relations)
      : base(panorama) {
        this.Relations = relations;
    }

    public PanoramaRelations(IPanoramaRelations panorama)
      : base(panorama) {
        this.Relations = panorama.Relations;
    }

    public Segment Core() {
      return Segments.OrderBy((s) => distancesFor(s)).First();
    }

    double distancesFor(Segment segment) {
      return Relations.Sum((m) => m.QuerySegment == segment ? m.Distance() : 0);
    }

    public ISegmentsRelation MatchBetween(Segment base_segment, Segment query_segment) {
      if (base_segment == query_segment || !Segments.Contains(base_segment) || !Segments.Contains(query_segment))
        throw new ArgumentException("Request for missing images");
      return Relations.Find((m) => m.BaseSegment == base_segment && m.QuerySegment == query_segment);
    }

    public IRelationControl MatchBetween(String base_segment, String query_segment) {
      var all_files = Segments.Select((s) => s.Filename);
      if (base_segment == query_segment || !all_files.Contains(base_segment) || !all_files.Contains(query_segment))
        throw new ArgumentException("Request for missing images");
      return Relations.Find((m) => m.BaseSegment.Filename == base_segment && m.QuerySegment.Filename == query_segment);
    }

    public Segment ClosestTo(Segment segment) {
      return Relations.
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
      return Relations.
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
      var match = Relations.
        Where((m) => m.Segments.Intersect(group).Count() > 0).
        Where((m) => m.Segments.Intersect(domain).Count() > 0).
        OrderBy((m) => m.Distance()).
        First();
      closest = match.Segments.Except(group).First();
      closest_from_group = match.Segments.Except(domain).First();
    }

    public Segment[] NeighboursOf(Segment segment, Segment[] domain = null) {
      if (domain == null)
        domain = Segments;
      return domain.Where((s) => ClosestTo(s) == segment).ToArray();
    }

    public void ResetSegmentsPositions() {
      foreach (var segment in Segments)
        segment.ResetTransformation();
    }
  }
}
