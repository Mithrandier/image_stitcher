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
    public Transformation Transformation { get; private set; }
    public bool BelongsToPan = false;

    public Segment(String filename) {
      this.Filename = filename;
      if (!File.Exists(filename))
        throw new FileNotFoundException();
      this.Bitmap = new System.Drawing.Bitmap(Filename);
      ResetTransformation();
    }

    public Segment(Segment base_segment) {
      this.Filename = base_segment.Filename;
      this.Bitmap = base_segment.Bitmap;
      ResetTransformation();
    }

    public void ResetTransformation() {
      this.Transformation = new Transformation();
    }

    public override string ToString() {
      return Path.GetFileName(Filename);
    }
  }
}
