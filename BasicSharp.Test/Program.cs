﻿using System;
using System.IO;
using System.Windows.Forms;
namespace OpenSBP.Test {
    class Program {
        [STAThread]  // needed for the file open dialog.
        static void Main(string[] args) {
            OpenFileDialog fDialog = new OpenFileDialog();
            string fileName = "";
            if (fDialog.ShowDialog() == DialogResult.OK) {
                fileName = fDialog.FileName;
                fDialog.Dispose();
                Interpreter basic = new Interpreter(File.ReadAllText(fileName));
                basic.StandAlone = true;  // prevents console redirect ops.

                try {
                    Console.WriteLine("OpenSBPCore Intepreter Start.");
                    Console.WriteLine("----------------------------\n");
                    basic.Exec();
                    Console.WriteLine("No errors during run.");
                } catch (Exception e) {
                    Console.WriteLine("Runtime Error detected - aborting.");
                    Console.WriteLine("Exception was " + e.Message);
                    //Console.WriteLine("stack trace:" + e.StackTrace.ToString());
                }
            }
          
            Console.WriteLine("Run complete, press [ENTER] to exit.");
            Console.Read();
        }
    }
}
