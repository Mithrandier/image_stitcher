using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransformatorExample.Matchers {
  interface IMatcher {

    KeyPointsPair[] Match();
  }
}
