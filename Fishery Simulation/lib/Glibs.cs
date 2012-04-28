using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Fishery_Simulation
{
    class Glibs
    {


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


        public static string ReadBlockText(string filePath, int? fromLine, int? toLine)
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

        public static void WriteBlockText(string filePath, string blocktext)
        {
            TextWriter tw = new StreamWriter(filePath);
            tw.Write(blocktext);
            tw.Close();
        }




    }
}
