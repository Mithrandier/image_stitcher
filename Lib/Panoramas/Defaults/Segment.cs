using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas.Defaults {
  public class Segment : IImageTransformed {
    public System.Drawing.Bitmap Bitmap { get; private set; }
    public String Name { get; private set; }
    public ITransformation Transformation { get; private set; }

    public Segment(String filename)
      : this(filename, new System.Drawing.Bitmap(filename)) {
    }

    public Segment(Segment segment)
      : this(segment.Name, segment.Bitmap) {
    }

    public Segment(String filename, System.Drawing.Bitmap image) {
      this.Name = filename;
      this.Bitmap = image;
    }

    public Segment(String filename, System.Drawing.Bitmap image, ITransformation transformation) {
      this.Name = filename;
      this.Bitmap = image;
      this.Transformation = transformation;
    }

    public override string ToString() {
      return Path.GetFileName(Name);
    }
  }
}
