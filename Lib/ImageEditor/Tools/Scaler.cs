using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEditor.Tools {
  public class Scaler {
    public float Scale { get; private set; }
    Size original_size;

    public Scaler(System.Windows.Forms.PictureBox box) {
      this.Scale = 1;
      this.original_size = box.Size;
    }

    public SizeF CurrentSize() {
      return new SizeF(original_size.Width * Scale, original_size.Height * Scale);
    }

    public void ScaleX(float scale) {
      this.Scale *= scale;
    }

    public void ScaleBy(float scale) {
      this.Scale += scale;
    }

    public void ScaleTo(float scale) {
      this.Scale = scale;
    }
  }
}
