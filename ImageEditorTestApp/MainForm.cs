using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageEditor;

namespace ImageEditorTestApp {
  public partial class MainForm : Form {
    public MainForm() {
      InitializeComponent();
      var editor = new ImageEditor.Editor(this, pictureThe, true);
      editor.Image = ImageEditorTestApp.Properties.Resources.Nature_Wallpaper_daydreaming_34811098_1024_768__1_;
    }
  }
}
