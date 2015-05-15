using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Panoramas.Matching;
using Panoramas.Tree;

namespace Panoramas {
  public class Stitcher {
    MatchingController matching_controller;

    public Stitcher(String[] filenames) {
      if (filenames.Length < 2)
        throw new ArgumentException("Not enough images");
      var segments = filenames.Select((f) => new Segment(f)).ToArray();
      this.matching_controller = new MatchingController(segments.ToArray());    
    }

    public Stitcher(String[] keys, Bitmap[] images) {
      if (keys.Length < 2 || keys.Length != images.Length)
        throw new ArgumentException("Not enough images");
      var segments = new List<Segment>();
      for (int i = 0; i < keys.Length; i++)
        segments.Add(new Segment(keys[i], images[i]));
      this.matching_controller = new MatchingController(segments.ToArray());
    }

    public IImagesMatch MatchBetween(String image_base, String image_matched) {
      return matching_controller.MatchBetween(image_base, image_matched);
    }

    public Image StitchAll() {
      var tree_builder = new TreeBuilder(matching_controller);
      var tree = tree_builder.Generate();
      return new TreePresenter(tree).Render();
    }
  }
}
