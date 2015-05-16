using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas {
  public class PanoramaSegments : IPanoramaSegments {
    public Segment[] Segments { get; private set; }

    public PanoramaSegments(Segment[] segments) {
      this.Segments = segments;
    }

    public PanoramaSegments(IPanoramaSegments panorama) {
      this.Segments = panorama.Segments;
    }
  }
}
