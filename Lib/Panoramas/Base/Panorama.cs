using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas {
  public class Panorama : IPanorama {
    public Segment[] Segments { get; private set; }

    public Panorama(Segment[] segments) {
      this.Segments = segments;
    }
  }
}
