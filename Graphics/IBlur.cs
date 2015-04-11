using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic {
  public interface IBlur {
    int Radius { get; }
    IPicture Apply();
  }
}
