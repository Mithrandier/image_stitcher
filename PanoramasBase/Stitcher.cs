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

    public Stitcher(Segment[] images) {
      this.images = images;
      this.segments_map = new SegmentsMap(images);
    }

    public void SetLimit(Segment image_base, Segment image_matched, int percent) {
      segments_map.MatchFor(image_base, image_matched).LimitMatchesBy(percent);
    }

    public Image MatchTwo(Segment image_base, Segment image_matched) {
      var presenter = new MatchesPresenter(segments_map.MatchFor(image_base, image_matched));
      return presenter.Render();
    }

    public Emgu.CV.HomographyMatrix GetTransformation(Segment image_base, Segment image_matched) {
      return segments_map.MatchFor(image_base, image_matched).Transformation;
    }

    public Image StitchTwo(Segment image_base, Segment image_matched) {
      var transformation = segments_map.MatchFor(image_base, image_matched).Transformation;
      return new Morpher(image_base.Bitmap, image_matched.Bitmap).Transform(transformation);
    }
  }
}
