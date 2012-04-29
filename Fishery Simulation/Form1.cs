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

            Thread oThread = new Thread(new ThreadStart(process1and2));

            oThread.Start();

        }

        private void process1and2()
        {



            

            //step 1.1: run commands
            try
            {
                if (textBox3.Text.ToString().Trim().Length > 0)
                {
                    //Create a new process info structure.
                    ProcessStartInfo pInfo = new ProcessStartInfo();
                    pInfo.FileName = textBox3.Text.ToString();
                    pInfo.WindowStyle = ProcessWindowStyle.Normal;
                    pInfo.WorkingDirectory=buttonEdit1.Text.ToString();
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
                    string filename = dataGridView1.Rows[j].Cells["FileName"].Value.ToString();
                    string captureType = dataGridView1.Rows[j].Cells["capture"].Value.ToString();
                    string outputFileName = dataGridView1.Rows[j].Cells["outputFileName"].Value.ToString();
                    string blockHeaderLine = dataGridView1.Rows[j].Cells["block"].Value.ToString();
                    string blockEndLine = dataGridView1.Rows[j].Cells["blockend"].Value.ToString();

                    string sourceFile = Path.Combine(buttonEdit1.Text, filename);


                    int? fromLine;
                    if (dataGridView1.Rows[j].Cells["fromLine"].Value == null)
                    { fromLine = null; }
                    else
                    { fromLine = int.Parse(dataGridView1.Rows[j].Cells["fromLine"].Value.ToString()); }        

                    int? toLine;
                    if (dataGridView1.Rows[j].Cells["toLine"].Value == null)
                    { toLine = null; }
                    else
                    { toLine = int.Parse(dataGridView1.Rows[j].Cells["toLine"].Value.ToString()); }



                    if (captureType == "Lines" && fromLine != null && toLine != null) ///copy line text
                    {
                        for (int i = 1; i <= int.Parse(textBox2.Text.Trim().ToString()); i++)
                        {
                            //open file and get conents, then copy over the conents
                            string destFile = Path.Combine(Path.Combine(buttonEdit1.Text, i.ToString()), outputFileName);
                            Glibs.WritelineText(destFile, Glibs.ReadBlockText(sourceFile, fromLine, toLine));
                        }
                    }
                    else if (captureType == "Block" && blockHeaderLine != null && blockEndLine!=null) ///copy block
                    {
                        string[] sts = Glibs.ReadText(sourceFile);


                        for (int i = 1; i <= int.Parse(textBox2.Text.Trim().ToString()); i++)
                        {
                            //string destFile = Path.Combine(Path.Combine(buttonEdit1.Text, i.ToString()), outputFileName);
                            //File.Copy(sourceFile, destFile, true);
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
                dataGridView1[5, e.RowIndex].Value = dataGridView1[0, e.RowIndex].EditedFormattedValue; //copy values from input to output
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
            if (e.ColumnIndex == 1) // your combo column index
            {
                e.Value = "None";
            }

            
        }
    }
}
