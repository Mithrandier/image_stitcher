using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas {
  public interface IFactory {
    IPanoramaSegments PanoramaSegments(Segment[] segments);
    IPanoramaRelations PanoramaRelations(IPanoramaSegments panorama, List<ISegmentsRelation> relations);
    IPanoramaComplete PanoramaComplete(IPanoramaRelations panorama);

    IAnalyzer Analyzer();
    IBuilder Builder();
  }
}
