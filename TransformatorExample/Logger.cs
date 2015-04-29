using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransformatorExample {
  class Logger {
    const string DEFAULT_NAME = "log.txt";
    static String filename = DEFAULT_NAME;

    public static void SetFile(String filename) {
      Logger.filename = filename;
    }

    public static void Info(String text) {
      var formatted_text = String.Format("\r\n{0}:\r\n{1}\r\n", DateTime.Now.ToString(), text);
      File.AppendAllText(Logger.filename, formatted_text);
    }
  }
}
