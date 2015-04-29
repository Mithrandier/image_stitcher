using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV.Features2D;

namespace Matcher {
  public class MatchesPresenter {
    FeaturedImage image_left, image_right;
    PictureBox picture;
    Bitmap common_template;

    public MatchesPresenter(FeaturedImage image_left, FeaturedImage image_right, PictureBox picture) {
      this.image_left = image_left;
      this.image_right = image_right;
      this.picture = picture;
      this.common_template = GenerateCommonTemplate();
    }

    public void Render(KeyPointsPair[] matches) {
      float x_offset = image_left.Width;
      var template = (Bitmap)common_template.Clone();
      var g = Graphics.FromImage(template);
      DrawFeatures(g, image_left, 0);
      DrawFeatures(g, image_right, x_offset);
      foreach (var pair in matches) {
        var point1 = pair.FeatureLeft.KeyPoint.Point;
        var point2 = pair.FeatureRight.KeyPoint.Point;
        g.DrawLine(Pens.Blue, point1.X, point1.Y, point2.X + x_offset, point2.Y);
      }
      g.Save();
      picture.Image = template;
    }

    Bitmap GenerateCommonTemplate() {
      float x_offset = image_left.Width;
      var image_template = new Bitmap(image_left.Width + image_right.Width, Math.Max(image_left.Height, image_right.Height));
      var g = Graphics.FromImage(image_template);
      g.DrawImage(image_left.Image, 0, 0, image_left.Width, image_left.Height);
      g.DrawImage(image_right.Image, x_offset, 0, image_right.Width, image_right.Height);
      return image_template;
    }

    void DrawFeatures(Graphics g, FeaturedImage image, float x_offset) {
      image.IterateFeatures((feature, iFeature) => {
        var point = feature.KeyPoint.Point;
        float x = point.X + x_offset;
        float y = point.Y;
        int radius = (int)(feature.KeyPoint.Size / 2);
        g.DrawEllipse(Pens.Red, x - radius, y - radius, radius * 2, radius * 2);
      });
    }
  }
}
