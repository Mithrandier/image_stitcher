using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas.IntegralPresenter {
  public class Factory {
    public EmguWrapper.IntegralImage.IIntegralImage Integral(System.Drawing.Bitmap bitmap) {
      return new EmguWrapper.IntegralImage.IntegralImage(bitmap);
    }
  }
}
