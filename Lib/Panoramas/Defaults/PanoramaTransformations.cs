using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas.Defaults {
  public class PanoramaTransformations: PanoramaRelations, IPanoramaTransformations {
    public IImageTransformed[] Segments { get; private set; }

    public PanoramaTransformations(IPanoramaRelations panorama, IImageTransformed[] segments)
      : base(panorama) {
        this.Segments = segments;
    }
  }
}
