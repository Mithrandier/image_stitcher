using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageStitcher1 {
    class Image {
        public String FileName { get; set; }
        public Image(String file_name) {
            this.FileName = file_name;

        }
    }
}
