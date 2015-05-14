using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransformatorExample {
  public class FilesDialog {
    public int MinimalFilesCount = 0;
    public int MaximalFilesCount = 100;
    public System.Windows.Forms.SaveFileDialog SaveDialog { get; private set; }
    public System.Windows.Forms.OpenFileDialog OpenDialog { get; private set; }

    public FilesDialog() {
      this.SaveDialog = new System.Windows.Forms.SaveFileDialog();
      this.OpenDialog = new System.Windows.Forms.OpenFileDialog();
    }

    public delegate void FilePathProcessor(String file_path);
    public void OpenFile(FilePathProcessor processor) {
      var dialog = OpenDialog;
      dialog.Multiselect = false;
      if (dialog.ShowDialog() != DialogResult.OK)
        return;
      processor.Invoke(dialog.FileName);
    }

    public delegate void FilePathsProcessor(String[] file_path);
    public void OpenFiles(FilePathsProcessor processor) {
      var dialog = OpenDialog;
      dialog.Multiselect = true;      
      if (dialog.ShowDialog() != DialogResult.OK)
        return;
      var filenames = dialog.FileNames;
      if (filenames.Length < MinimalFilesCount || filenames.Length > MaximalFilesCount)
        return;
      processor.Invoke(filenames);
    }

    public void SaveToFile(FilePathProcessor processor) {
      var dialog = SaveDialog;
      if (dialog.ShowDialog() != DialogResult.OK)
        return;
      processor.Invoke(dialog.FileName);
    }
  }
}
