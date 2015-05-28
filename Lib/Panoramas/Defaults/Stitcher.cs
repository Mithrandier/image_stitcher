using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Panoramas.Processors;

namespace Panoramas.Defaults {
  public class Stitcher : IStitcher {
    protected IFactory factory;
    protected IPanoramaImages panorama_segments;
    protected IPanoramaRelations panorama_relations;
    protected IPanoramaTransformations panorama_complete;
    protected IAnalyzer analyzer;
    protected IBuilder builder;
    protected IPresenter presenter;

    public Stitcher(IFactory factory, IImage[] images) {
      if (images.Length < 2)
        throw new ArgumentException("Not enough images");
      this.factory = factory;
      this.analyzer = factory.Analyzer();
      this.builder = factory.Builder();
      this.presenter = factory.Presenter();
      this.panorama_segments = factory.PanoramaImages(images);
      this.panorama_relations = analyzer.Analyze(panorama_segments);
    }

    public IRelationControl MatchBetween(String image_base, String image_matched) {
      return panorama_relations.MatchBetween(image_base, image_matched);
    }

    public Bitmap StitchAll() {
      this.panorama_complete = builder.Build(panorama_relations);
      return presenter.Present(panorama_complete);
    }

    public void SetImages(string[] names, Bitmap[] bitmaps) {
      if (names.Length != bitmaps.Length)
        throw new ArgumentException();
      foreach (var image in panorama_relations.Images) {
        if (!names.Contains(image.Name))
          analyzer.RemoveImage(panorama_relations, image);
      }
      for (int i_name = 0; i_name < names.Length; i_name++) {
        var name = names[i_name];
        if (!panorama_relations.Images.Select((i) => i.Name).Contains(name))
          analyzer.AddImage(panorama_relations, factory.Image(name, bitmaps[i_name]));
      }
      if (panorama_relations.Images.Count != names.Length)
        throw new NullReferenceException();
    }
  }
}
