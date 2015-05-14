using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransformatorExample {
  public class ImageFilesPresenter {
    ImageList images;
    ListView list;

    public ImageFilesPresenter(ListView list) {
      this.list = list;
      this.images = new ImageList();
      this.images.ColorDepth = ColorDepth.Depth32Bit;
      this.images.ImageSize = new System.Drawing.Size(250, 200);
      this.list.ShowGroups = false;
      this.list.ShowItemToolTips = true;
      this.list.LargeImageList = images;
    }

    public bool Add(String key, System.Drawing.Bitmap image) {
      var item = list.Items.Add(key);
      images.Images.Add(item.Text, FitImage(image));
      item.ImageKey = item.Text;
      item.ToolTipText = key;
      return true;
    }

    public void Clear() {
      this.list.Items.Clear();
      images.Images.Clear();
    }

    public String[] Selected {
      get {
        List<String> keys = new List<string>();
        foreach (ListViewItem item in list.SelectedItems)
          keys.Add(item.Text);
        return keys.ToArray();
      }
    }

    public void RemoveSelected() {
      foreach (ListViewItem item in list.SelectedItems) {
        list.Items.Remove(item);
        images.Images.RemoveByKey(item.Text);
      }
    }

    Bitmap FitImage(Bitmap image) {
      var image_ratio = image.Width * 1.0f / image.Height;
      var list_ratio = images.ImageSize.Width * 1.0f / images.ImageSize.Height;
      var position = new PointF(0, 0);
      var size = images.ImageSize;
      if (image_ratio > list_ratio) {
        size.Height = (int)(images.ImageSize.Width / image_ratio);
        position.Y = (images.ImageSize.Height - size.Height) / 2;
      } else {
        size.Width = (int)(images.ImageSize.Height * image_ratio);
        position.X = (images.ImageSize.Width - size.Width) / 2;
      }
      var template = new Bitmap(images.ImageSize.Width, images.ImageSize.Height);
      var g = Graphics.FromImage(template);
      g.DrawImage(image, new RectangleF(position, size));
      g.Save();
      return template;
    }
  }
}
