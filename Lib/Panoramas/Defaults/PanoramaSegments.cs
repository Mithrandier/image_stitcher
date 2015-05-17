using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas.Defaults {
  public class PanoramaSegments : IPanoramaSegments {
    public IImage[] Images { get; private set; }

    public PanoramaSegments(IImage[] segments) {
      this.Images = segments;
    }

    public PanoramaSegments(IPanoramaSegments panorama) {
      this.Images = panorama.Images;
    }
  }
}
