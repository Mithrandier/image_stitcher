using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas {
  public interface IAnalyzer {
    IPanoramaRelations Analyze(IPanoramaImages panorama_segment);
  }
}
