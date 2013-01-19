using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Reflection;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace Fishery_Simulation
{
    class Glibs

    {

        public static void DeleteFolder(System.IO.DirectoryInfo directory)
        {
            foreach (System.IO.FileInfo file in directory.GetFiles()) file.Delete();
            foreach (System.IO.DirectoryInfo subDirectory in directory.GetDirectories()) subDirectory.Delete(true);
        }

        public static bool createSubFolders(int numberOfSubFolder, string rootFolderPath)
        {
            try
            {
                System.Threading.Tasks.Parallel.For(1, numberOfSubFolder, i =>
                {
                    {
                        string newPath = Path.Combine(rootFolderPath, i.ToString());
                        Directory.CreateDirectory(newPath);
                    }
                });
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.ToString());
            }
            return true;
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


        public static string ReadLineText(string filePath, int? fromLine, int? toLine, bool blinsertInFront, string insertInFront, string delimited )
        {
            try
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
                            if (blinsertInFront == true)
                            { sb.AppendLine(insertInFront + delimited+ line); }
                            else
                            { sb.AppendLine(line); }
                        }
                        else if (currentLine > toLine)
                        {
                            break;
                        }
                        currentLine = currentLine + 1;
                    }
                }
                return sb.ToString().Trim();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error on ReadLineText: \r" + e.ToString());
                return "";
            }
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

        


        public static void WritelineText(string filePath, string text)
        {
            TextWriter tw = new StreamWriter(filePath);
            tw.Write(text);
            tw.Close();
        }

        public static string toStringNullable(object o1)
        {
            return o1 == null ? null : o1.ToString(); 
        }

        public static int? tointNullable(object o1)
        {
            return (o1 == null || o1.ToString()== "") ? (int?)null : int.Parse(o1.ToString());
        }

        public static bool? toboolNullable(object o1)
        {
            return (o1 == null || o1.ToString() == "") ? (bool?)null : bool.Parse(o1.ToString());
        }



        public static bool deleteEmptyRows (DataTable dt, string trigerFieldName)
        {
            ////delete empty rows
            List<DataRow> deletedRows = new List<DataRow>();

            foreach (DataRow dr in dt.Rows)
            {
                if (dr[trigerFieldName].ToString().Trim().Length <= 0) deletedRows.Add(dr);
            }

            foreach (DataRow dataRow in deletedRows)
            {
                dataRow.Delete();
            }

            return true;
        }

        public static List<DataRow> checkFileExist(DataTable dt, string sourceDirectory, string filenameFieldName)
        {
            List<DataRow> deletedRows = new List<DataRow>();

            return deletedRows;
        }


        public static double NORMSDIST(double Zscore)
        {
            double Z = -(Zscore * Zscore) / 2;
            double normDist = (1 / Math.Sqrt(2 * Math.PI)) * (Math.Exp(Z));

            return normDist;
        }


        public static int? findIndexOfKeyWord(List<string> strs, string keywords)
        {
            try
            {
                return strs.IndexOf(strs.Find(s => s.Contains(keywords)));
            }
            catch {
                return null;
            }
        }

        /// <summary>
        /// Creates the rand norm.
        /// </summary>
        /// <param name="valuesLine">The values line.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <param name="x">if x=NULL, then using rand double value for each one</param>
        /// <param name="mean">The mean.</param>
        /// <param name="std">The STD.</param>
        /// <param name="cumulative">if set to <c>true</c> [cumulative].</param>
        /// <returns></returns>
        public static string CreateRandNorm(string valuesLine, string delimiter, double? x, double mean, double std, bool cumulative)
        {

            string[] values = Regex.Split(valuesLine.ToString().Trim(), delimiter);

            string newValues = "";
            //string testran = "";


            for (int i = 0; i < values.Length; i++)
            {
                double _x = 0.0d;

                if (x == null)
                {                    
                    ////_x = (new Random()).NextDouble(); // doesn't work because process too fast, the system time base is always the same.

                    ///////better way to generate better random number
                    //RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                    //byte[] result = new byte[8];
                    //rng.GetBytes(result);
                    //_x= (double)BitConverter.ToUInt64(result, 0) / ulong.MaxValue;

                    _x = Glibs.getRealRandom();
                }
                else
                { _x = (double)x; }

              //  newValues = newValues + delimiter + Simulator.NORMDIST((double)_x, mean, std, cumulative).ToString();
                newValues = newValues + delimiter + SimpleRNG.GetNormal(mean, std).ToString();
            }

            //newValues = newValues.Trim();


            return newValues.Trim();
            
        }

        public static string extractStringHTML(string s, string tag)
        {
            // You should check for errors in real-world code, omitted for brevity
            var startTag = "<" + tag + ">";
            int startIndex = s.IndexOf(startTag) + startTag.Length;
            int endIndex = s.IndexOf("</" + tag + ">", startIndex);
            return s.Substring(startIndex, endIndex - startIndex);
        }

        public static string extractString(string s)
        {
            // You should check for errors in real-world code, omitted for brevity
            var startTag = "(";
            int startIndex = s.IndexOf(startTag) + startTag.Length;
            int endIndex = s.IndexOf(")", startIndex);
            return s.Substring(startIndex, endIndex - startIndex);
        }

        public static string convertStringListToString(List<string> liststring)
        { 
            string finalstring="";

            foreach (string s in liststring)
            {
                finalstring = finalstring + Environment.NewLine + s;
            }
            
            return finalstring.Trim(); //remove extra first empty line
        }

        /// <summary>
        /// Using Random() may not work correctly if the time is too short for example generate random number inside the For loop, and you will get the same number. This method gives you the real random the random # is between 0 to 1
        /// </summary>
        /// <returns></returns>
        public static double getRealRandom()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] result = new byte[8];
            rng.GetBytes(result);
            return (double)BitConverter.ToUInt64(result, 0) / ulong.MaxValue;        
        }

        /// <summary>
        /// Gets the name of the PC.
        /// </summary>
        /// <returns></returns>
        public static string getPCName()
        {
            return Environment.MachineName.ToString();
        }

        public static string parseLine() { 
        //#(.*)=(.*)\(([+-]?[0-9]+(?:\.[0-9]*)?),([+-]?[0-9]+(?:\.[0-9]*)?)\)
            return "" ;
        }


        public static List<FileInfo> FullDirList(DirectoryInfo dir, string searchPattern)
        {
            // Console.WriteLine("Directory {0}", dir.FullName);
            // list the files
            List<FileInfo> files = new List<FileInfo>();  // List that will hold the files and subfiles in path
            List<DirectoryInfo> folders = new List<DirectoryInfo>(); // List that hold direcotries that cannot be accessed

            try
            {
                foreach (FileInfo f in dir.GetFiles(searchPattern))
                {
                    //Console.WriteLine("File {0}", f.FullName);
                    files.Add(f);
                }
            }
            catch
            {
                Console.WriteLine("Directory {0}  \n could not be accessed!!!!", dir.FullName);
                return null;  // We alredy got an error trying to access dir so dont try to access it again
            }

            // process each directory
            // If I have been able to see the files in the directory I should also be able 
            // to look at its directories so I dont think I should place this in a try catch block
            foreach (DirectoryInfo d in dir.GetDirectories())
            {
                folders.Add(d);
                FullDirList(d, searchPattern);
            }

            return files;

        }

        public static List<FileInfo> getAllFilesWithinDir(DirectoryInfo dir)
        {
            List<FileInfo> files = new List<FileInfo>();  // List that will hold the files and subfiles in path
            foreach (FileInfo f in dir.GetFiles())
            {
                files.Add(f);
            }
            return files;
        
        }

    }
}