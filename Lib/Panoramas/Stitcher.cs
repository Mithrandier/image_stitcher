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

    public Stitcher(Segment[] segments) {
      if (segments.Length < 2)
        throw new ArgumentException("Not enough images");
      this.matching_controller = new MatchingController(segments);
    }

    public Image MatchTwo(Segment image_base, Segment image_matched) {
      var presenter = new MatchPresenter(matching_controller.MatchBetween(image_base, image_matched));
      return presenter.Render();
    }

    public double DistanceBetween(Segment image_base, Segment image_matched) {
      return matching_controller.MatchBetween(image_base, image_matched).Distance();
    }

    public void SetLimit(Segment image_base, Segment image_matched, int percent) {
      matching_controller.MatchBetween(image_base, image_matched).LimitMatchesBy(percent);
    }

    public Image StitchAll() {
      var tree_builder = new TreeBuilder(matching_controller);
      var tree = tree_builder.Generate();
      return new TreePresenter(tree).Render();
    }
  }
}
