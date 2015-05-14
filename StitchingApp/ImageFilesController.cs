using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransformatorExample {
  public class ImageFilesController {
    public List<String> FileNames { get; private set; }
    public List<Bitmap> Images { get; private set; }
    FilesDialog dialog;
    ListView control;
    ImageFilesPresenter presenter;

    public ImageFilesController(ListView control) {
      this.FileNames = new List<string>();
      this.Images = new List<Bitmap>();
      this.dialog = new FilesDialog();
      this.dialog.MinimalFilesCount = 2;
      this.control = control;
      this.control.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
      this.presenter = new ImageFilesPresenter(control);
    }

    public delegate void LoadedImagesProcessor(String[] filenames, Bitmap[] images);
    public void LoadMore(LoadedImagesProcessor processor = null) {
      dialog.OpenFiles((filenames) => {
        filenames = filenames.Except(FileNames).ToArray();
        var new_images = filenames.Select((f) => new Bitmap(f)).ToArray();
        for (int i_file = 0; i_file < filenames.Length; i_file++) {
          presenter.Add(filenames[i_file], new_images[i_file]);
        }
        FileNames.AddRange(filenames);
        Images.AddRange(new_images);        
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
      this.presenter.Clear();
    }

    private void control_KeyDown(object sender, KeyEventArgs e) {
      if (e.KeyData == Keys.Delete) {
        foreach (var filename in presenter.Selected) {
          int index = FileNames.IndexOf(filename);
          FileNames.RemoveAt(index);
          Images.RemoveAt(index);
        }
        presenter.RemoveSelected();
      }
    }
  }
}
