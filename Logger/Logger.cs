using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panoramas.Logger
{
    public delegate void Procedure();

    public class Logger {
      const string DEFAULT_NAME = "log.txt";
      static String filename = DEFAULT_NAME;

      public static void SetFile(String filename) {
        Logger.filename = filename;
      }

      public static void Info(String text) {
        var formatted_text = String.Format("{0}: {1}\r\n", DateTime.Now.ToString(), text);
        File.AppendAllText(Logger.filename, formatted_text);
      }

      public static long UseTimer(Procedure proc) {
        var timer = System.Diagnostics.Stopwatch.StartNew();
        proc.Invoke();
        timer.Stop();
        return timer.ElapsedMilliseconds;
      }

      public static void LogTime(String operation_info, Procedure proc) {
        var time = UseTimer(proc);
        Logger.Info(String.Format("{0} - {1} ms", operation_info, time));
      }
    }
}
