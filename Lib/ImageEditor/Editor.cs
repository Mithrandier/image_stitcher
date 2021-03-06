﻿using System;
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
    Allocator allocator;
    Image image;
    Image cropped_image;
    Tools.ContextMenu context_menu;

    enum Operators { Move, Crop };
    Operators current_operator;

    public Color BackgroundColor = Color.White;

    public Editor(Form form, PictureBox box, bool browseable = false) {
      this.form = form;
      this.box = box;
      var preset_image = box.Image;
      box.SizeMode = PictureBoxSizeMode.Normal;      
      box.Image = new Bitmap(box.Width, box.Height);
      this.Image = box.Image;
      if (browseable) {
        this.context_menu = new Tools.ContextMenu();
        box.ContextMenuStrip = context_menu.Control;
        initMenuItems();
        initPictureHandlers();
      }
      if (preset_image != null)
        this.Image = preset_image;
    }

    public Image Image {
      get {
        if (cropped_image != null)
          return cropped_image;
        else
          return image; 
      }
      set {
        if (value == null)
          return;
        var new_image = value;
        this.image = new_image;
        this.cropped_image = null;
        ResetState();
        refreshPicture();
      }
    }

    public void ResetState() {
      this.allocator = new Allocator(box.Size, this.Image.Size);
    }

    public Bitmap CurrentView() {
      var view_port = allocator.CurrentImageViewPort();
      var view = new Bitmap((int)view_port.Width, (int)view_port.Height);
      var g = Graphics.FromImage(view);
      var dest_rect = new RectangleF(new PointF(0, 0), view.Size);
      g.DrawImage(this.Image, dest_rect, view_port, GraphicsUnit.Pixel);
      return view;
    }

    void initMenuItems() {
      this.context_menu.AddItem("Move", new EventHandler(toolStripMenuItemMove_Click));
      this.context_menu.AddItem("Crop", new EventHandler(toolStripMenuItemCrop_Click));
      this.context_menu.AddItem("Reset", new EventHandler(toolStripMenuItemReset_Click));
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

    private void toolStripMenuItemMove_Click(object sender, EventArgs e) {
      this.current_operator = Operators.Move;
    }

    private void toolStripMenuItemCrop_Click(object sender, EventArgs e) {
      this.current_operator = Operators.Crop;
    }

    private void toolStripMenuItemReset_Click(object sender, EventArgs e) {
      this.cropped_image = null;
      ResetState();
      refreshPicture();
    }

    private void pictureMatches_MouseEnter(object sender, EventArgs e) {
      if (current_operator == Operators.Move)
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
      if (e.Button == MouseButtons.Left) {
        start_point = e.Location;
      }
    }

    private void pictureMatches_MouseUp(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left) {
        if (!start_point.IsEmpty && current_operator == Operators.Crop) {
          int min_x = Math.Min(e.Location.X, start_point.X);
          int max_x = Math.Max(e.Location.X, start_point.X);
          int min_y = Math.Min(e.Location.Y, start_point.Y);
          int max_y = Math.Max(e.Location.Y, start_point.Y);
          var selected_frame = new Rectangle(new Point(min_x, min_y), new Size(max_x - min_x, max_y - min_y));
          var cropped_frame = allocator.TranslateViewFrameToReal(selected_frame);
          var new_image = new Bitmap(cropped_frame.Width, cropped_frame.Height);
          var dest_rect = new Rectangle(new Point(0, 0), cropped_frame.Size);
          Graphics.FromImage(new_image).DrawImage(this.Image, dest_rect, cropped_frame, GraphicsUnit.Pixel);
          this.cropped_image = new_image;
          ResetState();
          refreshPicture();
        }
        start_point = Point.Empty;
      }
    }

    private void pictureMatches_MouseMove(object sender, MouseEventArgs e) {
      if (start_point.IsEmpty)
        return;
      switch (current_operator) {
        case Operators.Move:
          allocator.MoveBy(e.Location.X - start_point.X, e.Location.Y - start_point.Y);
          start_point = e.Location;
          refreshPicture();
          break;
        case Operators.Crop:
          var new_window = newWindow(start_point, e.Location);
          refreshPicture();
          drawRectangle(new_window);
          break;
      }
    }

    const float SCALE_STEP = 0.3f;
    private void pictureMatches_MouseWheel(object sender, MouseEventArgs e) {
      if (e.Delta > 0)
        allocator.ScaleBy(1-SCALE_STEP, e.Location);
      else
        allocator.ScaleBy(1+SCALE_STEP, e.Location);
      refreshPicture();
    }

    Rectangle newWindow(Point start_point, Point end_point) {
      int width = Math.Abs(start_point.X - end_point.X);
      int height = Math.Abs(start_point.Y - end_point.Y);
      Size new_size = new Size(width, height);
      var location = new Point(Math.Min(start_point.X, end_point.X), Math.Min(start_point.Y, end_point.Y));
      return new Rectangle(location, new_size);
    }

    void drawRectangle(Rectangle rect) {
      g.DrawLine(selectionPen, rect.X, rect.Y, rect.Right, rect.Top);
      g.DrawLine(selectionPen, rect.X, rect.Y, rect.Left, rect.Bottom);
      g.DrawLine(selectionPen, rect.Right, rect.Bottom, rect.Right, rect.Top);
      g.DrawLine(selectionPen, rect.Right, rect.Bottom, rect.Left, rect.Bottom);
      box.Refresh();
    }

    Pen selection_pen;
    Pen selectionPen {
      get {
        if (selection_pen == null) {
          selection_pen = new Pen(Color.White, 1);
          selection_pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
        }
        return selection_pen;
      }
    }

    //
    // UPDATING
    //

    void refreshPicture() {
      if (g == null) {
        this.g = Graphics.FromImage(this.box.Image);
      }
      g.Clear(BackgroundColor);
      g.DrawImage(this.Image, allocator.CurrentInboxRectangle());
      box.Refresh();
    }
  }
}
