using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas.FeaturedTree {
  public class Panorama : PanoramaMatches, IPanorama {
    public Panorama(IPanoramaMatches panorama_matches)
      : PanoramaSegments(panorama_matches) {

    }

    public Segment Core { get; private set; }
    public void SetCore(Segment segment) {
      if (!Segments.Contains(segment))
        throw new Exception("Unknown segment!");
      this.Core = segment;
    }
  }
}
