using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilesManager {
  public class ImageFile {
    public String FileName { get; private set; }
    public Bitmap Bitmap { get; private set; }

    public ImageFile(String filename, Bitmap bitmap = null) {
      this.FileName = filename;
      if (bitmap != null) {
        this.Bitmap = bitmap;
      } else {
        this.Bitmap = new Bitmap(filename);
      }
    }
  }
}
