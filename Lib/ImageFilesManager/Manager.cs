using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageFilesManager.Dialogs;
using ImageFilesManager.Presenters;

namespace ImageFilesManager {
  public class Manager {
    public List<String> FileNames { get; private set; }
    public List<Bitmap> Images { get; private set; }
    FilesDialog dialog;
    List<IRefreshablePresenter> presenters;

    public Manager() {
      this.FileNames = new List<string>();
      this.Images = new List<Bitmap>();
      this.dialog = new FilesDialog();
      this.presenters = new List<IRefreshablePresenter>();
    }

    public delegate void LoadedImagesProcessor(String[] filenames, Bitmap[] images);
    public void LoadMore(LoadedImagesProcessor processor = null) {
      dialog.OpenFiles((filenames) => {
        filenames = filenames.Except(FileNames).ToArray();
        var new_images = filenames.Select((f) => new Bitmap(f)).ToArray();
        FileNames.AddRange(filenames);
        Images.AddRange(new_images);
        refreshAll();
        processor.Invoke(filenames, new_images);
      });
    }

    public void SaveImage(Bitmap image) {
      dialog.SaveToFile((filename) => {
        image.Save(filename);
      });
    }

    public void ClearAll() {
      this.FileNames.Clear();
      this.Images.Clear();
      refreshAll();
    }

    public void RemoveImages(String[] filenames) {
      foreach (var filename in filenames) {
        int index = FileNames.IndexOf(filename);
        FileNames.RemoveAt(index);
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
      var keys = FileNames.ToArray();
      var images = Images.ToArray();
      foreach (var presenter in presenters)
        presenter.RefreshWith(keys, images);
    }
  }
}
