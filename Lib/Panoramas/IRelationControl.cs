using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas {
  public interface IRelationControl {
    Bitmap ToImage();
    double Similarity();
    int LimitPercent { get; set; }
    bool Active { get; set; }
  }
}
