using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas {
  public interface IPanoramaRelations : IPanoramaImages {
    List<IImagesRelation> Relations { get; }
    IImage Core();
    IImagesRelation MatchBetween(IImage base_segment, IImage related_image);
    IRelationControl MatchBetween(String base_iamge, String related_image);
    IImage[] NeighboursOf(IImage segment, IImage[] domain = null);
    void ClosestBetween(IImage[] group, IImage[] domain, out IImage closest, out IImage closest_from_group);
  }
}
