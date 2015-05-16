using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas {
  public class Panorama : IPanorama {
    public Segment[] Segments { get; private set; }
    public Segment Core { get; private set; }

    public Panorama(Segment[] segments) {
      this.Segments = segments;
    }

    public void SetCore(Segment segment) {
      if (!Segments.Contains(segment))
        throw new Exception("Unknown segment!");
      this.Core = segment;
    }

    public void ResetSegmentsPositions() {
      foreach (var segment in Segments) {
        segment.ResetTransformation();
      }
    }
  }
}
