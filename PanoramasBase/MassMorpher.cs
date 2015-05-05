using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV.Structure;
using Panoramas.Logger;

namespace Panoramas.Morphing {
  public class MassMorpher {
    SegmentsMap map;
    Segment core;
    Bitmap template;

    public MassMorpher(SegmentsMap map, Segment core_segment) {
      this.map = map;
      this.core = core_segment;
      Logger.Logger.LogTime("GenerateTemplate", () => {
        this.template = GenerateTemplate();
      });
    }

    public Bitmap Stitch() {
      Emgu.CV.Image<Bgr, int> result = null;
      Logger.Logger.LogTime("Stitch", () => {
        result = new Emgu.CV.Image<Bgr, int>((Bitmap)template.Clone());
        var core_distortion = new Transformation(core.Bitmap);
        core_distortion.Move(core.Bitmap.Width, core.Bitmap.Height);
        core_distortion.TransformOn(result);
        var segments = map.Segments.Where((s) => s != core);
        foreach (var segment in segments) {
          var transformation = map.MatchBetween(core, segment).Transformation();
          transformation.TransformWithin(result, core_distortion);
        }
      });
      Bitmap full_result = result.ToBitmap();
      Bitmap cropped_result = null;
      Logger.Logger.LogTime("AutoCrop", () => {
        cropped_result = new Cropper(full_result).AutoCrop();
      });
      return cropped_result;
    }

    Bitmap GenerateTemplate() {
      int width = core.Bitmap.Width * 3;
      int height = core.Bitmap.Height * 3;
      var template = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
      return template;
    }    

    Point BasePoint {
      get { return new Point(core.Bitmap.Width, core.Bitmap.Height); }
    }
  }
}
