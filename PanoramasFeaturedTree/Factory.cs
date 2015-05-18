using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas.FeaturedTrees {
  public class Factory {
    public static IPublicFactory Generate() {
      return new PrivateFactory();
    }
  }
}
