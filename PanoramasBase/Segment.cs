using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas {
  public class Segment {
    public System.Drawing.Bitmap Bitmap { get; private set; }
    public String Filename { get; private set; }

    public Segment(String filename) {
      this.Filename = filename;
      if (!File.Exists(filename))
        throw new FileNotFoundException();
      this.Bitmap = new System.Drawing.Bitmap(Filename);
    }

    public Segment(Segment base_segment) {
      this.Filename = base_segment.Filename;
      this.Bitmap = base_segment.Bitmap;
    }
  }
}
