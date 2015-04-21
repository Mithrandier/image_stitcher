using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Graphic;
using Graphic.Pictures;
using Graphic.Blurs;

namespace ImageStitcher {
    public partial class MainForm :Form {
        IPicture current_image;
        String current_file_path;
        IPicture CurrentImage {
            get { return current_image; }
            set {
                current_image = value;
                performToolStripMenuItem.Enabled = true;
                currentPictureBox.Image = current_image.ToBitmap();
            }
        }

        public MainForm() {
            InitializeComponent();
        }

        private delegate void procedure();
        private void CountTime(procedure proc) {
          var timer = System.Diagnostics.Stopwatch.StartNew();
          proc.Invoke();
          timer.Stop();
          textTimer.Text = String.Format("{0} ms", timer.ElapsedMilliseconds.ToString());
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }

        private void iterateToolStripMenuItem_Click(object sender, EventArgs e) {
          CountTime(() => current_image.EachPixel((x, y, p) => { uint z = p; }));
        }

        private void resetPixelsToolStripMenuItem_Click(object sender, EventArgs e) {
          CountTime(() => current_image.EachPixel((x, y, p) => { current_image[x, y] = p; }));
        }

        private void loadRawToolStripMenuItem_Click(object sender, EventArgs e) {
          if (loadImageDialog.ShowDialog() != DialogResult.OK)
            return;
          current_file_path = loadImageDialog.FileName;
          CurrentImage = new RawImage(current_file_path);
        }

        private void gaussBlurToolStripMenuItem_Click(object sender, EventArgs e) {
          CountTime(() => {
            var filter = new GaussianNetAlgorithm(CurrentImage, 2);
            var result_image = filter.Apply();
            CurrentImage = result_image;
          });
        }

        private void scale2xToolStripMenuItem_Click(object sender, EventArgs e) {
          CurrentImage = CurrentImage.Scale(0.5);
        }

        private void buildScaleSpaceToolStripMenuItem_Click(object sender, EventArgs e) {
          new Sift.Searching.GaussPyramid(CurrentImage).Build(4, 2, 4);
        }
    }
}
