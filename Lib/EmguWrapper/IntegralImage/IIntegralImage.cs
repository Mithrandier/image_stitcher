using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmguWrapper.IntegralImage {
  public interface IIntegralImage {
    double this[int x, int y] { get; }
    int Width { get; }
    int Height { get; }
  }
}
