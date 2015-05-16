using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilesManager {
  public interface ISelectableControl {
    String[] SelectedItems();
    void AddSelectionChangeHandler(EventHandler handler);
  }
}
