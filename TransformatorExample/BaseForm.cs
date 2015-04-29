using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransformatorExample {
  public partial class BaseForm : Form {
    protected delegate void Procedure();
    protected long UseTimer(Procedure proc) {
      this.Cursor = Cursors.WaitCursor;
      var timer = System.Diagnostics.Stopwatch.StartNew();
      proc.Invoke();
      timer.Stop();
      this.Cursor = Cursors.Default;
      return timer.ElapsedMilliseconds;
    }
    protected void LogTime(String operation_info, Procedure proc) {
      var time = UseTimer(proc);
      Logger.Info(String.Format("{0} - {1} ms", operation_info, time));
    }
  }
}
