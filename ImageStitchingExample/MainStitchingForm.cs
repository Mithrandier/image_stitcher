using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageStitchingExample {
  public partial class MainStitchingForm :Form {
    List<Image> segments = new List<Image>();
    Image result;
    Stitcher.IStitcher stitcher;

    public MainStitchingForm() {
      InitializeComponent();
      listSegments.LargeImageList = new ImageList();
      //stitcher = new Stitcher.EmguStitcher();
    }

    private void buttonAdd_Click(object sender, EventArgs e) {
      if (addSegmentDialog.ShowDialog() != DialogResult.OK)
        return;      
      foreach (var filename in addSegmentDialog.FileNames) {
        segments.Add(Image.FromFile(filename));
        listSegments.LargeImageList.Images.Add(segments.Last());
        listSegments.Items.Add(filename, segments.Count - 1);
      }
    }

    private void buttonStitch_Click(object sender, EventArgs e) {
      if (segments.Count < 2) {
        textResultMessage.Text = "Not enough segments";
        return;
      }
      result = stitcher.Stitch(segments.ToArray());
      pictureResult.Image = result;
    }

    private void buttonSave_Click(object sender, EventArgs e) {
      if (result == null) {
        textResultMessage.Text = "Nothing to be saved!";
        return;
      }
      if (saveResultDialog.ShowDialog() != DialogResult.OK)
        return;
      result.Save(saveResultDialog.FileName);
    }
  }
}
