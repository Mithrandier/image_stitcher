using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Panoramas;

namespace Panoramas.BoundsPresenter
{
    public class Presenter: Panoramas.Processors.IPresenter
    {
      IFactory factory;

      public Presenter(IFactory factory) {
        this.factory = factory;
      }

      public Bitmap Present(IPanoramaTransformations panorama) {
        PointF offset_vector;
        var template = generateTemplate(panorama, out offset_vector);
        var offset = factory.Transformation();
        offset.Move((int)offset_vector.X, (int)offset_vector.Y);
        foreach (var segment in panorama.Segments)
          template = renderSegment(segment, offset, template);
        return template;
      }

      Bitmap renderSegment(IImageTransformed segment, ITransformation context, Bitmap template) {
        var transformation = context.Multiply(segment.Transformation);
        return transformation.TransformOn(segment.Bitmap, template);
      }

      Bitmap generateTemplate(IPanoramaTransformations panorama, out PointF offset) {
        List<PointF> bounds = new List<PointF>();
        foreach (var image in panorama.Segments) {
          var size = image.Bitmap.Size;
          List<PointF> corners = new List<PointF>();
          corners.Add(new PointF(0, 0));
          corners.Add(new PointF(0, size.Height));
          corners.Add(new PointF(size.Width, 0));
          corners.Add(new PointF(size.Width, size.Height));
          var transformed_corners = corners.Select((c) => image.Transformation.Transform(c));
          bounds.AddRange(transformed_corners);
        }
        float min_x = bounds.Min((b) => b.X);
        float max_x = bounds.Max((b) => b.X);
        float min_y = bounds.Min((b) => b.Y);
        float max_y = bounds.Max((b) => b.Y);
        int width = (int)((max_x - min_x) * 1.0);
        int height = (int)((max_y - min_y) * 1.0);
        var template = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
        Graphics.FromImage(template).Clear(Color.White);
        offset = new PointF(-min_x, -min_y);
        return template;
      }
    }
}
