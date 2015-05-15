using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV.Features2D;

namespace Panoramas.Matching {
  public class MatchPresenter {
    Bitmap ImageBase, ImageQuery;
    Bitmap common_template;
    SegmentsPair match;

    public MatchPresenter(SegmentsPair match) {
      this.match = match;
      this.ImageBase = match.BaseSegment.Bitmap;
      this.ImageQuery = match.QuerySegment.Bitmap;
      this.common_template = GenerateCommonTemplate();
    }

    public Image Render() {
      var matches = match.Matches;
      float x_offset = ImageBase.Width;
      var template = (Bitmap)common_template.Clone();
      var g = Graphics.FromImage(template);
      foreach (var pair in matches) {
        var point1 = pair.Left.Point;
        DrawFeature(g, pair.Left.Point, pair.Left.Size, 0);
        var point2 = pair.Right.Point;
        DrawFeature(g, pair.Right.Point, pair.Right.Size, x_offset);
        g.DrawLine(Pens.Blue, point1.X, point1.Y, point2.X + x_offset, point2.Y);
      }
      g.Save();
      return template;
    }

    Bitmap GenerateCommonTemplate() {
      float x_offset = ImageBase.Width;
      var image_template = new Bitmap(ImageBase.Width + ImageQuery.Width, Math.Max(ImageBase.Height, ImageQuery.Height));
      var g = Graphics.FromImage(image_template);
      g.DrawImage(ImageBase, 0, 0, ImageBase.Width, ImageBase.Height);
      g.DrawImage(ImageQuery, x_offset, 0, ImageQuery.Width, ImageQuery.Height);
      return image_template;
    }

    void DrawFeature(Graphics g, PointF location, float size, float x_offset) {
      float x = location.X + x_offset;
      float y = location.Y;
      int radius = (int)(size / 2);
      g.DrawEllipse(Pens.Red, x - radius, y - radius, radius * 2, radius * 2);
    }
  }
}
