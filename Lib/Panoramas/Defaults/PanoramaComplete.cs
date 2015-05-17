using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas.Defaults {
  public class PanoramaComplete: PanoramaRelations, IPanoramaComplete {
    public ISegment[] Segments { get; private set; }

    public PanoramaComplete(IPanoramaRelations panorama, ISegment[] segments)
      : base(panorama) {
        this.Segments = segments;
    }
  }
}
