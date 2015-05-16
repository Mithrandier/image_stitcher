using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageFilesManager {
  public class Dialog {
    public int MinimalFilesCount = 1;
    public int MaximalFilesCount = 100;
    public System.Windows.Forms.SaveFileDialog SaveDialog { get; private set; }
    public System.Windows.Forms.OpenFileDialog OpenDialog { get; private set; }
    public delegate void FilePathProcessor(String file_path);
    public delegate void FilePathsProcessor(String[] file_path);

    public Dialog() {
      this.SaveDialog = new System.Windows.Forms.SaveFileDialog();
      this.OpenDialog = new System.Windows.Forms.OpenFileDialog();
    }

    public void OpenFile(FilePathProcessor processor) {
      var dialog = OpenDialog;
      dialog.Multiselect = false;
      if (dialog.ShowDialog() != DialogResult.OK)
        return;
      processor.Invoke(dialog.FileName);
    }

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
