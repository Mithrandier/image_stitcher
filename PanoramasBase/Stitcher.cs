using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Panoramas.Matching;
using Panoramas.Morphing;

namespace Panoramas {
  public class Stitcher {
    Segment[] images;
    SegmentsMap segments_map;
    Panorama pan;

    public Stitcher(Segment[] images) {
      this.images = images;
      this.segments_map = new SegmentsMap(images);
      this.pan = new Panorama(images);
    }

    public void SetLimit(Segment image_base, Segment image_matched, int percent) {
      segments_map.MatchBetween(image_base, image_matched).LimitMatchesBy(percent);
    }

    public Image MatchTwo(Segment image_base, Segment image_matched) {
      var presenter = new MatchesPresenter(segments_map.MatchBetween(image_base, image_matched));
      return presenter.Render();
    }

    public double[,] GetTransformation(Segment image_base, Segment image_matched) {
      return segments_map.MatchBetween(image_base, image_matched).GenerateTransformation().Matrix();
    }

    public Image StitchAll() {
      var tree_builder = new TreeBuilder(segments_map);
      var tree = tree_builder.Generate();
      return new Presenters.PanoramaPresenter(pan, tree).Render();
    }

    public double DistanceBetween(Segment image_base, Segment image_matched) {
      return segments_map.MatchBetween(image_base, image_matched).Distance();
    }
  }
}
