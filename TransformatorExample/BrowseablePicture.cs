using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransformatorExample {
  class BrowseablePicture {
    PictureBox box;
    Form form;
    Image image;
    Image canvas;

    Point start_point;
    Point current_location;
    Size current_scale;

    Graphics g;

    public BrowseablePicture(Form form, PictureBox box) {
      this.form = form;
      this.box = box;
      this.box.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureMatches_MouseDown);
      this.box.MouseEnter += new System.EventHandler(this.pictureMatches_MouseEnter);
      this.box.MouseLeave += new System.EventHandler(this.pictureMatches_MouseLeave);
      this.box.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureMatches_MouseMove);
      this.box.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureMatches_MouseUp);
      this.box.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.pictureMatches_MouseWheel);
      this.image = (Bitmap)box.Image.Clone();
      current_location = new Point(0, 0);
      current_scale = this.image.Size;
      canvas = new Bitmap(this.image.Width, this.image.Height);
      g = Graphics.FromImage(box.Image);
    }

    private void pictureMatches_MouseEnter(object sender, EventArgs e) {
      form.Cursor = Cursors.Hand;
      box.Focus();
    }

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
      var original_image = this.image;
      var new_image = new Bitmap(original_image.Width, original_image.Height);
      float multiplier = 1;
      float diff = 0.3f;
      if (e.Delta < 0)
        multiplier -= diff;
      else
        multiplier += diff;
      current_scale.Width = (int)(multiplier * current_scale.Width);
      current_scale.Height = (int)(multiplier * current_scale.Height);
      int x_diff = e.Location.X - current_location.X;
      current_location.X += (int)(x_diff * multiplier) - x_diff;
      int y_diff = e.Location.Y - current_location.Y;
      current_location.Y += (int)(y_diff * multiplier) - y_diff;
      RefreshPicture();
    }

    private void pictureMatches_MouseMove(object sender, MouseEventArgs e) {
      if (start_point.IsEmpty)
        return;
      MoveTo(e.Location);
      start_point = e.Location;
    }

    void MoveTo(Point point) {
      if (start_point.IsEmpty)
        return;
      current_location.X += point.X - start_point.X;
      current_location.Y += point.Y - start_point.Y;
      RefreshPicture();
    }

    void RefreshPicture() {
      g.Clear(Color.Green);
      g.DrawImage(image, current_location.X, current_location.Y, current_scale.Width, current_scale.Height);
      g.Save();
      box.Refresh();
    }
  }
}
