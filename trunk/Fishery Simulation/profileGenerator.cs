﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fishery_Simulation
{
    public partial class profileGenerator : Form
    {
        private int _createNewFolder =0;


        public profileGenerator()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rootFileTextBox.Focus(); //to make sure the text is modified in the Dataset
            this.Focus();

            DialogResult result = this.openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                rootFileTextBox.Text = openFileDialog1.FileName.ToString();
            }
        }

        private void rootFolderTextBox_DragDrop(object sender, DragEventArgs e)
        {

            dragDrop(e);

        }

        private void rootFolderLabel_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _createNewFolder = 1 + (int)Math.Ceiling((double.Parse(textBox4.Text.Trim()) - double.Parse(textBox3.Text.Trim())) / double.Parse(textBox5.Text.Trim()));

                if (_createNewFolder < 0)
                {
                    MessageBox.Show("Please check 'start' 'end' and 'interval' values. This program cannot create NEGATIVE folder numbers");
                }
                else
                {
                    if (rootFileTextBox.Text.Trim().Length > 0)
                    {
                        generateProfileFileAndFolders();
                    }
                    else
                    {
                        MessageBox.Show("You forget enter the filename you want to modify with full path");
                    }
                }
            }
            catch (Exception ei)
            { MessageBox.Show(ei.ToString()); }
        }

        private bool generateProfileFileAndFolders()
        {
            try
            {

                FileInfo __rootfile = new FileInfo(rootFileTextBox.Text.Trim());
                double __currentValue = 0;
                int __lineNumber = int.Parse(textBox1.Text.Trim());

                //create new folders         
                Glibs.createSubFolders(_createNewFolder + 1, Path.GetDirectoryName(rootFileTextBox.Text.Trim()));


                //get all files in the same folder
                List<FileInfo> __files = new List<FileInfo>();
                DirectoryInfo __folder = new DirectoryInfo(Path.GetDirectoryName(rootFileTextBox.Text.Trim()));
                __files = Glibs.getAllFilesWithinDir(__folder);


                //create new file to the new folders
                string[] __fileConect = Glibs.ReadText2(__rootfile.FullName);
                string __thisLine = __fileConect[__lineNumber - 1];
                string __newLine = "";
                string[] __thisValue = __thisLine.Split(' ');

                for (int i = 1; i <= _createNewFolder; i++)
                {
                    __currentValue = double.Parse(textBox3.Text.Trim()) + double.Parse(textBox5.Text.Trim()) *(i-1);

                    for (int j = 0; j < __thisValue.Length; j++)
                    {
                        if (__thisValue[0] == "" || __thisValue[0] == " ") // if the first one is space, then skip counting this as column
                        {
                            if (j == int.Parse(textBox2.Text.Trim()))
                            {
                                __thisValue[j] = __currentValue.ToString();
                            }

                            if (textBox8.Text.Trim() != "")
                            {
                                if (j == int.Parse(textBox8.Text.Trim()))
                                {
                                    __thisValue[j] = (Math.Abs( double.Parse(__thisValue[j]) )*-1).ToString();
                                }
                            }


                        }
                        else
                        {
                            if (j == int.Parse(textBox2.Text.Trim()) - 1)
                            {
                                __thisValue[j] = __currentValue.ToString();
                            }

                            try
                            {
                                if (j == int.Parse(textBox8.Text.Trim()) - 1)
                                {
                                    __thisValue[j] = (Math.Abs(double.Parse(__thisValue[j])) * -1).ToString();
                                }
                            }
                            catch (Exception ei4) { }


                        }
                    }

                    __newLine = String.Join(" ", __thisValue);

                    //if (i == __lineNumber)
                    //{
                    __fileConect[__lineNumber-1] = __newLine;
                    //}

                    string __text = "";
                    foreach (string l in __fileConect)
                    {
                        __text = __text+l + Environment.NewLine;
                    }

                    Glibs.WritelineText((__rootfile.DirectoryName+@"\").Replace(@"\\",@"\")+ i.ToString() + @"\" + __rootfile.Name, __text);
                }
                

 


                //copy other files to each new folders
                for (int i = 1; i <= _createNewFolder; i++)
                {
                    foreach (FileInfo f in __files)
                    {
                        if (f.Name != __rootfile.Name)
                        {
                            f.CopyTo((__rootfile.DirectoryName + @"\").Replace(@"\\", @"\") + i.ToString() + @"\" + f.Name);
                        }
                    }
                }

            }
            catch (Exception ei)
            {
                MessageBox.Show(ei.ToString());
            }

            // end method

            MessageBox.Show("Process Completed.");
            return true;
        }

        private void profileGenerator_DragDrop(object sender, DragEventArgs e)
        {
            dragDrop(e);
        }

        private void profileGenerator_Load(object sender, EventArgs e)
        {

        }

        private void profileGenerator_DragEnter(object sender, DragEventArgs e)
        {
            dragEnter(e);
        }


        private void dragEnter(DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void dragDrop(DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] filePaths = (string[])(e.Data.GetData(DataFormats.FileDrop));
                rootFileTextBox.Text = filePaths[0].ToString();
                //foreach (string fileLoc in filePaths)
                //{
                //    // Code to read the contents of the text file
                //    if (File.Exists(fileLoc))
                //    {
                //        using (TextReader tr = new StreamReader(fileLoc))
                //        {
                //            MessageBox.Show(tr.ReadToEnd());
                //        }
                //    }

                //}
            }
        }

        private void rootFileTextBox_DragEnter(object sender, DragEventArgs e)
        {
            dragEnter(e);
        }


    }
}
