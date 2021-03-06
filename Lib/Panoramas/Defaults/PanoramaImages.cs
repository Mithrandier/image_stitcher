﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas.Defaults {
  public class PanoramaImages : IPanoramaImages {
    public List<IImage> Images { get; private set; }

    public PanoramaImages(IImage[] segments) {
      this.Images = segments.ToList();
    }

    public PanoramaImages(IPanoramaImages panorama) {
      this.Images = panorama.Images;
    }
  }
}
