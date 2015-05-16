using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Panoramas.FeaturedTree.Matching;

namespace Panoramas.FeaturedTree {
  public class Stitcher {
    IPanoramaSegments panorama;
    IAnalyzer matching_controller;
    IBuilder builder;

    public Stitcher(String[] filenames) {
      if (filenames.Length < 2)
        throw new ArgumentException("Not enough images");
      var segments = filenames.Select((f) => new Segment(f)).ToArray();
      this.matching_controller = new MatchingController(segments.ToArray());
      this.panorama = matching_controller.Analyze();
    }

    public Stitcher(String[] keys, Bitmap[] images) {
      if (keys.Length < 2 || keys.Length != images.Length)
        throw new ArgumentException("Not enough images");
      var segments = new List<Segment>();
      for (int i = 0; i < keys.Length; i++)
        segments.Add(new Segment(keys[i], images[i]));
      this.matching_controller = new MatchingController(segments.ToArray());
      this.panorama = matching_controller.Analyze();
    }

    public IRelationControl MatchBetween(String image_base, String image_matched) {
      return matching_controller.MatchBetween(image_base, image_matched);
    }

    public Image StitchAll() {
      this.builder = new TreeBuilder(panorama, matching_controller);
      this.panorama = builder.Generate();
      var uncut_panorama = new PanoramaPresenter().Render(panorama);
      var factory = new EmguWrapper.IntegralImage.Factory();
      var cropped_result = new Rendering.Cropper(uncut_panorama, factory).AutoCrop();
      return cropped_result;
    }
  }
}
