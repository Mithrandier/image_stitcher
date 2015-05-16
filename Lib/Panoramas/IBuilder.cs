using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas {
  public interface IBuilder {
    IPanorama Generate(IPanoramaMatches panorama_matches);
  }
}
