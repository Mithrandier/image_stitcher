using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Panoramas;

namespace PanoramasBaseTests {
  class Factory {
    public const string VALID_FILE_NAME = "..\\..\\Resources\\2.jpg";
    public const string VALID_FILE_NAME_2 = "..\\..\\Resources\\1.jpg";
    public const string INVALID_FILE_NAME = "..\\..\\Resources\\?.jpg";

    public static Bitmap ABitmap() {
      return new Bitmap(VALID_FILE_NAME);
    }
  }
}
