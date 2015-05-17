using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV.Structure;

namespace Panoramas.FeaturesAnalyzer {
  public class KeyPointsPair {
    public MKeyPoint Left { get; private set; }
    public MKeyPoint Right { get; private set; }
    public double Distance { get; private set; }

    public KeyPointsPair(MKeyPoint left, MKeyPoint right, double distance) {
      this.Left = left;
      this.Right = right;
      this.Distance = distance;
    }
  }
}
