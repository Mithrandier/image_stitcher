using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageFilesManager.Presenters;

namespace ImageFilesManager {
  public class CollectionManager {
    public List<ImageFile> Images { get; private set; }
    public delegate void LoadedImagesProcessor(ImageFile[] filenames);

    Dialog dialog;
    List<IRefreshablePresenter> presenters;

    public CollectionManager() {
      this.Images = new List<ImageFile>();
      this.dialog = new Dialog();
      this.presenters = new List<IRefreshablePresenter>();
    }

    public void LoadMore(LoadedImagesProcessor processor = null) {
      dialog.OpenFiles((filenames) => {
        var present_filenames = Images.Select((i) => i.FileName);
        filenames = filenames.Except(present_filenames).ToArray();
        var new_images = filenames.Select((f) => new ImageFile(f)).ToArray();
        Images.AddRange(new_images);
        refreshAll();
        processor.Invoke(new_images);
      });
    }

    public void ClearAll() {
      this.Images.Clear();
      refreshAll();
    }

    public void Remove(String[] filenames) {
      foreach (var filename in filenames) {
        int index = Images.FindIndex((i) => i.FileName == filename);
        Images.RemoveAt(index);
      }
      refreshAll();
    }

    public ISelectableControl PresentAsListView(ListView list) {
      var presenter = new ThumbnailsList(list);
      presenters.Add(presenter);
      return presenter;
    }

    public ISelectableControl PresentAsPairsList(ListBox main_list, ListBox sub_list) {
      var presenter = new PairsList(main_list, sub_list);
      presenters.Add(presenter);
      return presenter;
    }

    void refreshAll() {
      foreach (var presenter in presenters)
        presenter.RefreshWith(Images.ToArray());
    }
  }
}
