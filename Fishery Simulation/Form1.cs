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
        }

        private void saveSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
           List<Control> allcontrl = Glibs.GetControls2(this);
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

            //step 1:

            this.CopyFiles();

            //step 1.1: run commands
            try
            {
                if (textBox3.Text.ToString().Trim().Length > 0)
                    Process.Start(textBox3.Text.ToString());
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString());
            }


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
                    string filename = dataGridView1.Rows[j].Cells[0].Value.ToString();
                    string sourceFile = Path.Combine(buttonEdit1.Text, filename);
                    int? fromLine;
                    if (dataGridView1.Rows[j].Cells[1].Value == null)
                    { fromLine = null; }
                    else
                    { fromLine = int.Parse(dataGridView1.Rows[j].Cells[1].Value.ToString()); }        

                    int? toLine;
                    if (dataGridView1.Rows[j].Cells[2].Value == null)
                    { toLine = null; }
                    else
                    { toLine = int.Parse(dataGridView1.Rows[j].Cells[2].Value.ToString()); }



                    if (fromLine == null || toLine == null) ///if no fromline and toline
                    {
                        for (int i = 1; i <= int.Parse(textBox2.Text.Trim().ToString()); i++)
                        {
                            string destFile = Path.Combine(Path.Combine(buttonEdit1.Text, i.ToString()), filename);
                            File.Copy(sourceFile, destFile, true);
                        }
                    }
                    else { 
                        for (int i = 1; i <= int.Parse(textBox2.Text.Trim().ToString()); i++)
                        {
                            //open file and get conents, then copy over the conents
                            string destFile = Path.Combine(Path.Combine(buttonEdit1.Text, i.ToString()), filename);
                            Glibs.WriteBlockText(destFile, Glibs.ReadBlockText(sourceFile, fromLine, toLine));
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
    }
}
