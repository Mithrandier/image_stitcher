using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmguWrapper.IntegralImage {
  public class Factory : Rendering.IFactory {
    public Rendering.IIntegralImage IntegralImage(System.Drawing.Bitmap bitmap) {
      return new IntegralImage(bitmap);
    }
  }
}
