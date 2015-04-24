using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV.Features2D;

namespace TransformatorExample {
  class MatchesPresenter {
    FeaturedImage image1, image2;
    PictureBox picture;
    Bitmap common_template;

    public MatchesPresenter(FeaturedImage image1, FeaturedImage image2, PictureBox picture) {
      this.image1 = image1;
      this.image2 = image2;
      this.picture = picture;
      this.common_template = GenerateCommonTemplate();
    }

    public void Render(KeyPointsPair[] matches) {
      float x_offset = image1.Image.Width;
      var template = (Bitmap)common_template.Clone();
      var g = Graphics.FromImage(template);
      DrawFeatures(g, image1, 0);
      DrawFeatures(g, image2, x_offset);
      foreach (var pair in matches) {
        var point1 = pair.Feature1.KeyPoint.Point;
        var point2 = pair.Feature2.KeyPoint.Point;
        g.DrawLine(Pens.Blue, point1.X, point1.Y, point2.X + x_offset, point2.Y);
      }
      g.Save();
      picture.Image = template;
    }

    Bitmap GenerateCommonTemplate() {
      float x_offset = image1.Image.Width;
      var image_template = new Bitmap(image1.Image.Width + image2.Image.Width, Math.Max(image1.Image.Height, image2.Image.Height));
      var g = Graphics.FromImage(image_template);
      g.DrawImage(image1.Image, 0, 0, image1.Image.Width, image1.Image.Height);
      g.DrawImage(image2.Image, x_offset, 0, image2.Image.Width, image2.Image.Height);
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
