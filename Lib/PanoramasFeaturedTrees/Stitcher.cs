using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Panoramas.FeaturedTrees;
using Panoramas.FeaturedTrees.Matching;
using Panoramas.FeaturedTrees.Trees;

namespace Panoramas {
  public class Stitcher {
    IFactory factory;
    IPanoramaSegments panorama_segments;
    IPanoramaRelations panorama_relations;
    IPanoramaComplete panorama_complate;
    IAnalyzer analyzer;
    IBuilder builder;

    public Stitcher(IFactory factory, String[] keys, Bitmap[] images) {
      if (keys.Length < 2 || keys.Length != images.Length)
        throw new ArgumentException("Not enough images");
      var segments = new List<Segment>();
      for (int i = 0; i < keys.Length; i++)
        segments.Add(new Segment(keys[i], images[i]));
      this.factory = factory;
      this.analyzer = new FeaturesAnalyzer(factory);
      this.builder = new TreeBuilder(factory);
      this.panorama_segments = new PanoramaSegments(segments.ToArray());
      this.panorama_relations = analyzer.Analyze(panorama_segments);
    }

    public Stitcher(IFactory factory, String[] filenames)
      : this(factory, filenames, filenames.Select((f) => new Bitmap(f)).ToArray()) {

    }

    public IRelationControl MatchBetween(String image_base, String image_matched) {
      return panorama_relations.MatchBetween(image_base, image_matched);
    }

    public Image StitchAll() {
      this.panorama_complate = builder.Generate(panorama_relations);
      var uncut_panorama = new PanoramaPresenter().Render(panorama_complate);
      var factory = new EmguWrapper.IntegralImage.Factory();
      var cropped_result = new Rendering.Cropper(uncut_panorama, factory).AutoCrop();
      return cropped_result;
    }
  }
}
