using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEditor.Tools {
  public class Allocator {
    Image original;
    SizeF box_size;
    SizeF current_size;
    PointF current_location;
    SizeF boxed_size;
    PointF boxed_location;

    Image boxed_image = null;
    public Image BoxedImage {
      get {
        if (boxed_image == null) {
          this.boxed_image = new Bitmap((int)box_size.Width, (int)box_size.Height);
          Graphics.FromImage(boxed_image).DrawImage(original, CurrentInboxRectangle());
        }
        return boxed_image;
      }
    }

    public Allocator(System.Windows.Forms.PictureBox box, Image original) {
      this.original = original;
      this.box_size = box.Size;
      this.current_size = original.Size;
      this.current_location = new Point(0, 0);
      resetBoxedRectangle();
    }

    void resetBoxedRectangle() {
      this.boxed_size = shrinkFrameTo(box_size, current_size);
      this.boxed_location = new PointF((box_size.Width - boxed_size.Width) / 2, (box_size.Height - boxed_size.Height) / 2);
    }

    public RectangleF CurrentRectangle() {
      return new RectangleF(current_location, current_size);
    }

    public RectangleF CurrentInboxRectangle() {
      return new RectangleF(boxed_location, boxed_size);
    }

    public void ScaleBy(float scale, Point core_location) {
      updateScale(scale, core_location);
    }

    public void MoveBy(int x, int y) {
      this.boxed_location.X += x;
      this.boxed_location.Y += y;
    }

    public void SetFrame(Rectangle new_frame) {
      this.current_location.X += new_frame.Location.X - boxed_location.X;
      this.current_location.Y += new_frame.Location.Y - boxed_location.Y;
      resetBoxedRectangle();
    }

    bool allowScale(float new_scale) {
      return new_scale >= 0.2 && new_scale <= 5;
    }  

    const int MINIMAL_SIDE_LENGTH = 100;
    const int MAXIMAL_SIDE_LENGTH = 10000;
    void updateScale(float new_scale, Point core_location) {
      var div_scale = 1.0f / new_scale;
      var scaled_size = scaledBoxSize(div_scale);
      if (Math.Min(scaled_size.Width, scaled_size.Height) < MINIMAL_SIDE_LENGTH ||
          Math.Max(scaled_size.Width, scaled_size.Height) > MAXIMAL_SIDE_LENGTH)
        return;
      this.boxed_size = scaled_size;
      this.boxed_location = scaledBoxLocation(div_scale, core_location);
    }

    SizeF scaledBoxSize(float scale) {
      var scaled_size = new SizeF();
      scaled_size.Width = boxed_size.Width * scale;
      scaled_size.Height = boxed_size.Height * scale;
      return scaled_size;
    }

    PointF scaledBoxLocation(float scale, Point stick_location) {
      var scaled_location = new PointF();
      var cur_dif_x = stick_location.X - boxed_location.X;
      var cur_dif_y = stick_location.Y - boxed_location.Y;
      scaled_location.X = stick_location.X - cur_dif_x * scale;
      scaled_location.Y = stick_location.Y - cur_dif_y * scale;
      return scaled_location;
    }

    //
    // SUPPORTIVE STUFF
    //

    double frameRatio(SizeF frame) {
      return frame.Width * 1.0 / frame.Height;
    }

    SizeF shrinkFrameTo(SizeF target_frame, SizeF object_frame) {
      SizeF result_frame = target_frame;
      double object_ratio = frameRatio(object_frame);
      if (frameRatio(target_frame) > object_ratio) {
        result_frame.Width = (int)(result_frame.Height * object_ratio);
      } else {
        result_frame.Height = (int)(result_frame.Width / object_ratio);
      }
      return result_frame;
    }
  }
}
