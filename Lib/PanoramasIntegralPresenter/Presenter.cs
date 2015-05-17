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

    public Bitmap Render(IPanoramaTransformations panorama) {
      var template = generateTemplate(panorama.Core().Bitmap);
      var offset = factory.Transformation();
      offset.Move(panorama.Core().Bitmap.Width, panorama.Core().Bitmap.Height);
      foreach (var segment in panorama.Segments)
        template = renderSegment(segment, offset, template);
      var cropped_bitmap = new Cropper(template, new Factory()).AutoCrop();
      return cropped_bitmap;
    }

    Bitmap renderSegment(IImageTransformed segment, ITransformation context, Bitmap template) {
      var transformation = context.Multiply(segment.Transformation);
      return transformation.TransformOn(segment.Bitmap, template);      
    }

    Bitmap generateTemplate(Bitmap core_image) {
      int width = core_image.Width * 3;
      int height = core_image.Height * 3;
      var template = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
      return template;
    }
  }
}
