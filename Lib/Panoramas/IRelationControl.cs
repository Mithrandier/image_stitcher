using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas {
  public interface IRelationControl {
    Image ToImage();
    double Distance();
    int LimitPercent { get; set; }
    bool Active { get; set; }
  }
}
