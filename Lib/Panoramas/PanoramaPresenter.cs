using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Panoramas.Tree;
using Rendering;

namespace Panoramas {
  public class PanoramaPresenter {
    public Bitmap Render(IPanorama panorama) {
      var template = generateTemplate(panorama.Core.Bitmap);
      var result = new Emgu.CV.Image<Emgu.CV.Structure.Bgr, int>((Bitmap)template.Clone());
      var offset = new Transformation();
      offset.Move(panorama.Core.Bitmap.Width, panorama.Core.Bitmap.Height);
      foreach (var segment in panorama.Segments)
        renderSegment(segment, offset, result);
      var result_bitmap = result.ToBitmap();
      return result_bitmap;
    }

    void renderSegment(Segment segment, Transformation context, Emgu.CV.Image<Emgu.CV.Structure.Bgr, int> template) {
      var transformation = context.Multiply(segment.Transformation);
      transformation.TransformOn(segment.Bitmap, template);      
    }

    Bitmap generateTemplate(Bitmap core_image) {
      int width = core_image.Width * 3;
      int height = core_image.Height * 3;
      var template = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
      return template;
    }
  }
}
