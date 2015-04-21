using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stitcher
{
    public interface IStitcher
    {
      System.Drawing.Image Stitch(System.Drawing.Image[] segments);
    }
}
