using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;
using System.Xml;
using System.Reflection;


namespace Fishery_Simulation
{
    class ProcessFiles
    {
        public int _numberOfSubFolder = 0;
        public string _rootFolderPath = "";
        public DataSet1 _ds = new DataSet1();
        public enum _processModeDefine: short { rootOnly, subOnly, rootToSub, subToRoot };
        public _processModeDefine _processMode;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessFiles" /> class. Try use full Initializes instead of this one.
        /// </summary>
        public ProcessFiles()  {      }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessFiles" /> class.
        /// </summary>
        /// <param name="numberOfSubFolder">The number of sub folder.</param>
        /// <param name="rootFolderPath">The root folder path.</param>
        /// <param name="ds">The ds.</param>
        /// <param name="processMode">The process mode.</param>
        public ProcessFiles(int numberOfSubFolder, string rootFolderPath, DataSet1 ds, _processModeDefine processMode)
        {
            _numberOfSubFolder = numberOfSubFolder;
            _rootFolderPath = rootFolderPath;
            _ds = ds;
            _processMode = processMode;
        }

        internal bool createSubFolders(int? numberOfSubFolder, string rootFolderPath)
        {
            if (numberOfSubFolder.HasValue == true)
            {
                _numberOfSubFolder = numberOfSubFolder.Value;
            }

            //if (rootFolderPath.HasValue == true)
            //{
            //    _rootFolderPath = rootFolderPath.Value;
            //}

            //create empty folders
            try
            {
                Parallel.For(1, _numberOfSubFolder, i =>
                {
                    {
                        string newPath = Path.Combine(_rootFolderPath, i.ToString());
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

        internal bool paralleProcessFiles(string dataSet1TableName, int? numberOfSubFolder, string rootFolderPath)
        {
            if (numberOfSubFolder.HasValue == true)
            {
                _numberOfSubFolder = numberOfSubFolder.Value;
            }

            //if (rootFolderPath.HasValue == true)
            //{
            //    _rootFolderPath = rootFolderPath.Value;
            //}

            //if (ds.HasValue == true)
            //{
            //    _ds = ds.Value;
            //}


            //copy files
            try
            {
                Parallel.For(0, _ds.Tables[dataSet1TableName].Rows.Count - 1, j =>
                {

                    //for (int j = 0; j < dataGridView1.RowCount-1; j++)
                    {
                        string filename = Glibs.toStringNullable(_ds.Tables[dataSet1TableName].Rows[j]["FileName"].ToString());
                        string captureType = Glibs.toStringNullable(_ds.Tables[dataSet1TableName].Rows[j]["capture"].ToString());
                        string outputFileName = Glibs.toStringNullable(_ds.Tables[dataSet1TableName].Rows[j]["outputFileName"].ToString());
                        string blockHeaderLine = Glibs.toStringNullable(_ds.Tables[dataSet1TableName].Rows[j]["block"].ToString());
                        string blockEndLine = Glibs.toStringNullable(_ds.Tables[dataSet1TableName].Rows[j]["blockend"].ToString());
                        string randomGen = Glibs.toStringNullable(_ds.Tables[dataSet1TableName].Rows[j]["randomGen"].ToString());

                        string sourceFile = ""; //defined in each following selection

                        int? fromLine = Glibs.tointNullable(_ds.Tables[dataSet1TableName].Rows[j]["fromLine"].ToString());
                        int? toLine = Glibs.tointNullable(_ds.Tables[dataSet1TableName].Rows[j]["toLine"].ToString());






                        if (captureType == "Lines" && fromLine != null && toLine != null) ///copy line text
                        {
                            for (int i = 1; i < _numberOfSubFolder; i++)
                            {
                                //open file and get conents, then copy over the conents therefor, use the file from root folder
                                sourceFile = Path.Combine(_rootFolderPath, filename);
                                string destFile = Path.Combine(Path.Combine(_rootFolderPath, i.ToString()), outputFileName);


                                Glibs.WritelineText(destFile, Glibs.ReadLineText(sourceFile, fromLine, toLine, false, null, null));
                            }
                        }
                        else if (captureType == "Rand Gen" && randomGen != null) ///gen rand numbers
                        {
                            for (int i = 1; i < _numberOfSubFolder; i++)
                            {
                                //open file and get conents, then copy over the conents therefor, use the file from root folder
                                sourceFile = Path.Combine(_rootFolderPath, filename);
                                string destFile = Path.Combine(Path.Combine(_rootFolderPath, i.ToString()), outputFileName);
                                generateRandDist(sourceFile, destFile, randomGen);
                            }
                        }
                        //else if (captureType == "Block" && blockHeaderLine != null && blockEndLine!=null) ///copy block
                        else if (captureType == "Block" && blockHeaderLine != null) ///copy block
                        {

                            DataTable dt = new DataTable();
                            //List<string> strings = Glibs.ReadText(sourceFile);

                            sourceFile = Path.Combine(_rootFolderPath, filename);
                            string[] strings2 = Glibs.ReadText2(sourceFile); //use the file which generated in the root folder

                            //row number column
                            DataColumn c = new DataColumn("romNum");

                            c.AutoIncrement = true;
                            c.AutoIncrementSeed = 1;
                            c.AutoIncrementStep = 1;
                            dt.Columns.Add(c);

                            //setNum for block
                            dt.Columns.Add("setNum", typeof(int));

                            //data column
                            dt.Columns.Add("textline", typeof(string));

                            int curr_set = 0;

                            foreach (string str in strings2)
                            {
                                if (str.StartsWith(blockHeaderLine))
                                { curr_set = curr_set + 1; }

                                DataRow dr = dt.NewRow();
                                dr["textline"] = str;
                                dr["setNum"] = curr_set;
                                dt.Rows.Add(dr);
                            }




                            for (int i = 1; i < _numberOfSubFolder; i++)
                            {
                                var query = from dr2 in dt.AsEnumerable()
                                            where (int)dr2["setNum"] == i
                                            select (string)dr2["textline"];

                                string final_str = "";

                                foreach (string str in query)
                                {
                                    final_str = final_str + Environment.NewLine + str;
                                }

                                final_str = final_str.Trim();
                                string destFile = Path.Combine(Path.Combine(_rootFolderPath, i.ToString()), outputFileName);
                                Glibs.WritelineText(destFile, final_str);
                            }


                        }
                        else // anything else, copy full file
                        {
                            for (int i = 1; i < _numberOfSubFolder; i++)
                            {

                                // sourceFile = Path.Combine(Path.Combine(_rootFolderPath, "~~original"), filename);
                                sourceFile = Path.Combine(Path.Combine(_rootFolderPath, "~~original"), filename);
                                string destFile = Path.Combine(Path.Combine(_rootFolderPath, i.ToString()), outputFileName);
                                File.Copy(sourceFile, destFile, true);
                            }
                        }


                    }
                }); //Parallel.For
            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.ToString());
            }
            return true;
        }

        internal bool generateRandDist(string sourceFile, string outputFile, string TextBoxValue)
        {
            //string sourceFile = @"C:\_MSmesh_\(my documents)\__PROJECTS__\Fishery Simulation\Fishery Simulation\bin\Release\~~.txt";
            //string outputFile = "";

            List<string> strs = new List<string>();
            strs.AddRange(Glibs.ReadText(sourceFile));

            //string _originalTextboxValue = "<FileList>=Anything(RAND,2,34,false)";
            string _originalTextboxValue = TextBoxValue;
            string[] _textboxValueInLines = _originalTextboxValue.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);


            foreach (string _eachPairLine in _textboxValueInLines)   //_eachPairLine is "abc=randdis(1,2,4)"
            {
                string _key = _eachPairLine;
                try
                {
                    string[] _eachPair = _eachPairLine.Split('=');
                    _key = _eachPair[0].ToString().Trim(); //eg: abc

                    string _values = _eachPair[1].Trim(); //eg: Anything(Rand,0.6,0.7,false)
                    string[] _eachValue = Glibs.extractString(_values).Split(new string[] { "," }, StringSplitOptions.None); //eg: 1

                    //find the keyheader line
                    int? keywordFoundInIndexOf = Glibs.findIndexOfKeyWord(strs, _key);
                    //replace the value with the right values for the line after the keyheader line
                    //strs[(int)keywordFoundInIndexOf + 1] = (Glibs.CreateRandNorm(strs[(int)keywordFoundInIndexOf + 1], " ", _x, double.Parse(_eachValue[1].Trim()), double.Parse(_eachValue[2].Trim()), bool.Parse(_eachValue[3].Trim()))); //change value for the next time
                    strs[(int)keywordFoundInIndexOf + 1] = (Glibs.CreateRandNorm(strs[(int)keywordFoundInIndexOf + 1], " ", null, double.Parse(_eachValue[0].Trim()), double.Parse(_eachValue[1].Trim()), false)); //change value for the next time

                }
                catch
                {
                    MessageBox.Show("Cannot find the keyword header: " + _key + " or the fomular is not right, continue without modification.");
                }

            }

            //replace with new value for this file
            //write back to the the file to the sub folder.

            //string fileText = Glibs.convertStringListToString(strs);
            Glibs.WritelineText(outputFile, Glibs.convertStringListToString(strs));
            return true;
        }



    }
}
