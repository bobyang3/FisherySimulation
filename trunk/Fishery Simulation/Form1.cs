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
using IPlugins;


namespace Fishery_Simulation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            //hide step 2 top part
            splitContainer2.Panel1Collapsed = true;
            splitContainer2.Panel1.Hide();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox2 ab2 = new AboutBox2();
            ab2.ShowDialog();
        }

        List<IPlugin> plugins = new List<IPlugin>();

        private void loadPlugins()
        {
            //AppDomain domain = AppDomain.CreateDomain("exedomain");
            //Do other things to the domain like set the security policy


            string exePath = Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName;
            string pluginsDir = Path.Combine(Path.GetDirectoryName(exePath), "plugin");


            try
            {
                foreach (string s in Directory.GetFiles(pluginsDir, "*.dll"))
                {
                    //MessageBox.Show(Directory.GetFiles(pluginsDir, "*.dll").Length.ToString());
                    //Type[] pluingTypes = Assembly.LoadFile(s).GetTypes();

                    Type[] pluingTypes;
                    try
                    {
                        pluingTypes = Assembly.LoadFrom(s).GetTypes();
                    }
                    catch (ReflectionTypeLoadException r1) //will get to this if ILMerge is used and missing Iplugins.dll in the root folder
                    {
                        pluingTypes = r1.Types;
                    }

                    foreach (Type t in pluingTypes)
                    {
                        try
                        {

                           // Type t = typeof(TypeIWantToLoad);
                            //IPlugins.IPlugin myObject = (IPlugins.IPlugin)domain.CreateInstanceFromAndUnwrap(s, t.FullName);

                            //IPlugin plugin = Activator.CreateInstance(t) as IPlugin;
                            //object ob = Activator.CreateInstance(t);
                            //MessageBox.Show(Assembly.LoadFrom(s).ToString());
                            IPlugins.IPlugin plugin = Activator.CreateInstance(t.AssemblyQualifiedName, t.Name) as IPlugins.IPlugin;
                            //MessageBox.Show(myObject.ToString());
                            pluginToolStripMenuItem.DropDownItems.Add(plugin.Name + " " + plugin.Version, null, new EventHandler(item_Click));
                            plugins.Add(plugin);
                        }
                        catch (Exception e1)
                        {
                            //this is not an plugin dll
                            MessageBox.Show("e1: " + e1.ToString());
                        }

                    }
                }
            }
            catch (Exception e2)
            {
                //There is no dlls in the folder
                MessageBox.Show("e2: " + e2.ToString());
            }

        }

        private void item_Click(object sender, EventArgs e)  //handle plugins action
        {
            foreach (IPlugin plugin in plugins) //find the correct plugin
            {
                if ((plugin.Name + " " + plugin.Version) == sender.ToString())
                {
                    plugin.dataset = ((DataSet)dataSet1).Copy();
                    plugin.refreshMainDataset = false;
                    plugin.startingPoint();

                    if (plugin.refreshMainDataset == true)
                    {
                        dataSet1.Clear();
                        dataSet1 = (DataSet1)plugin.dataset.Copy();  // write the data back to the UI main program
                    }

                    break; //only run the first matching name in the list
                }
            }
        }



        private void setDataSetFromPlugin()
        {
            this.dataSet1.Clear();
            //TODO: load dataset from Plugins
        }



        private void Form1_Load(object sender, EventArgs e)
        {






            //create a new 
            DataRow row=dataSet1.Tables["Settings"].NewRow();
            dataSet1.Tables["Settings"].Rows.Add(row);

            settingsBindingSource.MoveFirst();

            //cPUNumTextBox.Text = Glibs.GetCPUCore().ToString();
            dataSet1.Tables["Settings"].Rows[0][0]=  Directory.GetCurrentDirectory();

            settingsBindingSource.EndEdit();  //sync all the textboxes with current values

            cPUNumTextBox.Text = Math.Ceiling((double)Glibs.GetCPUCore()*1.5).ToString();

            loadPlugins(); // load plguins
        }
        
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); //number only
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            string rootFolderTextBoxText = this.rootFolderTextBox.Text as string;
            string completedFile = Path.Combine(rootFolderTextBoxText, "~FSstatus.xml");

            bool userClick = true;

            if (File.Exists(completedFile) && textBox3.Text.ToString().Trim().Length>0)
            {
                DialogResult result1 = MessageBox.Show(@"The Step 1 was processed before! Are you sure you want to run again? This will overwrite your previous result. If you choose to continue, please make sure you delete all subfolders or delete file '~FSstatus.xml' from sub folders", "Important Question", MessageBoxButtons.YesNo);

                if (result1 == DialogResult.Yes)
                {
                    userClick = true;
                }
                else { 
                    userClick = false;
                    EnableForm1();
                }             
            }

            if (fileExistsCheck() == true && userClick == true)
            {
                //Thread oThread = new Thread(new ThreadStart(process1and2));

                //pass values to the new thread
                Thread oThread = new Thread(new ParameterizedThreadStart(process1and2));
                System.Threading.Thread.Sleep(18);  // because every Environment.Tickcount is 15.6ms
                Thread.SpinWait(16);
                oThread.Start(this);

            }
            else { 
                EnableForm1();
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

                    string[] sts = textBox3.Text.ToString().Split(new char[] {' '}, 2);
                    string app = sts[0];
                    //string arguments = sts[1];

                    pInfo.FileName = Path.Combine(rootFolderTextBoxText, app);

                    try
                    {
                        pInfo.Arguments = sts[1]; 
                    }
                    catch { }

					/*
                   // pInfo.WindowStyle = ProcessWindowStyle.Normal;
                    pInfo.WorkingDirectory = rootFolderTextBoxText;
                    Process p = Process.Start(pInfo);

                    p.EnableRaisingEvents = true; // to make sure capture the correct exitcode
                    p.WaitForExit();

                    if (p.ExitCode == 0) // 0 = regular close, otherwise, user force close, by ctrl+C or click on X
                    {
                        DataSetCPU.ProcessStatusDataTable dt = new DataSetCPU.ProcessStatusDataTable();
                        dt.Clear();
                        dt.Rows.Add("", "30", DateTime.Now.ToString(), "Completed", p.UserProcessorTime.TotalSeconds.ToString() ,  Glibs.getPCName());
                        dt.WriteXml(Path.Combine(rootFolderTextBoxText, "~FSstatus.xml"));
                        dt.Clear();
                    }
					
					*/


                    pInfo.WorkingDirectory = rootFolderTextBoxText;

                    Process p = new Process();
                    p.StartInfo = pInfo;
                    p.EnableRaisingEvents = true; // to make sure capture the correct exitcode
                    System.Threading.Thread.Sleep(18);  // because every Environment.Tickcount is 15.6ms
                    Thread.SpinWait(16);
                    p.Start();    
                    
                    p.WaitForExit();
                    Console.WriteLine(p.ExitCode);  // for debuging output test.

                    if (p.ExitCode == 0 || p.ExitCode == 1) // 0 = regular close, 1= regular close too, otherwise, user force close, by ctrl+C or click on X
                    {
                        DataSetCPU.ProcessStatusDataTable dt = new DataSetCPU.ProcessStatusDataTable();
                        dt.Clear();
                        //dt.Rows.Add("", "30", DateTime.Now.ToString(), "Completed " + Glibs.getPCName());
                        dt.Rows.Add("", "30", DateTime.Now.ToString(), "Step 1 Completed", p.UserProcessorTime.TotalSeconds.ToString(), Glibs.getPCName());
                        dt.WriteXml(Path.Combine(rootFolderTextBoxText, "~FSstatus.xml"));
                        dt.Clear();
                    }
                    else
                    {

                        //DialogResult result1 = MessageBox.Show("Do you want to stop starting all other process? If yes, new process will not start up.", "Are you sure?", MessageBoxButtons.YesNo);

                        //if (result1 == DialogResult.Yes)
                        //{
                        //    _stopAllStep2Command = true;
                        //}

                    }
					


                }
            }
            catch (Exception e1)
            {
                MessageBox.Show("Step 1 Error:\r" + e1.ToString());
            }

            //step 1: only continue this when the command is finished.
            this.CopyFiles(originalForm);



            //del files
            //Glibs.DeleteFolder(new DirectoryInfo(newPath));



            //step 2: run commands

            try
            {

                if (textBox4.Text.ToString().Trim().Length > 0 && textBox2.Text.Trim() != "")
                    {
                                          
                     //TODO: split core job.

                        int paralleNum = 0;
                        if (cPUNumTextBox.Text.ToString().Trim().Length <= 0)
                        {
                            paralleNum = (int)Math.Ceiling((double)Glibs.GetCPUCore() * 1.5);
                        }
                        else
                        {
                            paralleNum = int.Parse(cPUNumTextBox.Text.ToString().Trim());
                        }

                    double _Max_folder_num=double.Parse(textBox2.Text.Trim().ToString()) + 1;


                    //int CUPsetAverage = Convert.ToInt32(Math.Ceiling(_Max_folder_num / paralleNum));

                    //for (int i=1; i <= Glibs.GetCPUCore(); i++)
                    //{
                    //    step2Command(rootFolderTextBoxText, (i-1) * CUPsetAverage + 1, i * CUPsetAverage);
                    //}

                    //Glibs.lastProcessDateTime=DateTime.Now;
                    //Glibs.ProcessStartDatetime.Add(DateTime.Now);

                    ParallelOptions po = new ParallelOptions();
                    po.MaxDegreeOfParallelism = paralleNum;
                    //po.MaxDegreeOfParallelism = int.Parse(cPUNumTextBox.Text.ToString().Trim());
                    //Parallel.For(1, paralleNum + 1, po, i =>
                    Parallel.For(1
                                ,(int)_Max_folder_num
                                , po
                                , (i, loopState) =>
                        {
                            {
                                string subFolder= Path.Combine(rootFolderTextBoxText,i.ToString());
                                //step2Command(rootFolderTextBoxText, (i - 1) * CUPsetAverage + 1, (i * CUPsetAverage) > _Max_folder_num ? Convert.ToInt32(_Max_folder_num) : (i * CUPsetAverage));


                                /***************make process delay so it won't generate the same random number in SS.exe***************/
                                ////DateTime dt2=DateTime.Now;
                                ////double timediff=dt2.Subtract(Glibs.lastProcessDateTime).TotalSeconds;

                                //double _CPU = double.Parse(cPUNumTextBox.Text.ToString().Trim());

                                ////if (timediff <= _CPU*1.8)
                                ////{
                                ////    Thread.Sleep(
                                ////       // (int)(((i % (_CPU + Glibs.getRealRandom()*7)) + Glibs.getRealRandom() * 1.7) * 1234)
                                ////       //(int)((i % (_CPU*1.8)) * 1800)
                                ////       (int)(i  * 1200)
                                ////        );

                                ////}


                                ////if (DateTime.Now.Subtract(Glibs.ProcessStartDatetime[Glibs.ProcessStartDatetime.Count - 1]).TotalSeconds <= 5) //if time diff is less than 5 seconds
                                ////{
                                //    if (Glibs.waitTimeinSecond > _CPU*3)
                                //    {
                                //        Glibs.waitTimeinSecond = 3;
                                //    }
                                //    else {
                                //        Glibs.waitTimeinSecond = Glibs.waitTimeinSecond + 3;
                                //    }
                                
                                //    Glibs.ProcessStartDatetime.Add(DateTime.Now);

                                //    try
                                //    {
                                //        //if (Glibs.ProcessStartDatetime[Glibs.ProcessStartDatetime.Count - 1] == Glibs.ProcessStartDatetime[Glibs.ProcessStartDatetime.Count - 2])

                                //        if (DateTime.Now.AddSeconds(Glibs.waitTimeinSecond) == Glibs.ProcessStartDatetime[Glibs.ProcessStartDatetime.Count - 1])
                                //        {
                                //            Glibs.waitTimeinSecond = Glibs.waitTimeinSecond + 2;
                                //        }
                                //    }
                                //    catch { }

                                //        Thread.Sleep(Glibs.waitTimeinSecond * 1000); 
                                    



                                    
                                //    //Thread.Sleep((int)( (i % (_CPU*1.5)) * 1200));
                                ////}


                                ////Glibs.lastProcessDateTime = DateTime.Now;

                                ////Glibs.ProcessStartDatetime.Add(DateTime.Now);

                                ////double _folderNum = 0;

                                ////try { _folderNum = double.Parse(textBox2.Text.Trim().ToString()); }
                                ////catch { _folderNum = 100 + 1; }
                                
                                ////int _CPU = int.Parse(cPUNumTextBox.Text.ToString().Trim());

                                ////double _delaysecond = i % (_CPU+1); // need to wait in case SS generate the same random number
                                ////Thread.Sleep((int)(Glibs.getRealRandom() * 1386 + _delaysecond * 1278));

                                //Glibs.debugProcessStartDatetime.Add(DateTime.Now);
                                /******END*********make process delay so it won't generate the same random number in SS.exe***************/

                                    
                                step2Command(subFolder);


                                //ParallelLoopState pl = new ParallelLoopState();
                                //pl.Break();

                                if (_stopAllStep2Command == true)
                                {
                                    //ParallelLoopState pl = new ParallelLoopState();
                                    loopState.Break();
                                    //_stopAllStep2Command = false;
                                    //MessageBox.Show(_stopAllStep2Command.ToString());
                                }

                            }
                        });

                    //Glibs.debugProcessStartDatetime.ToString();
                }

                MessageBox.Show(@"Step 1 and/or 2 completed.", "FS Message:");
                
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString());
            }

            ((Form1)originalForm).BeginInvoke(new EnableForm1Callback(EnableForm1));

        }

        public delegate void EnableForm1Callback();

        private void EnableForm1()
        {
            this.Enabled = true;
            this.Activate(); //bring form to front
            _stopAllStep2Command = false; //set back to default, so it will keep on running commmand in the step2
        }


        bool _stopAllStep2Command = false;

        private void step2Command(string subfolderPath)
        {
            ProcessStartInfo pInfo = new ProcessStartInfo();
            
            string[] sts = textBox4.Text.ToString().Split(new char[] { ' ' }, 2);
            string app = sts[0];
            //string arguments = sts[1];

            pInfo.FileName = Path.Combine(subfolderPath, app);

            try
            {
                pInfo.Arguments = sts[1];
            }
            catch { }

            try
            {
                bool blRun = true;
                int step2TimeOutInMinutes = 120;

                try
                {
                   step2TimeOutInMinutes=int.Parse( dataSet1.Tables["settings"].Rows[0]["step2TimeOutInMinutes"].ToString() );
                }
                catch { }

                if (File.Exists(Path.Combine(subfolderPath, "~FSstatus.xml")))
                {
                    DataSetCPU.ProcessStatusDataTable dt = new DataSetCPU.ProcessStatusDataTable();    
                    dt.ReadXml(Path.Combine(subfolderPath, "~FSstatus.xml"));
                    if (int.Parse(dt.Rows[0]["Status"].ToString()) < 30) //status is less than commpleted
                    {
                        DateTime datetime = DateTime.Parse(dt.Rows[0]["StatusDatetime"].ToString());
                        System.TimeSpan diff1 = DateTime.Now.Subtract(datetime);
                        //MessageBox.Show(datetime.ToString() + " xxx " + diff1.TotalMinutes.ToString());
                        if (diff1.TotalMinutes > step2TimeOutInMinutes)  //if time different from last run was more than 120 minutes, then could be incompleted. run again
                            blRun = true;
                        else blRun = false;
                    }
                    else
                    {
                        blRun = false; // don't process again if it is complted, status = 30
                    }

                    
                }

                if (blRun)
                {
                    DataSetCPU.ProcessStatusDataTable dt = new DataSetCPU.ProcessStatusDataTable();
                    dt.Clear();
                    //dt.Rows.Add("", "20", DateTime.Now.ToString(), "Running " + Glibs.getPCName());
                    dt.Rows.Add(subfolderPath, "20", DateTime.Now.ToString(), "Step 2 Running", "", Glibs.getPCName());
                    dt.WriteXml(Path.Combine(subfolderPath, "~FSstatus.xml"));
                   
                    //Process p = new Process();
                    //p.Start(pInfo);

                    string _tempPath = Path.GetTempPath();
                    DirectoryInfo dir = new DirectoryInfo(subfolderPath);
                    String dirName = dir.Name; 
                    _tempPath = Path.Combine(_tempPath, dirName);
                    Console.WriteLine("Temporary Path := " + _tempPath);  //debug only


                    if (checkBoxNetwork.Checked == true)
                    {
                        //copy files over to temp
                        ProcessFiles.CopyFolder(subfolderPath, _tempPath);  //eg. c:\%temp%\210
                        pInfo.FileName = Path.Combine(_tempPath, app);

                        try
                        {
                            pInfo.Arguments = sts[1];
                        }
                        catch { }

                        pInfo.WorkingDirectory = _tempPath;

                    }
                    else {
                        pInfo.WorkingDirectory = subfolderPath;
                    }
                                      
                    Process p = new Process();
                    //compiler.StartInfo.FileName = "csc.exe";
                    //compiler.StartInfo.Arguments = "/r:System.dll /out:sample.exe stdstr.cs";
                    p.StartInfo = pInfo;
                    //p.StartInfo.UseShellExecute = true;
                    //p.StartInfo.RedirectStandardOutput = true;


                    p.EnableRaisingEvents = true; // to make sure capture the correct exitcode

                   // SetConsoleCtrlHandler(new HandlerRoutine(ConsoleCtrlCheck), true);
                    //p.Exited += new EventHandler(myProcess_Exited);
                    System.Threading.Thread.Sleep(18);  // because every Environment.Tickcount is 15.6ms
                    Thread.SpinWait(16);
                    p.Start();    
                    
                    p.WaitForExit();
                    Console.WriteLine(p.ExitCode);  // for debuging output test.



                    if (p.ExitCode == 0 || p.ExitCode == 1) // 0 = regular close, 1= regular close too, otherwise, user force close, by ctrl+C or click on X
                    {
                        dt.Clear();
                        //dt.Rows.Add("", "30", DateTime.Now.ToString(), "Completed " + Glibs.getPCName());
                        dt.Rows.Add(subfolderPath, "30", DateTime.Now.ToString(), "Step 2 Completed", p.UserProcessorTime.TotalSeconds.ToString(), Glibs.getPCName());

                        if (checkBoxNetwork.Checked == true)
                        {
                            dt.WriteXml(Path.Combine(_tempPath, "~FSstatus.xml"));
                            // copy files back from temp to the network folder.
                            ProcessFiles.CopyFolder(_tempPath, subfolderPath);  //eg. c:\%temp%\210

                            try {
                                 //(new DirectoryInfo(_tempPath)).Delete();
                                 System.IO.Directory.Delete(_tempPath, true);
                            }
                            catch {}
                        }
                        else {
                            dt.WriteXml(Path.Combine(subfolderPath, "~FSstatus.xml"));                     
                        }
                        dt.Clear();

                    }
                    else
                    {
                        DialogResult result1 = MessageBox.Show("Do you want to stop starting all other process in Step 2? If yes, new process will not start up.", "Are you sure?", MessageBoxButtons.YesNo);

                        if (result1 == DialogResult.Yes)
                        {
                            _stopAllStep2Command = true;
                        }
                    }

                }
            }
            catch (Exception i) { MessageBox.Show(i.ToString()); }

            //// Wait for Exited event, but not more than 30 seconds. 
            //const int SLEEP_AMOUNT = 100;
            //while (!eventHandled)
            //{
            //    elapsedTime += SLEEP_AMOUNT;
            //    if (elapsedTime > 30000)
            //    {
            //        break;
            //    }
            //    Thread.Sleep(SLEEP_AMOUNT);
            //}

            
        }

        //private bool eventHandled;
        //private Process p = new Process();
        //private int elapsedTime;

        //private void myProcess_Exited(object sender, System.EventArgs e)
        //{

        //    eventHandled = true;
        //    //MessageBox.Show(string.Format("Exit time:    {0}\r\n" +
        //    //    "Exit code:    {1}\r\nElapsed time: {2}", p.ExitTime, p.ExitCode, elapsedTime));
        //    DialogResult result1 = MessageBox.Show("aaa Do you want to stop starting all other process? If yes, new process will not start up.", "Are you sure?", MessageBoxButtons.YesNo);

        //    if (result1 == DialogResult.Yes)
        //    {
        //        _stopAllStep2Command = true;
        //    }

        //}

       // [System.Runtime.InteropServices.DllImport("Kernel32")]
        public static bool myProcess_Exited(object sender, System.EventArgs e)
        {
            MessageBox.Show("xxxx myProcess_Exited xxxxxx");
            return true;

        }

        //private static bool isclosing = false;

        //private static bool ConsoleCtrlCheck(CtrlTypes ctrlType)
        //{
        //    // Put your own handler here
        //    switch (ctrlType)
        //    {
        //        case CtrlTypes.CTRL_C_EVENT:
        //            isclosing = true;
        //            MessageBox.Show("CTRL+C received!");
        //            break;

        //        case CtrlTypes.CTRL_BREAK_EVENT:
        //            isclosing = true;
        //            MessageBox.Show("CTRL+BREAK received!");
        //            break;

        //        case CtrlTypes.CTRL_CLOSE_EVENT:
        //            isclosing = true;
        //            MessageBox.Show("Program being closed!");
        //            break;

        //        case CtrlTypes.CTRL_LOGOFF_EVENT:
        //        case CtrlTypes.CTRL_SHUTDOWN_EVENT:
        //            isclosing = true;
        //            MessageBox.Show("User is logging off!");
        //            break;

        //    }
        //    return true;
        //}



        //#region unmanaged
        //// Declare the SetConsoleCtrlHandler function
        //// as external and receiving a delegate.

        //[System.Runtime.InteropServices.DllImport("Kernel32")]
        //public static extern bool SetConsoleCtrlHandler(HandlerRoutine Handler, bool Add);

        //// A delegate type to be used as the handler routine
        //// for SetConsoleCtrlHandler.
        //public delegate bool HandlerRoutine(CtrlTypes CtrlType);

        //// An enumerated type for the control messages
        //// sent to the handler routine.
        //public enum CtrlTypes
        //{
        //    CTRL_C_EVENT = 0,
        //    CTRL_BREAK_EVENT,
        //    CTRL_CLOSE_EVENT,
        //    CTRL_LOGOFF_EVENT = 5,
        //    CTRL_SHUTDOWN_EVENT
        //}

        //#endregion 

        private void step2Command(string rootFolderTextBoxText, int starting, int ending)
        {
            
            for (int i = starting; i <= ending; i++)
            {
                ProcessStartInfo pInfo = new ProcessStartInfo();

                //string[] sts = textBox4.Text.ToString().Split('-');
                //string app = sts[0];
                //string arguments = "";
                //for (int j = 1; j < sts.Length; j++)
                //{
                //    arguments = arguments + "-" + sts[j];
                //}

                //string app = ((Form1)originalForm).textBox4.Text as string;

                string[] sts = textBox4.Text.ToString().Split(new char[] { ' ' }, 2);
                string app = sts[0];
                //string arguments = sts[1];

                pInfo.FileName = Path.Combine(Path.Combine(rootFolderTextBoxText, i.ToString()), app);

                //if (Path.GetExtension(pInfo.FileName).Length <= 0)
                //{
                //    MessageBox.Show("Your command file: " + app.ToUpper() + " has no extension. Are you sure this is correct? The command may not run correctly without extension. eg. SS3.exe instead of SS3");
                //}


                try
                {
                    pInfo.Arguments = sts[1];
                }
                catch { }

                pInfo.WorkingDirectory = Path.Combine(rootFolderTextBoxText, i.ToString());

                System.Threading.Thread.Sleep(18);  // because every Environment.Tickcount is 15.6ms
                Thread.SpinWait(16);
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

            ProcessFiles pf = new ProcessFiles();
            pf._processMode = ProcessFiles._processModeDefine.rootToSub;
            pf._ds = dataSet1;
            //pf._rootFolderPath = rootFolderTextBox.Text;
            string rootFolderPath = rootFolderTextBox.Text.ToString();
            pf.createSubFolders(_sub_folder_num, rootFolderPath);
            pf.paralleProcessFiles("FileList", _sub_folder_num, rootFolderPath);


            ////create empty folders
            //try
            //{


            //    Parallel.For(1, _sub_folder_num, i =>
            //    {
            //        {
            //            string newPath = Path.Combine(rootFolderTextBox.Text, i.ToString());
            //            Directory.CreateDirectory(newPath);
            //        }
            //    });

            //    //for(int i=1; i<_sub_folder_num; i++)
            //    //{

            //    //        string newPath = Path.Combine(rootFolderTextBox.Text, i.ToString());
            //    //        Directory.CreateDirectory(newPath);                    
            //    //}


            //}
            //catch (Exception e2)
            //{
            //    MessageBox.Show(e2.ToString());
            //}


            ////copy files
            //try
            //{
            //    Parallel.For(0, dataGridView1.RowCount-1, j =>
            //    {

            //    //for (int j = 0; j < dataGridView1.RowCount-1; j++)
            //    {
            //        string filename = Glibs.toStringNullable(dataSet1.Tables["FileList"].Rows[j]["FileName"].ToString());
            //        string captureType = Glibs.toStringNullable(dataSet1.Tables["FileList"].Rows[j]["capture"].ToString());
            //        string outputFileName = Glibs.toStringNullable(dataSet1.Tables["FileList"].Rows[j]["outputFileName"].ToString());
            //        string blockHeaderLine = Glibs.toStringNullable(dataSet1.Tables["FileList"].Rows[j]["block"].ToString());
            //        string blockEndLine = Glibs.toStringNullable(dataSet1.Tables["FileList"].Rows[j]["blockend"].ToString());
            //        string randomGen = Glibs.toStringNullable(dataSet1.Tables["FileList"].Rows[j]["randomGen"].ToString());

            //        string sourceFile = Path.Combine(Path.Combine(rootFolderTextBox.Text,"~~original"), filename);

            //        int? fromLine = Glibs.tointNullable(dataSet1.Tables["FileList"].Rows[j]["fromLine"].ToString());
            //        int? toLine = Glibs.tointNullable(dataSet1.Tables["FileList"].Rows[j]["toLine"].ToString());

                    
            //        if (captureType == "Lines" && fromLine != null && toLine != null) ///copy line text
            //        {
            //            for (int i = 1; i < _sub_folder_num; i++)
            //            {
            //                //open file and get conents, then copy over the conents therefor, use the file from root folder
            //                sourceFile = Path.Combine(rootFolderTextBox.Text,filename);
            //                string destFile = Path.Combine(Path.Combine(rootFolderTextBox.Text, i.ToString()), outputFileName);
            //                Glibs.WritelineText(destFile, Glibs.ReadLineText(sourceFile, fromLine, toLine, false, null, null));
            //            }
            //        }
            //        else if (captureType == "Rand Gen" && randomGen != null) ///gen rand numbers
            //        {
            //            for (int i = 1; i < _sub_folder_num; i++)
            //            {
            //                //open file and get conents, then copy over the conents therefor, use the file from root folder
            //                sourceFile = Path.Combine(rootFolderTextBox.Text, filename);
            //                string destFile = Path.Combine(Path.Combine(rootFolderTextBox.Text, i.ToString()), outputFileName);
            //                generateRandDist(sourceFile, destFile, randomGen);
            //            }
            //        }
            //        //else if (captureType == "Block" && blockHeaderLine != null && blockEndLine!=null) ///copy block
            //        else if (captureType == "Block" && blockHeaderLine != null) ///copy block
            //        {

            //            DataTable dt = new DataTable();
            //            //List<string> strings = Glibs.ReadText(sourceFile);
                        
            //            sourceFile = Path.Combine(rootFolderTextBox.Text, filename);
            //            string[] strings2 = Glibs.ReadText2(sourceFile); //use the file which generated in the root folder

            //            //row number column
            //            DataColumn c = new DataColumn("romNum");

            //            c.AutoIncrement = true;
            //            c.AutoIncrementSeed = 1;
            //            c.AutoIncrementStep = 1;
            //            dt.Columns.Add(c);

            //            //setNum for block
            //            dt.Columns.Add("setNum", typeof(int));

            //            //data column
            //            dt.Columns.Add("textline", typeof(string));

            //            int curr_set = 0;

            //            foreach (string str in strings2)
            //            {
            //                if (str.StartsWith(blockHeaderLine))
            //                { curr_set = curr_set + 1; }

            //                DataRow dr = dt.NewRow();
            //                dr["textline"] = str;
            //                dr["setNum"] = curr_set;
            //                dt.Rows.Add(dr);
            //            }




            //            for (int i = 1; i < _sub_folder_num; i++)
            //            {
            //                var query = from dr2 in dt.AsEnumerable()
            //                            where (int)dr2["setNum"] == i
            //                            select (string)dr2["textline"];

            //                string final_str = "";

            //                foreach (string str in query)
            //                {
            //                    final_str = final_str + Environment.NewLine + str;
            //                }

            //                final_str = final_str.Trim();
            //                string destFile = Path.Combine(Path.Combine(rootFolderTextBox.Text, i.ToString()), outputFileName);
            //                Glibs.WritelineText(destFile, final_str);
            //            }


            //        }
            //        else // anything else, copy full file
            //        {
            //            for (int i = 1; i < _sub_folder_num; i++)
            //            {

            //                // sourceFile = Path.Combine(Path.Combine(rootFolderTextBox.Text, "~~original"), filename);
            //                string destFile = Path.Combine(Path.Combine(rootFolderTextBox.Text, i.ToString()), outputFileName);
            //                File.Copy(sourceFile, destFile, true);
            //            }
            //        }

                    
            //    }
            //    }); //Parallel.For
            //}
            //catch (Exception e3)
            //{
            //    MessageBox.Show(e3.ToString());
            //}

            
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

            Glibs.deleteEmptyRows(dataSet1.Tables["FileList"], "FileName");

            dataGridView1.Refresh();



            try
            {
                    for (int j = 0; j < dataGridView1.RowCount - 1; j++)
                {

                    string captureType = Glibs.toStringNullable(dataSet1.Tables["FileList"].Rows[j]["capture"].ToString());
                    string sourceFile = Path.Combine(rootFolderTextBox.Text, dataSet1.Tables["FileList"].Rows[j]["FileName"].ToString());
                    string destFile = Path.Combine(newPath, dataSet1.Tables["FileList"].Rows[j]["FileName"].ToString());


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
                MessageBox.Show("Please make sure the files are exists: " + _error_fileNames.Trim(",".ToCharArray()));
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
        }

        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            //multilines
            dataGridView1.Columns["randomGen"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void saveSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox2.Focus(); //TO MAKE SURE LEAVE DATAGRID AND UPDATE THE CHANGES
            this.Focus();

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
                    dataSet1.Tables["SummaryFiles"].Clear();
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
                if (e.ColumnIndex == 0) //fileName is entered
                {
                    if (dataSet1.Tables["FileList"].Rows[e.RowIndex]["outputFileName"].ToString().Trim().Length <= 0)
                    {
                        dataGridView1["outputFileName", e.RowIndex].Value = dataGridView1[0, e.RowIndex].EditedFormattedValue; //copy values from input to output
                    }
                }
            }
            catch{}
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control && e.KeyCode == Keys.Delete)
                {
                    fileListBindingSource1.RemoveCurrent();
                }
                else if (e.Control && e.KeyCode == Keys.C)
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
                if (e.ColumnIndex == 0) //fileName is entered
                {
                    summayFilesDataGridView["dataGridViewTextBoxColumn1", e.RowIndex].Value = summayFilesDataGridView[0, e.RowIndex].EditedFormattedValue; //copy values from input to output
                }
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //if (fileExistsCheck())
            // {
 
            Glibs.deleteEmptyRows(dataSet1.Tables["SummaryFiles"], "sourceFile");  //delete empty rows

            summayFilesDataGridView.Refresh();


            //pass values to the new thread
            Thread oThread = new Thread(new ParameterizedThreadStart(process3));
            System.Threading.Thread.Sleep(18);  // because every Environment.Tickcount is 15.6ms
            Thread.SpinWait(16);
            oThread.Start(this);

            //process3(this);
            // }


        }

        private void process3(object originalForm)
        {
            string rootFolderTextBoxText = ((Form1)originalForm).rootFolderTextBox.Text as string;

            //step 3: run commands



            for (int j = 0; j <= dataSet1.Tables["SummaryFiles"].Rows.Count - 1; j++)
                //for (int j = 0; j < summayFilesDataGridView.RowCount - 1; j++)
            {
                string filename = Glibs.toStringNullable(dataSet1.Tables["SummaryFiles"].Rows[j]["sourceFile"]);
                int? fromLine = Glibs.tointNullable(dataSet1.Tables["SummaryFiles"].Rows[j]["fromLine"]);
                int? toLine = Glibs.tointNullable(dataSet1.Tables["SummaryFiles"].Rows[j]["toLine"]);
                string outputFileName = Glibs.toStringNullable(dataSet1.Tables["SummaryFiles"].Rows[j]["outputFileOrTable"]);

                bool? onlyOneHeader = Glibs.toboolNullable(dataSet1.Tables["SummaryFiles"].Rows[j]["onlyOneHeader"]);
                bool? addSourceFolderNumInFront = Glibs.toboolNullable(dataSet1.Tables["SummaryFiles"].Rows[j]["addSourceFolderNumInFront"]);
                string delimited = Glibs.toStringNullable(dataSet1.Tables["SummaryFiles"].Rows[j]["delimited"]);

                delimited = delimited.Replace("(tab)", "\t");

                string rootFolder = rootFolderTextBox1.Text.ToString().Trim();
                int? _sub_folder_num = Glibs.tointNullable(simulationNumTextBox.Text);
                string captured = "";

                if (_sub_folder_num != null && (fromLine != null && toLine != null))///copy line text
                {
                    for (int i = 1; i <= _sub_folder_num; i++)
                    {
                        
                        if ((onlyOneHeader == null || onlyOneHeader==true))
                        {
                            if ( i == 1)
                            { fromLine = Glibs.tointNullable(dataSet1.Tables["SummaryFiles"].Rows[j]["fromLine"]); }
                                else
                            { fromLine = Glibs.tointNullable(dataSet1.Tables["SummaryFiles"].Rows[j]["fromLine"]) + 1; }
                         }




                        //open file and get conents, then copy over the conents
                        string sourceFile = Path.Combine(Path.Combine(rootFolder, i.ToString()), filename);

                        if ((addSourceFolderNumInFront == null || addSourceFolderNumInFront == true))
                        { captured = captured + Glibs.ReadLineText(sourceFile, fromLine, toLine, true, i.ToString() , delimited) + Environment.NewLine; }
                        else
                        { captured = captured + Glibs.ReadLineText(sourceFile, fromLine, toLine, false, null, null) + Environment.NewLine; }
                        

                    }


                    string destFile = Path.Combine(rootFolder, outputFileName);
                    Glibs.WritelineText(destFile, captured);
                }

            }

            MessageBox.Show("Step 3 completed.", "FS Message.");

        }

        private void summayFilesDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            //int i = 5;
            settingsBindingSource.EndEdit();
        }

        private void rootFolderTextBox_Leave(object sender, EventArgs e)
        {
            settingsBindingSource.EndEdit();
        }

        private void simulationNumTextBox_Leave(object sender, EventArgs e)
        {
            settingsBindingSource.EndEdit();
        }

        private void rootFolderTextBox1_Leave(object sender, EventArgs e)
        {
            settingsBindingSource.EndEdit();
        }

        private bool generateRandDist(string sourceFile, string outputFile, string TextBoxValue)
        {
            //string sourceFile = @"C:\_MSmesh_\(my documents)\__PROJECTS__\Fishery Simulation\Fishery Simulation\bin\Release\~~.txt";
            //string outputFile = "";

            List<string> strs = new List<string>();
            strs.AddRange(Glibs.ReadText(sourceFile));

            //string _originalTextboxValue = "<FileList>=Anything(RAND,2,34,false)";
            string _originalTextboxValue = TextBoxValue;
            string[] _textboxValueInLines = _originalTextboxValue.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);


            foreach (string _eachPairLine in _textboxValueInLines)   //_eachPairLine is "abc=randdis(1,2,4,flase)"
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
                    strs[(int)keywordFoundInIndexOf + 1] = (Glibs.CreateRandNorm(strs[(int)keywordFoundInIndexOf + 1], " ", null , double.Parse(_eachValue[0].Trim()), double.Parse(_eachValue[1].Trim()), false)); //change value for the next time
                
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

        private void button4_Click(object sender, EventArgs e)
        {
            //string s = "";


            //for (int i = 0; i < 10; ++i)
            //{
            //    s = s + "_" + SimpleRNG.GetNormal(1, 0.6).ToString();
            //}

            //MessageBox.Show(s);

            loadPlugins();
        }

        private void dataGridView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (e.Data.GetData("FileDrop") as string[]);

            for (int i = 0; i < files.Length; i++)
            {
                try
                {
                    files[i] = Path.GetFileName(files[i]);

                    DataRow row = dataSet1.Tables["FileList"].NewRow();
                    row["FileName"] = files[i];
                    row["outputFileName"] = files[i];
                    dataSet1.FileList.Rows.Add(row);
                }
                catch
                { }
            }
            dataGridView1.Refresh();
        }

        private void rootFolderTextBox_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string[] files = (e.Data.GetData("FileDrop") as string[]);

                dataSet1.Settings.Rows[0]["rootFolder"] = Path.GetDirectoryName(files[0]);
            }
            catch
            {}
        }

        private void summayFilesDataGridView_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void summayFilesDataGridView_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (e.Data.GetData("FileDrop") as string[]);

            for (int i = 0; i < files.Length; i++)
            {
                try
                {
                    files[i] = Path.GetFileName(files[i]);

                    DataRow row = dataSet1.Tables["SummaryFiles"].NewRow();
                    row["sourceFile"] = files[i];
                    row["outputFileOrTable"] = files[i];
                    dataSet1.SummaryFiles.Rows.Add(row);
                }
                catch
                { }
            }
            summayFilesDataGridView.Refresh();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //convert back from EditOnKeystrokOrF2 mode to enter mode
            DataGridView dgv = (DataGridView)sender;
            dgv.EditMode = DataGridViewEditMode.EditOnEnter;
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            //convert to EditOnKeystrokOrF2 mode so people can delete records
            DataGridView dgv = (DataGridView)sender;
            DataGridView.HitTestInfo hti = dgv.HitTest(e.X, e.Y);
            if (hti.Type == DataGridViewHitTestType.RowHeader)
            {
                dgv.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
                dgv.EndEdit();
            }

        }

        private void pluginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadPlugins();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView2_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (e.Data.GetData("FileDrop") as string[]);

            for (int i = 0; i < files.Length; i++)
            {
                try
                {
                    files[i] = Path.GetFileName(files[i]);

                    DataRow row = dataSet1.Tables["FileList2"].NewRow();
                    row["FileName"] = files[i];
                    row["outputFileName"] = files[i];
                    dataSet1.FileList2.Rows.Add(row);
                }
                catch
                { }
            }
            dataGridView2.Refresh();
        }

        private void dataGridView2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            //convert to EditOnKeystrokOrF2 mode so people can delete records
            DataGridView dgv = (DataGridView)sender;
            DataGridView.HitTestInfo hti = dgv.HitTest(e.X, e.Y);
            if (hti.Type == DataGridViewHitTestType.RowHeader)
            {
                dgv.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
                dgv.EndEdit();
            }
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0) //fileName is entered
                {
                    if (dataSet1.Tables["FileList2"].Rows[e.RowIndex]["outputFileName"].ToString().Trim().Length <= 0)
                    {
                        dataGridView2["outputFileName", e.RowIndex].Value = dataGridView2[0, e.RowIndex].EditedFormattedValue; //copy values from input to output
                    }
                }
            }
            catch { }
        }

        private void dataGridView2_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            //multilines
            dataGridView2.Columns["randomGen"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void sSexeProfileGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            profileGenerator pg = new profileGenerator();
            pg.ShowDialog();
        }



    
    
    }
}
