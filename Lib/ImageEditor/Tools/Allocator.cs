using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEditor.Tools {
  public class Allocator {
    SizeF original_size;
    SizeF box_size;
    SizeF shrinked_size;
    SizeF boxed_size;
    PointF boxed_location;

    public Allocator(Size box_size, Size original_size) {
      this.original_size = original_size;
      this.box_size = box_size;
      resetBoxedRectangle();
    }

    public RectangleF CurrentInboxRectangle() {
      return new RectangleF(boxed_location, boxed_size);
    }

    public RectangleF CurrentImageViewPort() {
      var top_left = transformViewPointToReal(new PointF(0, 0));
      var bottom_right = transformViewPointToReal(new PointF(box_size.Width, box_size.Height));
      var port_size = new SizeF(bottom_right.X - top_left.X, bottom_right.Y - top_left.Y);
      return new RectangleF(top_left, port_size);
    }

    public void ScaleBy(float scale, Point core_location) {
      updateScale(scale, core_location);
    }

    public void MoveBy(int x, int y) {
      this.boxed_location.X += x;
      this.boxed_location.Y += y;
    }

    public Rectangle TranslateViewFrameToReal(Rectangle view_frame) {
      var top_left = transformViewPointToReal(view_frame.Location);
      var bottom_right_view = new Point(view_frame.Location.X + view_frame.Width, view_frame.Location.Y + view_frame.Height);
      var bottom_right = transformViewPointToReal(bottom_right_view);
      return new Rectangle(
        (int)top_left.X, 
        (int)top_left.Y,
        (int)(bottom_right.X - top_left.X),
        (int)(bottom_right.Y - top_left.Y));
    }

    void resetBoxedRectangle() {
      this.shrinked_size = shrinkFrameTo(box_size, original_size);
      this.boxed_size = shrinked_size;
      this.boxed_location = new PointF((box_size.Width - boxed_size.Width) / 2, (box_size.Height - boxed_size.Height) / 2);
    }

    //
    // TRANSLATIONS
    //

    PointF transformViewPointToReal(PointF view_point) {
      return transformShrinkedPointToReal(
        transformBoxedPointToShrinked(
        transformViewPointToBoxed(view_point)));
    }

    PointF transformViewPointToBoxed(PointF view_point) {
      var boxed_point = new PointF();
      boxed_point.X = view_point.X - boxed_location.X;
      boxed_point.Y = view_point.Y - boxed_location.Y;
      return boxed_point;
    }

    PointF transformBoxedPointToShrinked(PointF boxed_point) {
      var scale = boxed_size.Width / shrinked_size.Width;
      var shrinked_point = new PointF();
      shrinked_point.X = boxed_point.X / scale;
      shrinked_point.Y = boxed_point.Y / scale;
      return shrinked_point;
    }

    PointF transformShrinkedPointToReal(PointF shrinked_point) {
      var scale = shrinked_size.Width / original_size.Width;
      var real_point = new PointF();
      real_point.X = shrinked_point.X / scale;
      real_point.Y = shrinked_point.Y / scale;
      return real_point;
    }

    //
    // MODIFICATIONS
    //

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

    SizeF shrinkFrameTo(SizeF outer_frame, SizeF object_frame) {
      SizeF result_frame = outer_frame;
      var object_ratio = frameRatio(object_frame);
      var frame_ration = frameRatio(outer_frame);
      if (frame_ration > object_ratio) {
        result_frame.Width = (int)(result_frame.Height * object_ratio);
      } else {
        result_frame.Height = (int)(result_frame.Width / object_ratio);
      }
      return result_frame;
    }

    SizeF expandFrameTo(SizeF inner_frame, SizeF object_frame, out PointF expansion_offset) {
      expansion_offset = new PointF();
      SizeF result_frame = object_frame;
      double frame_ratio = frameRatio(inner_frame);
      double object_ratio = frameRatio(object_frame);
      if (frame_ratio > object_ratio) {
        result_frame.Width = (int)(result_frame.Height * frame_ratio);
        expansion_offset.X = (result_frame.Width - object_frame.Width) / 2;
      } else {
        result_frame.Height = (int)(result_frame.Width / frame_ratio);
        expansion_offset.Y = (result_frame.Height - object_frame.Height) / 2;
      }
      return result_frame;
    }

    double frameRatio(SizeF frame) {
      return frame.Width * 1.0 / frame.Height;
    }
  }
}
