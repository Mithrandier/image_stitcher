using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas {
  public interface IPublicFactory {
    IStitcher Stitcher(String[] files, System.Drawing.Bitmap[] bitmaps = null);
  }
}
