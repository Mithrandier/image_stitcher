using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormTools {
  public class BrowseablePicture {
    PictureBox box;
    Form form;
    Graphics g;
    Point current_location;
    Size current_scale;

    Image _image;
    public Image Image {
      get { return _image; }
      set {
        if (value == null)
          return;
        var new_image = (Bitmap)value.Clone();
        this._image = new_image;
        this.current_scale = ShrinkFrameTo(this.box.Size, new_image.Size);
        this.current_location = new Point((box.Size.Width - current_scale.Width) / 2, (box.Size.Height - current_scale.Height) / 2);
        RefreshPicture();
      }
    }

    public BrowseablePicture(Form form, PictureBox box) {
      this.form = form;
      this.box = box;
      if (box.Image == null) {
        box.Image = new Bitmap(box.Width, box.Height);
      }
      this.Image = box.Image;
      InitPictureHandlers();
    }

    void InitPictureHandlers() {
      this.box.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureMatches_MouseDown);
      this.box.MouseEnter += new System.EventHandler(this.pictureMatches_MouseEnter);
      this.box.MouseLeave += new System.EventHandler(this.pictureMatches_MouseLeave);
      this.box.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureMatches_MouseMove);
      this.box.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureMatches_MouseUp);
      this.box.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.pictureMatches_MouseWheel);
    }

    //
    // HANDLERS
    //

    private void pictureMatches_MouseEnter(object sender, EventArgs e) {
      form.Cursor = Cursors.Hand;
      box.Focus();
    }

    Point start_point;
    private void pictureMatches_MouseLeave(object sender, EventArgs e) {
      form.Cursor = Cursors.Default;
      start_point = Point.Empty;
      form.ActiveControl = null;
    }

    private void pictureMatches_MouseDown(object sender, MouseEventArgs e) {
      start_point = e.Location;
    }

    private void pictureMatches_MouseUp(object sender, MouseEventArgs e) {
      if (start_point.IsEmpty)
        return;
      MoveTo(e.Location);
      start_point = Point.Empty;
    }

    private void pictureMatches_MouseWheel(object sender, MouseEventArgs e) {
      ScaleBy(e.Delta, e.Location);
    }

    private void pictureMatches_MouseMove(object sender, MouseEventArgs e) {
      if (start_point.IsEmpty)
        return;
      MoveTo(e.Location);
      start_point = e.Location;
    }

    //
    // UPDATING
    //

    void RefreshPicture() {
      if (g == null) {
        this.g = Graphics.FromImage(this.box.Image);
      }
      g.Clear(Color.Black);
      g.DrawImage(this.Image, current_location.X, current_location.Y, current_scale.Width, current_scale.Height);
      g.Save();
      box.Refresh();
    }

    void MoveTo(Point point) {
      if (start_point.IsEmpty)
        return;
      current_location.X += point.X - start_point.X;
      current_location.Y += point.Y - start_point.Y;
      RefreshPicture();
    }

    const float SCALE_STEP = 0.3f;
    void ScaleBy(int direction, Point mouse_location) {
      float multiplier = 1;
      if (direction < 0)
        multiplier -= SCALE_STEP;
      else
        multiplier += SCALE_STEP;
      current_scale.Width = (int)(multiplier * current_scale.Width);
      current_scale.Height = (int)(multiplier * current_scale.Height);
      int x_diff = mouse_location.X - current_location.X;
      current_location.X -= (int)(x_diff * multiplier) - x_diff;
      int y_diff = mouse_location.Y - current_location.Y;
      current_location.Y -= (int)(y_diff * multiplier) - y_diff;
      RefreshPicture();
    }

    //
    // SUPPORTIVE STUFF
    //

    Size ShrinkFrameTo(Size target_frame, Size object_frame) {
      Size result_frame = target_frame;
      double object_ratio = FrameRatio(object_frame);
      if (FrameRatio(target_frame) > object_ratio) {
        result_frame.Width = (int)(result_frame.Height * object_ratio);
      } else {
        result_frame.Height = (int)(result_frame.Width / object_ratio);
      }
      return result_frame;
    }

    double FrameRatio(Size frame) {
      return frame.Width * 1.0 / frame.Height;
    }
  }
}
