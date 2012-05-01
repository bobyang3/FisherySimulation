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


namespace Fishery_Simulation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox2 ab2 = new AboutBox2();
            ab2.ShowDialog();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rootFolderTextBox_EditValueChanged(object sender, EventArgs e)
        {

        }

        //private void rootFolderTextBox_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        //{
        //    DialogResult result = this.folderBrowserDialog1.ShowDialog();
        //    if (result == DialogResult.OK)
        //    {
        //        rootFolderTextBox.Text = folderBrowserDialog1.SelectedPath;
        //    }
        //}

        private void Form1_Load(object sender, EventArgs e)
        {

            //create a new 
            DataRow row=dataSet1.Tables["Settings"].NewRow();
            dataSet1.Tables["Settings"].Rows.Add(row);


            rootFolderTextBox.Text = Directory.GetCurrentDirectory();
        }


        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); //number only
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (fileExistsCheck())
            {
                //Thread oThread = new Thread(new ThreadStart(process1and2));

                //pass values to the new thread
                Thread oThread = new Thread(new ParameterizedThreadStart(process1and2));
                oThread.Start(this);
            }

        }

        private void process1and2(object originalForm)
        {
            string rootFolderTextBoxText = ((Form1)originalForm).rootFolderTextBox.Text as string;

            //step 1.1: run commands
            try
            {
                if (textBox3.Text.ToString().Trim().Length > 0)
                {
                    //Create a new process info structure.
                    ProcessStartInfo pInfo = new ProcessStartInfo();
                    string[] sts=textBox3.Text.ToString().Split('-');
                    string app=sts[0];
                    string arguments="";
                    for (int i=1; i<sts.Length; i++)
                    {
                        arguments=arguments+"-" + sts[i];
                    }

                    pInfo.FileName = Path.Combine(rootFolderTextBoxText, app);
                    pInfo.Arguments = arguments;
                   // pInfo.WindowStyle = ProcessWindowStyle.Normal;
                    pInfo.WorkingDirectory = rootFolderTextBoxText;
                    Process p = Process.Start(pInfo);

                    ////Wait for the window to finish loading.
                    //p.WaitForInputIdle();
                    //Wait for the process to end.
                    p.WaitForExit();
                    //MessageBox.Show("Code continuing...");
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString());
            }

            //step 1: only continue this when the command is finished.
            this.CopyFiles(originalForm);

            //del files
            //Glibs.DeleteFolder(new DirectoryInfo(newPath));



            //step 2: run commands

            try
            {

                if (textBox4.Text.ToString().Trim().Length > 0 && textBox2.Text.Trim()!="")
                    {
                                          
                     //TODO: split core job.

                    double _Max_folder_num=double.Parse(textBox2.Text.Trim().ToString());
                    int CUPsetAverage = Convert.ToInt32(Math.Ceiling(_Max_folder_num / Glibs.GetCPUCore()));

                    //for (int i=1; i <= Glibs.GetCPUCore(); i++)
                    //{
                    //    step2Command(rootFolderTextBoxText, (i-1) * CUPsetAverage + 1, i * CUPsetAverage);
                    //}

                    Parallel.For (1, Glibs.GetCPUCore()+1, i =>
                        {
                            {
                                step2Command(rootFolderTextBoxText, (i - 1) * CUPsetAverage + 1, (i * CUPsetAverage) > _Max_folder_num ? Convert.ToInt32(_Max_folder_num) : (i * CUPsetAverage));
                            }
                        });

                     
                }

                MessageBox.Show(@"Step 1 and/or 2 finished.");
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString());
            }


        }


        private void step2Command(string rootFolderTextBoxText, int starting, int ending)
        {
            
            for (int i = starting; i <= ending; i++)
            {
                ProcessStartInfo pInfo = new ProcessStartInfo();
                string[] sts = textBox4.Text.ToString().Split('-');
                string app = sts[0];
                string arguments = "";
                for (int j = 1; j < sts.Length; j++)
                {
                    arguments = arguments + "-" + sts[j];
                }

                //string app = ((Form1)originalForm).textBox4.Text as string;

                pInfo.FileName = Path.Combine(Path.Combine(rootFolderTextBoxText, i.ToString()), app);
                pInfo.Arguments = arguments;
                pInfo.WorkingDirectory = Path.Combine(rootFolderTextBoxText, i.ToString());
                Process p = Process.Start(pInfo);

                ////Wait for the process to end.
                p.WaitForExit();
            }
        }

        private void CopyFiles(object originalForm)
        {
            int _sub_folder_num = 0;

            if (((Form1)originalForm).textBox2.Text != null && ((Form1)originalForm).textBox2.Text.Trim() != "")
            {
                _sub_folder_num = int.Parse(textBox2.Text.Trim().ToString()) + 1;
            }

            //create empty folders
            try
            {
                

                Parallel.For(1, _sub_folder_num , i =>
                {
                    {
                        string newPath = Path.Combine(rootFolderTextBox.Text, i.ToString());
                        Directory.CreateDirectory(newPath);
                    }
                });
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.ToString());
            }


            //copy files
            try
            {
                Parallel.For(0, dataGridView1.RowCount-1, j =>
                {

                //for (int j = 0; j < dataGridView1.RowCount-1; j++)
                {
                    string filename = Glibs.toStringNullable(dataGridView1.Rows[j].Cells["FileName"].Value);
                    string captureType = Glibs.toStringNullable(dataGridView1.Rows[j].Cells["capture"].Value);
                    string outputFileName = Glibs.toStringNullable(dataGridView1.Rows[j].Cells["outputFileName"].Value);
                    string blockHeaderLine = Glibs.toStringNullable(dataGridView1.Rows[j].Cells["block"].Value);
                    string blockEndLine = Glibs.toStringNullable(dataGridView1.Rows[j].Cells["blockend"].Value);
                    string randomGen = Glibs.toStringNullable(dataGridView1.Rows[j].Cells["randomGen"].Value);

                    string sourceFile = Path.Combine(Path.Combine(rootFolderTextBox.Text,"~~original"), filename);


                    int? fromLine = Glibs.tointNullable(dataGridView1.Rows[j].Cells["fromLine"].Value);
                    int? toLine = Glibs.tointNullable(dataGridView1.Rows[j].Cells["toLine"].Value);

                    
                    if (captureType == "Lines" && fromLine != null && toLine != null) ///copy line text
                    {
                        for (int i = 1; i < _sub_folder_num; i++)
                        {
                            //open file and get conents, then copy over the conents
                            sourceFile = Path.Combine(rootFolderTextBox.Text,filename);
                            string destFile = Path.Combine(Path.Combine(rootFolderTextBox.Text, i.ToString()), outputFileName);
                            Glibs.WritelineText(destFile, Glibs.ReadLineText(sourceFile, fromLine, toLine));
                        }
                    }
                    else if (captureType == "Rand Gen" && randomGen != null) ///gen rand numbers
                    {
                        DataTable dt= convertFileToDataTable(sourceFile);


                        var query = from dr2 in dt.AsEnumerable()
                                    where (string)dr2["textline"] == "dictionaryKey"
                                    select dr2;
                    
                    }
                    //else if (captureType == "Block" && blockHeaderLine != null && blockEndLine!=null) ///copy block
                    else if (captureType == "Block" && blockHeaderLine != null) ///copy block
                    {

                        DataTable dt = new DataTable();
                        //List<string> strings = Glibs.ReadText(sourceFile);
                        
                        sourceFile = Path.Combine(rootFolderTextBox.Text, filename);
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




                        for (int i = 1; i < _sub_folder_num; i++)
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
                            string destFile = Path.Combine(Path.Combine(rootFolderTextBox.Text, i.ToString()), outputFileName);
                            Glibs.WritelineText(destFile, final_str);
                        }


                    }
                    else // anything else, copy full file
                    {
                        for (int i = 1; i < _sub_folder_num; i++)
                        {

                            // sourceFile = Path.Combine(Path.Combine(rootFolderTextBox.Text, "~~original"), filename);
                            string destFile = Path.Combine(Path.Combine(rootFolderTextBox.Text, i.ToString()), outputFileName);
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

            
        }

        private DataTable convertFileToDataTable(string sourceFile)
        {
            DataTable dt = new DataTable();
            string[] strings2 = Glibs.ReadText2(sourceFile);
            
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

            foreach (string str in strings2)
            {
                DataRow dr = dt.NewRow();
                dr["textline"] = str;
                dt.Rows.Add(dr);
            }

            return dt;
        }


        private double generateNormalDisNumber(double mean, double SD, int count)
        {

            return 0;                    
        }

        private bool fileExistsCheck()
        {
            string newPath = Path.Combine(rootFolderTextBox.Text, "~~original");
            Directory.CreateDirectory(newPath);
            string _error_fileNames = "";

            try
            {
                for (int j = 0; j < dataGridView1.RowCount - 1; j++)
                {

                    string captureType = Glibs.toStringNullable(dataGridView1.Rows[j].Cells["capture"].Value);
                    string sourceFile = Path.Combine(rootFolderTextBox.Text, dataGridView1.Rows[j].Cells["FileName"].Value.ToString());
                    string destFile = Path.Combine(newPath, dataGridView1.Rows[j].Cells["FileName"].Value.ToString());

                    //MessageBox.Show(sourceFile);

                    if (captureType == "None" || captureType == null)
                    {
                        if (File.Exists(sourceFile))
                        {
                            File.Copy(sourceFile, destFile, true);
                        }
                        else
                        {
                            _error_fileNames = _error_fileNames + "," + dataGridView1.Rows[j].Cells["FileName"].Value;
                        }
                    }


                }
            }

            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString());
            }


            if (_error_fileNames.Length > 0)
            {
                MessageBox.Show("Please make sure the files are exists: " + _error_fileNames);
                Glibs.DeleteFolder(new DirectoryInfo(newPath));
                return false;
            }
            else
            {
                return true;
            }


            // Directory.Delete(newPath);

        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 0) //fileName is netered
            //{
            //    dataGridView1["outputFileName", e.RowIndex].Value = dataGridView1[0, e.RowIndex].EditedFormattedValue; //copy values from input to output
            //}


        }


        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            //e.Row.Cells[2].ReadOnly = true;


            //multilines
            dataGridView1.Columns["randomGen"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;


        }

     

        private void saveSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox2.Focus(); //TO MAKE SURE LEAVE DATAGRID AND UPDATE THE CHANGES
            this.Focus();
            
            //path of XML file            
           // dataSet1.WriteXml(@"FS_setting.xml");

            DialogResult result = this.saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                  dataSet1.WriteXml(saveFileDialog1.FileName);
            }


        }


        private void loadSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult result = this.openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    dataSet1.Tables["FileList"].Clear();
                    dataSet1.Tables["Settings"].Clear();
                    dataSet1.Tables["SummayFiles"].Clear();
                    dataSet1.ReadXml(openFileDialog1.FileName);
                    //dataSet1.ReadXml(@"FS_setting.xml");
                }

                
            }
            catch (Exception ei)
            { }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            rootFolderTextBox.Focus(); //to make sure the text is modified in the Dataset
            this.Focus();

            DialogResult result = this.folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                rootFolderTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void hellpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://fisherysimulation.codeplex.com/documentation");
            }
            catch { }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0) //fileName is netered
                {
                    dataGridView1["outputFileName", e.RowIndex].Value = dataGridView1[0, e.RowIndex].EditedFormattedValue; //copy values from input to output
                }
            }
            catch{}
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control && e.KeyCode == Keys.C)
                {
                    DataObject d = dataGridView1.GetClipboardContent();
                    Clipboard.SetDataObject(d);
                    e.Handled = true;
                }
                else if (e.Control && e.KeyCode == Keys.V)
                {
                    string s = Clipboard.GetText();
                    string[] lines = s.Split('\n');
                    int row = dataGridView1.CurrentCell.RowIndex;
                    int col = dataGridView1.CurrentCell.ColumnIndex;
                    foreach (string line in lines)
                    {
                        if (row < dataGridView1.RowCount && line.Length >
                        0)
                        {
                            string[] cells = line.Split('\t');
                            for (int i = 0; i < cells.GetLength(0); ++i)
                            {
                                if (col + i <
                                this.dataGridView1.ColumnCount)
                                {
                                    dataGridView1[col + i, row].Value =
                                    Convert.ChangeType(cells[i], dataGridView1[col + i, row].ValueType);
                                }
                                else
                                {
                                    break;
                                }
                            }
                            row++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception ei) { }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {



            if (e.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("Commit error");
            }
            if (e.Context == DataGridViewDataErrorContexts.CurrentCellChange)
            {
                MessageBox.Show("Cell change");
            }
            if (e.Context == DataGridViewDataErrorContexts.Parsing)
            {
                MessageBox.Show("parsing error");
            }
            if (e.Context == DataGridViewDataErrorContexts.LeaveControl)
            {
                MessageBox.Show("leave control error");
            }


        }

        private void summayFilesDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0) //fileName is netered
                {
                    summayFilesDataGridView["dataGridViewTextBoxColumn1", e.RowIndex].Value = summayFilesDataGridView[0, e.RowIndex].EditedFormattedValue; //copy values from input to output
                }
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < summayFilesDataGridView.RowCount - 1; j++)
            {
                string filename = Glibs.toStringNullable(summayFilesDataGridView.Rows[j].Cells["dataGridViewTextBoxColumn1"].Value);
                int? fromLine = Glibs.tointNullable(summayFilesDataGridView.Rows[j].Cells["dataGridViewTextBoxColumn2"].Value);
                int? toLine = Glibs.tointNullable(summayFilesDataGridView.Rows[j].Cells["dataGridViewTextBoxColumn3"].Value);
                string outputFileName = Glibs.toStringNullable(summayFilesDataGridView.Rows[j].Cells["dataGridViewTextBoxColumn4"].Value);

                string rootFolder = rootFolderTextBox1.Text.ToString().Trim();
                int? _sub_folder_num = Glibs.tointNullable(simulationNumTextBox.Text);
                string captured = "";

                if (_sub_folder_num != null && (fromLine != null && toLine != null))///copy line text
                {
                    for (int i = 1; i <= _sub_folder_num; i++)
                    {
                        //open file and get conents, then copy over the conents
                        string sourceFile = Path.Combine(Path.Combine(rootFolder, i.ToString()), filename);
                        captured = captured + Glibs.ReadLineText(sourceFile, fromLine, toLine) + Environment.NewLine;

                    }


                    string destFile = Path.Combine(rootFolder, outputFileName);
                    Glibs.WritelineText(destFile, captured);
                }

            }

            MessageBox.Show("Step 3 is completed.");

        }


    
    
    
    }
}
