using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas {
  public interface IImagesMatch {
    Image ToImage();
    double Distance();
    void SetLimit(int percent);
    int CurrentLimit();
    bool IsActive { get; set; }
  }
}
