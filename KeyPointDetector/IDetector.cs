using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphic;

namespace KeyPointDetector
{
    public interface IDetector
    {
      KeyPoint[] Apply();
    }
}
