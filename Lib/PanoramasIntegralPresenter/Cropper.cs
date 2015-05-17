using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas.IntegralPresenter {
  public class Cropper {
    Bitmap image;
    EmguWrapper.IntegralImage.IIntegralImage integral;

    public Cropper(Bitmap image, Factory factory) {
      this.image = image;
      this.integral = factory.Integral(image);
    }

    public Bitmap AutoCrop() {
      Bitmap cropped_image = null;
      Rectangle bounds = DefineContentBounds();
      cropped_image = new Bitmap(bounds.Width, bounds.Height);
      var g = Graphics.FromImage(cropped_image);
      g.DrawImage(image, new Rectangle(0, 0, cropped_image.Width, cropped_image.Height), bounds, GraphicsUnit.Pixel);
      g.Save();
      return cropped_image;
    }

    Rectangle DefineContentBounds() {
      int bottom_y = -1;
      double current_value, down_value;
      do {
        bottom_y += 1;
        current_value = integral[image.Width - 1, bottom_y];
      } while ((current_value == 0 || Double.IsInfinity(current_value)) && bottom_y < image.Height - 2);

      int top_y = image.Height;
      do {
        top_y -= 1;
        current_value = integral[image.Width - 1, top_y];
        down_value = integral[image.Width - 1, top_y - 1];
      } while (top_y > bottom_y + 1 && (current_value == down_value));

      int bottom_x = -1;
      do {
        bottom_x += 1;
        current_value = integral[bottom_x, image.Height - 1];
      } while ((current_value == 0 || Double.IsInfinity(current_value)) && bottom_x < image.Width - 2);
      int top_x = image.Width;
      do {
        top_x -= 1;
        current_value = integral[top_x, image.Height - 1];
        down_value = integral[top_x - 1, image.Height - 1];
      } while (top_x > bottom_x + 1 && (current_value == down_value));
      var location = new Point(bottom_x, bottom_y);
      var size = new Size(top_x - bottom_x, top_y - bottom_y);
      return new Rectangle(location, size);
    }

    double[] CollectIntergralGrayColumn(int x) {
      double[] column = new double[integral.Height];
      for (int y = 0; y < integral.Height; y++) {
        column[y] = integral[x, y];
      }
      return column;
    }

    double[] CollectIntergralGrayRow(int y) {
      double[] row = new double[integral.Width];
      for (int x = 0; x < integral.Width; x++) {
        row[x] = integral[x, y];
      }
      return row;
    }
  }
}
