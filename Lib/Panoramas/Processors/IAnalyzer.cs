using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas.Processors {
  public interface IAnalyzer {
    IPanoramaRelations Analyze(IPanoramaImages panorama_segment);
    bool AddImage(IPanoramaRelations panorama_relations, IImage image);
    bool RemoveImage(IPanoramaRelations panorama_relations, IImage image);
  }
}
