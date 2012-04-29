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

        private void buttonEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DialogResult result = this.folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                buttonEdit1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            buttonEdit1.Text = Directory.GetCurrentDirectory();

            dataGridView1.DataSource = new DataTable("t1");
        }

        private void saveSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {

            List<Control> allcontrls = Glibs.GetControls2(this);

            MessageBox.Show(Glibs.GetCPUCore().ToString());


        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); //number only
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Thread oThread = new Thread(new ThreadStart(process1and2));
            Thread oThread = new Thread(new ParameterizedThreadStart(process1and2));
            oThread.Start(buttonEdit1.Text);

        }

        private void process1and2(object str)
        {

            string buttonEdit1Text = str as string;

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

                    //buttonEdit1.Invoke((Action)delegate { buttonEdit1.Text; });

                    pInfo.FileName = Path.Combine(buttonEdit1Text, app);
                    pInfo.Arguments = arguments;
                   // pInfo.WindowStyle = ProcessWindowStyle.Normal;
                    pInfo.WorkingDirectory = buttonEdit1Text;
                    Process p = Process.Start(pInfo);

                    //Wait for the window to finish loading.
                    p.WaitForInputIdle();
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
            this.CopyFiles();



            //step 2: run commands
            try
            {
                if (textBox4.Text.ToString().Trim().Length > 0)
                    {
                        for (int i = 1; i <= int.Parse(textBox2.Text.Trim().ToString()); i++)
                        {
                            ProcessStartInfo pInfo = new ProcessStartInfo();
                            string[] sts=textBox3.Text.ToString().Split('-');
                            string app=sts[0];
                            string arguments="";
                            for (int j=1; j<sts.Length; j++)
                            {
                                arguments=arguments+"-" + sts[j];
                            }
                            pInfo.FileName = Path.Combine(Path.Combine(buttonEdit1Text, i.ToString()),app);
                            pInfo.Arguments = arguments;
                            pInfo.WorkingDirectory = Path.Combine(buttonEdit1Text, i.ToString());
                            Process p = Process.Start(pInfo);

                            ////Wait for the window to finish loading.
                            //p.WaitForInputIdle();
                            ////Wait for the process to end.
                            //p.WaitForExit();
                            ////MessageBox.Show("Code continuing...");
                        }
                }
                    Process.Start(textBox4.Text.ToString());
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString());
            }


        }
        private void CopyFiles()
        {

            //create empty folders
            try
            {
                Parallel.For(1, int.Parse(textBox2.Text.Trim().ToString()) + 1, i =>
                {
                    {
                        string newPath = Path.Combine(buttonEdit1.Text, i.ToString());
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

                    string sourceFile = Path.Combine(buttonEdit1.Text, filename);

                    int? fromLine = Glibs.tointNullable(dataGridView1.Rows[j].Cells["fromLine"].Value);
                    int? toLine = Glibs.tointNullable(dataGridView1.Rows[j].Cells["toLine"].Value);

                    
                    if (captureType == "Lines" && fromLine != null && toLine != null) ///copy line text
                    {
                        for (int i = 1; i <= int.Parse(textBox2.Text.Trim().ToString()); i++)
                        {
                            //open file and get conents, then copy over the conents
                            string destFile = Path.Combine(Path.Combine(buttonEdit1.Text, i.ToString()), outputFileName);
                            Glibs.WritelineText(destFile, Glibs.ReadLineText(sourceFile, fromLine, toLine));
                        }
                    }
                    //else if (captureType == "Block" && blockHeaderLine != null && blockEndLine!=null) ///copy block
                    else if (captureType == "Block" && blockHeaderLine != null) ///copy block
                    {

                        DataTable dt = new DataTable();
                        List<string> strings = Glibs.ReadText(sourceFile);
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
                        dt.Columns.Add("textline",typeof(string));

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




                        for (int i = 1; i <= int.Parse(textBox2.Text.Trim().ToString()); i++)
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
                            string destFile = Path.Combine(Path.Combine(buttonEdit1.Text, i.ToString()), outputFileName);
                            Glibs.WritelineText(destFile, final_str);

                        }
                    }
                    else // anything else, copy full file
                    {
                        for (int i = 1; i <= int.Parse(textBox2.Text.Trim().ToString()); i++)
                        {
                            string destFile = Path.Combine(Path.Combine(buttonEdit1.Text, i.ToString()), outputFileName);
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

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0) //fileName is netered
            {
                dataGridView1["outputFileName", e.RowIndex].Value = dataGridView1[0, e.RowIndex].EditedFormattedValue; //copy values from input to output
            }


        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //set default value

            //dataGridView1[1, e.RowIndex]. = 0;

        }

        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            //e.Row.Cells[2].ReadOnly = true;


        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.Value==null) // your combo column index
            {
                e.Value = "None";
            }

            
        }
    
    
    
    
    
    }
}
