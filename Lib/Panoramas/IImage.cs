using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas {
  public interface IImage {
    System.Drawing.Bitmap Bitmap { get; }
    String Name { get; }
  }
}
