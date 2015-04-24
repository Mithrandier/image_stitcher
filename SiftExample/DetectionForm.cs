using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV.Structure;

namespace SiftExample {
  public partial class DetectionForm : Form {
    Image loaded_image, current_image;

    public DetectionForm() {
      InitializeComponent();
      var detector = new Emgu.CV.Features2D.SIFTDetector();
    }

    private void buttonLoad_Click(object sender, EventArgs e) {
      if (loadImageDialog.ShowDialog() != DialogResult.OK)
        return;
      loaded_image = Image.FromFile(loadImageDialog.FileName);
      current_image = (Image)loaded_image.Clone();
      pictureCurrent.Image = current_image;
    }

    private void buttonDetectFeatures_Click(object sender, EventArgs e) {
      var detector = new Emgu.CV.Features2D.SIFTDetector();
      var timer = System.Diagnostics.Stopwatch.StartNew();
      var features = detector.DetectFeatures(new Emgu.CV.Image<Gray, byte>((Bitmap)current_image), null);
      timer.Stop();
      textTime.Text = timer.ElapsedMilliseconds.ToString();
      textPointsCount.Text = features.Length.ToString();
      var g = Graphics.FromImage(current_image);
      foreach (var feature in features) {
        g.DrawEllipse(Pens.Red, feature.KeyPoint.Point.X, feature.KeyPoint.Point.Y, 10, 10);
      }
      g.Save();
      pictureCurrent.Image = current_image;
      return;
    }

    private void buttonResetImage_Click(object sender, EventArgs e) {
      current_image = (Image)loaded_image.Clone();
      pictureCurrent.Image = current_image;
    }
  }
}
