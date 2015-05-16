using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas.FeaturedTrees {
  class PanoramaComplete: PanoramaRelations, IPanoramaComplete {
    public PanoramaComplete(IPanoramaRelations panorama)
      : base(panorama) {

    }

    public System.Drawing.Bitmap Render() {
      return new PanoramaPresenter().Render(this);
    }
  }
}
