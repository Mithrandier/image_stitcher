using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas {
  public interface IPanoramaRelations : IPanoramaSegments {
    Segment Core();
    ISegmentsRelation MatchBetween(Segment base_segment, Segment related_image);
    IRelationControl MatchBetween(String base_iamge, String related_image);
    Segment[] NeighboursOf(Segment segment, Segment[] domain = null);
    void ClosestTo(Segment[] group, Segment[] domain, out Segment closest, out Segment closest_from_group);
    void ResetSegmentsPositions();
    List<ISegmentsRelation> Relations { get; }
  }
}
