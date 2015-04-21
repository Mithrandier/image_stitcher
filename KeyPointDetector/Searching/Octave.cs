using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphic;
using Graphic.Blurs;

namespace Sift.Searching {
  class Octave {
    IPicture initial_picture;
    public uint Size { get; private set; }
    public IPicture[] Pictures { get; private set; }
    public double Scale { get; private set; }

    public Octave(IPicture picture, double scale, uint size) {            
      initial_picture = picture;
      this.Scale = scale;
      this.Size = size;
    }

    public void Build(int sigma) {
      var pictures_list = new List<IPicture>();
      pictures_list.Add(initial_picture);
      while (pictures_list.Count != Size) {
        var next_picture = new GaussianNetAlgorithm(pictures_list.Last(), sigma).Apply();
        pictures_list.Add(next_picture);
      }
      Pictures = pictures_list.ToArray();
    }
  }
}
