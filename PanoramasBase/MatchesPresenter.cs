using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV.Features2D;

namespace Panoramas {
  public class MatchesPresenter {
    Bitmap ImageBase, ImageQuery;
    Bitmap common_template;
    SegmentsMatch match;

    public MatchesPresenter(SegmentsMatch match) {
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
        var point1 = pair.FeatureLeft.KeyPoint.Point;
        DrawFeature(g, pair.FeatureLeft, 0);
        var point2 = pair.FeatureRight.KeyPoint.Point;
        DrawFeature(g, pair.FeatureRight, x_offset);
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

    void DrawFeature(Graphics g, ImageFeature<float> feature, float x_offset) {
      var point = feature.KeyPoint.Point;
      float x = point.X + x_offset;
      float y = point.Y;
      int radius = (int)(feature.KeyPoint.Size / 2);
      g.DrawEllipse(Pens.Red, x - radius, y - radius, radius * 2, radius * 2);
    }
  }
}
