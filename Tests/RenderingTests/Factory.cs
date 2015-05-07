using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenderingTest {
  class Factory {
    public const string VALID_FILE_NAME = "..\\..\\Resources\\2.jpg";

    public static Bitmap ABitmap() {
      return new Bitmap(VALID_FILE_NAME);
    }
  }
}
