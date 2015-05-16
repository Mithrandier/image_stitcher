using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas {
  public class DefaultFactory : IFactory {
    public IPanoramaSegments PanoramaSegments(Segment[] segments) {
      return new PanoramaSegments(segments);
    }

    public IPanoramaRelations PanoramaRelations(IPanoramaSegments panorama, List<ISegmentsRelation> relations) {
      return new PanoramaRelations(panorama, relations);
    }

    public IPanoramaComplete PanoramaComplete(IPanoramaRelations panorama) {
      throw new NotImplementedException();
    }

    public IAnalyzer Analyzer() {
      throw new NotImplementedException();
    }

    public IBuilder Builder() {
      throw new NotImplementedException();
    }
  }
}
