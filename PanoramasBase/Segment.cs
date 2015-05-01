using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas {
  public class Segment {
    public System.Drawing.Bitmap Bitmap { get; private set; }
    public String Filename { get; private set; }

    public Segment(String filename) {
      this.Filename = filename;
      this.Bitmap = new System.Drawing.Bitmap(Filename);
    }
  }
}
