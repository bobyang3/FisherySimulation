using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Reflection;
using System.ComponentModel;

namespace Fishery_Simulation
{
    class Glibs

    {

        public static void DeleteFolder(System.IO.DirectoryInfo directory)
        {
            foreach (System.IO.FileInfo file in directory.GetFiles()) file.Delete();
            foreach (System.IO.DirectoryInfo subDirectory in directory.GetDirectories()) subDirectory.Delete(true);
        }

        public static IEnumerable<Control> GetControls(Control form)
        {
            foreach (Control childControl in form.Controls)
            {   // Recurse child controls.
                foreach (Control grandChild in GetControls(childControl))
                {
                    yield return grandChild;
                }
                yield return childControl;
            }
        }

        public static List<Control> GetControls2(Control form)
        {
            var controlList = new List<Control>();

            foreach (Control childControl in form.Controls)
            {
                // Recurse child controls.
                controlList.AddRange(GetControls2(childControl));
                controlList.Add(childControl);
            }
            return controlList;
        }


        public static int GetCPUCore()
        {
           return Environment.ProcessorCount;
        }


        public static string ReadLineText(string filePath, int? fromLine, int? toLine)
        {
            StringBuilder sb = new StringBuilder();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                int currentLine = 1;
                while ((line = reader.ReadLine()) != null)
                {
                    if (currentLine >= fromLine && currentLine <= toLine)
                    {
                        sb.AppendLine(line);
                    }
                    else if (currentLine > toLine)
                    {
                        break;
                    }
                    currentLine = currentLine+1;
                }
            }
            return sb.ToString().Trim();
        }

        public static List<string> ReadText(string filePath)
        {
           // return File.ReadAllLines(filePath);
            return File.ReadAllLines(filePath).ToList();
        }

        public static string[] ReadText2(string filePath)
        {
            // return File.ReadAllLines(filePath);
            return File.ReadAllLines(filePath);
        }



        public static void WritelineText(string filePath, string blocktext)
        {
            TextWriter tw = new StreamWriter(filePath);
            tw.Write(blocktext);
            tw.Close();
        }

        public static string toStringNullable(object o1)
        {
            return o1 == null ? null : o1.ToString().Trim(); 
        }

        public static int? tointNullable(object o1)
        {
            return o1 == null ? (int?)null : int.Parse(o1.ToString());
        }






    }
}
