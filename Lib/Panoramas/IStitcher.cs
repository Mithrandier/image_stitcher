using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas {
  public interface IStitcher {
    void AddImage(String name, System.Drawing.Bitmap bitmap);
    IRelationControl MatchBetween(String image_base, String image_matched);
    System.Drawing.Bitmap StitchAll();
  }
}
