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
        var segments = map.Segments.Where((s) => s != core);
        foreach (var segment in segments) {
          var formatted_segment = new Emgu.CV.Image<Bgr, int>(segment.Bitmap);
          var transformation = map.MatchBetween(segment, core).Transformation.Clone();
          transformation[0, 2] += core.Bitmap.Width;
          transformation[1, 2] += core.Bitmap.Height;
          Emgu.CV.CvInvoke.cvWarpPerspective(formatted_segment.Ptr, result.Ptr, transformation.Ptr, (int)Emgu.CV.CvEnum.INTER.CV_INTER_NN, new MCvScalar(0, 0, 0));
        }
      });
      Bitmap cropped_result = null;
      Logger.Logger.LogTime("AutoCrop", () => {
        cropped_result = new Cropper(result.ToBitmap()).AutoCrop();
      });
      return cropped_result;
    }

    Bitmap GenerateTemplate() {
      int width = core.Bitmap.Width * 3;
      int height = core.Bitmap.Height * 3;
      var template = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
      var g = Graphics.FromImage(template);
      g.DrawImage(core.Bitmap, BasePoint.X, BasePoint.Y, core.Bitmap.Width, core.Bitmap.Height);
      g.Save();
      return template;
    }    

    Point BasePoint {
      get { return new Point(core.Bitmap.Width, core.Bitmap.Height); }
    }
  }
}
