using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransformatorExample {
  static class Program {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main() {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      try {
        var panoramas_factory = Panoramas.FeaturedTrees.Factory.Generate();
        Application.Run(new MainForm(panoramas_factory));
      } catch (Exception ex) {
        Logger.Logger.Info(ex.ToString());
        MessageBox.Show("The program unexpectedly ended. Please, contact us to fix the problem");
      }
    }
  }
}
