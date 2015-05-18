using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas.Defaults {
  public class PanoramaRelations: PanoramaImages, IPanoramaRelations {
    public List<IImagesRelation> Relations { get; private set; }

    public PanoramaRelations(IPanoramaImages panorama, List<IImagesRelation> relations)
      : base(panorama) {
        this.Relations = relations;
    }

    public PanoramaRelations(IPanoramaRelations panorama)
      : base(panorama) {
        this.Relations = panorama.Relations;
    }

    public IImage Core() {
      return Images.OrderBy((s) => distancesFor(s)).First();
    }

    double distancesFor(IImage segment) {
      return Relations.Sum((m) => m.QuerySegment == segment ? m.Similarity() : 0);
    }

    public IImagesRelation MatchBetween(IImage base_segment, IImage query_segment) {
      if (base_segment == query_segment || !Images.Contains(base_segment) || !Images.Contains(query_segment))
        throw new ArgumentException("Request for missing images");
      return Relations.Find((m) => m.BaseSegment == base_segment && m.QuerySegment == query_segment);
    }

    public IRelationControl MatchBetween(String base_segment, String query_segment) {
      var all_files = Images.Select((s) => s.Name);
      if (base_segment == query_segment || !all_files.Contains(base_segment) || !all_files.Contains(query_segment))
        throw new ArgumentException("Request for missing images");
      return Relations.Find((m) => m.BaseSegment.Name == base_segment && m.QuerySegment.Name == query_segment);
    }

    public void ClosestBetween(IImage[] group, IImage[] domain, out IImage closest, out IImage closest_from_group) {
      if (domain.Intersect(group).Count() > 0)
        throw new ArgumentException();
      if (domain == null)
        domain = Images;
      var match = Relations.
        Where((m) => m.Segments.Intersect(group).Count() > 0).
        Where((m) => m.Segments.Intersect(domain).Count() > 0).
        OrderBy((m) => m.Similarity()).
        First();
      closest = match.Segments.Except(group).First();
      closest_from_group = match.Segments.Except(domain).First();
    }

    public IImage[] NeighboursOf(IImage segment, IImage[] domain = null) {
      if (domain == null)
        domain = Images;
      return domain.Where((s) => closestTo(s) == segment).ToArray();
    }

    protected IImage closestTo(IImage segment) {
      return Relations.
        Where((m) => m.Includes(segment)).
        OrderBy((m) => m.Similarity()).
        First().
        PairOf(segment);
    }
  }
}
