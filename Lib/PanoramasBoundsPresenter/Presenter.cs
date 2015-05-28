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
        var corners = defineCorners(panorama);
        var points = aggregateToList(corners);
        PointF offset_vector;
        var template = generateTemplate(points, out offset_vector);
        var offset = factory.Transformation();
        offset.Move((int)offset_vector.X, (int)offset_vector.Y);
        foreach (var segment in panorama.Segments)
          template = renderSegment(segment, offset, template);
        //showBounds(corners, template, offset_vector);
        return template;
      }

      List<PointF[]> defineCorners(IPanoramaTransformations panorama) {
        var bounds = new List<PointF[]>();
        foreach (var image in panorama.Segments) {
          var size = image.Bitmap.Size;
          var corners = new List<PointF>();
          corners.Add(new PointF(0, 0));
          corners.Add(new PointF(0, size.Height));
          corners.Add(new PointF(size.Width, size.Height));
          corners.Add(new PointF(size.Width, 0));
          var transformed_corners = corners.Select((c) => image.Transformation.Transform(c)).ToArray();
          bounds.Add(transformed_corners);
        }
        return bounds;
      }

      List<PointF> aggregateToList(List<PointF[]> corners) {
        return corners.Aggregate(new List<PointF>(), (list, items) => {
          list.AddRange(items);
          return list;
        });
      }

      Bitmap generateTemplate(List<PointF> points, out PointF offset) {
        float min_x = points.Min((b) => b.X);
        float max_x = points.Max((b) => b.X);
        float min_y = points.Min((b) => b.Y);
        float max_y = points.Max((b) => b.Y);
        int width = (int)((max_x - min_x) * 1.0);
        int height = (int)((max_y - min_y) * 1.0);
        var template = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
        Graphics.FromImage(template).Clear(Color.White);
        offset = new PointF(-min_x, -min_y);
        return template;
      }

      Bitmap renderSegment(IImageTransformed segment, ITransformation context, Bitmap template) {
        var transformation = context.Multiply(segment.Transformation);
        return transformation.TransformOn(segment.Bitmap, template);
      }

      void showBounds(List<PointF[]> corners, Bitmap template, PointF offset) {
        var g = Graphics.FromImage(template);
        var pen = new Pen(Color.GreenYellow, 2);
        foreach (var points in corners) {
          for (int i_point = 0; i_point < points.Length; i_point++) {
            var point = points[i_point];
            var next_point = points[(i_point + 1) % points.Length];
            g.DrawLine(pen, point.X + offset.X, point.Y + offset.Y, next_point.X + offset.X, next_point.Y + offset.Y);
          }
        }        
      }
    }
}
