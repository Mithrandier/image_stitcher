using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas {
  public interface IPanorama : IPanoramaMatches {
    Segment Core { get; }
    void SetCore(Segment segment);
  }
}
