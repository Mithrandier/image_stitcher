using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas.IntegralPresenter {
  public class Presenter : IResultPresenter {
    IFactory factory;

    public Presenter(IFactory factory) {
      this.factory = factory;
    }

    public Bitmap Render(IPanoramaComplete panorama) {
      var template = generateTemplate(panorama.Core().Bitmap);
      var result = new Emgu.CV.Image<Emgu.CV.Structure.Bgr, int>((Bitmap)template.Clone());
      var offset = factory.Transformation();
      offset.Move(panorama.Core().Bitmap.Width, panorama.Core().Bitmap.Height);
      foreach (var segment in panorama.Segments)
        renderSegment(segment, offset, result);
      var result_bitmap = result.ToBitmap();
      var cropped_bitmap = new Cropper(result_bitmap, new Factory()).AutoCrop();
      return cropped_bitmap;
    }

    void renderSegment(ISegment segment, ITransformation context, Emgu.CV.Image<Emgu.CV.Structure.Bgr, int> template) {
      var transformation = context.Multiply(segment.Transformation);
      transformation.TransformOn(segment.Bitmap, template.ToBitmap());      
    }

    Bitmap generateTemplate(Bitmap core_image) {
      int width = core_image.Width * 3;
      int height = core_image.Height * 3;
      var template = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
      return template;
    }
  }
}
