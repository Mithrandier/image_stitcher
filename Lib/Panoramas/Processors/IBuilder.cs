using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas.Processors {
  public interface IBuilder {
    IPanoramaTransformations Build(IPanoramaRelations panorama_relations);
  }
}
