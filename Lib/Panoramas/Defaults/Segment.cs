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

    public Segment(Segment segment)
      : this(segment.Name, segment.Bitmap) {
    }

    public Segment(String filename, System.Drawing.Bitmap bitmap = null) {
      if (filename == null)
        throw new ArgumentNullException();
      if (bitmap == null)
        bitmap = (System.Drawing.Bitmap)System.Drawing.Bitmap.FromFile(filename);
      this.Name = filename;
      this.Bitmap = bitmap;
    }

    public Segment(IImage image, ITransformation transformation) {
      this.Name = image.Name;
      this.Bitmap = image.Bitmap;
      this.Transformation = transformation;
    }

    public override string ToString() {
      return Path.GetFileName(Name);
    }
  }
}
