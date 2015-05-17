using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas.Defaults {
  public class Stitcher : IStitcher {
    IFactory factory;
    IPanoramaImages panorama_segments;
    IPanoramaRelations panorama_relations;
    IPanoramaTransformations panorama_complate;
    IAnalyzer analyzer;
    IBuilder builder;
    IResultPresenter presenter;

    public Stitcher(IFactory factory, IImage[] images) {
      this.factory = factory;
      this.analyzer = factory.Analyzer();
      this.builder = factory.Builder();
      this.presenter = factory.ResultPresenter();
      this.panorama_segments = factory.PanoramaSegments(images);
      this.panorama_relations = analyzer.Analyze(panorama_segments);
    }

    public IRelationControl MatchBetween(String image_base, String image_matched) {
      return panorama_relations.MatchBetween(image_base, image_matched);
    }

    public Bitmap StitchAll() {
      this.panorama_complate = builder.Generate(panorama_relations);
      return presenter.Render(panorama_complate);
    }
  }
}
