using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Panoramas.FeaturedTrees.Matching;

namespace Panoramas.FeaturedTrees {
  public class Factory : Panoramas.DefaultFactory {
    public IPanoramaComplete PanoramaComplete(IPanoramaRelations panorama) {
      return new PanoramaComplete(panorama);
    }

    public IAnalyzer Analyzer() {
      return new FeaturesAnalyzer(this);
    }

    public IBuilder Builder() {
      return new Panoramas.FeaturedTrees.Trees.TreeBuilder(this);
    }
  }
}
