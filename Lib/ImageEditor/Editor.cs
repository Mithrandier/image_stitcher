using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageEditor.Tools;

namespace ImageEditor {
  public class Editor {
    PictureBox box;
    Form form;
    Graphics g;
    Point image_location;
    Size image_size;
    Scaler scaler;

    public Color BackgroundColor = Color.White;

    public Editor(Form form, PictureBox box) {
      this.form = form;
      this.box = box;
      if (box.Image == null) {
        box.Image = new Bitmap(box.Width, box.Height);
      }
      this.Image = box.Image;
      initPictureHandlers();
    }

    Image _image;
    public Image Image {
      get { return _image; }
      set {
        if (value == null)
          return;
        var new_image = (Bitmap)value.Clone();
        this._image = new_image;
        ResetState();
      }
    }

    public void ResetState() {
      this.scaler = new Scaler(box);
      this.image_size = shrinkFrameTo(this.box.Size, this.Image.Size);
      this.image_location = new Point((box.Size.Width - image_size.Width) / 2, (box.Size.Height - image_size.Height) / 2);
      refreshPicture();
    }

    void initPictureHandlers() {
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
      //if (start_point.IsEmpty)
      //  return;
      //var end_point = new Point(e.Location.X, e.Location.Y);
      //end_point.X = (int)Math.Max(0, Math.Min(end_point.X, box.Width));
      //end_point.Y = (int)Math.Max(0, Math.Min(end_point.Y, box.Height));
      //image_location.X -= Math.Min(start_point.X, e.Location.X);
      //image_location.Y -= Math.Min(start_point.Y, e.Location.Y);
      //int window_width = Math.Abs(start_point.X - end_point.X);
      //int window_height = Math.Abs(start_point.Y - end_point.Y);
      //scaler.ScaleTo(((float)box.Size.Height) / window_height);
      refreshPicture();
      start_point = Point.Empty;
    }

    const float SCALE_STEP = 0.1f;
    private void pictureMatches_MouseWheel(object sender, MouseEventArgs e) {
      if (e.Delta < 0)
        scaler.ScaleBy(-SCALE_STEP);
      else
        scaler.ScaleBy(SCALE_STEP);
      refreshPicture();
    }

    private void pictureMatches_MouseMove(object sender, MouseEventArgs e) {
      if (start_point.IsEmpty)
        return;
      var new_window = newWindow(start_point, e.Location);
      g.Clear(BackgroundColor);
      drawRectangle(new_window);
    }

    Rectangle newWindow(Point start_point, Point end_point) {
      int width = Math.Abs(start_point.X - end_point.X);
      int height = Math.Abs(start_point.Y - end_point.Y);
      Size new_size = new Size(width, height);
      var location = new Point(Math.Min(start_point.X, end_point.X), Math.Min(start_point.Y, end_point.Y));
      return new Rectangle(location, new_size);
    }

    void drawRectangle(Rectangle rect) {
      var pen = Pens.Purple;
      g.DrawLine(pen, rect.X, rect.Y, rect.Right, rect.Top);
      g.DrawLine(pen, rect.X, rect.Y, rect.Left, rect.Bottom);
      g.DrawLine(pen, rect.Right, rect.Bottom, rect.Right, rect.Top);
      g.DrawLine(pen, rect.Right, rect.Bottom, rect.Left, rect.Bottom);
      box.Refresh();
    }

    //
    // UPDATING
    //

    void refreshPicture() {
      if (g == null) {
        this.g = Graphics.FromImage(this.box.Image);
      }
      g.Clear(BackgroundColor);
      var dest_rectangle = new RectangleF(image_location, scaler.CurrentSize());
      var rect = new Rectangle(image_location, image_size);
      g.DrawImage(this.Image, rect);
      box.Refresh();
    }

    //
    // SUPPORTIVE STUFF
    //

    Size shrinkFrameTo(Size target_frame, Size object_frame) {
      Size result_frame = target_frame;
      double object_ratio = frameRatio(object_frame);
      if (frameRatio(target_frame) > object_ratio) {
        result_frame.Width = (int)(result_frame.Height * object_ratio);
      } else {
        result_frame.Height = (int)(result_frame.Width / object_ratio);
      }
      return result_frame;
    }

    double frameRatio(Size frame) {
      return frame.Width * 1.0 / frame.Height;
    }
  }
}
