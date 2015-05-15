using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilesManager.Presenters {
  interface IRefreshablePresenter {
    void RefreshWith(String[] filenames, Bitmap[] images);
  }
}
