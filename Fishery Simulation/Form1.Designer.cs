namespace Fishery_Simulation
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label rootFolderLabel;
            System.Windows.Forms.Label rootFolderLabel1;
            System.Windows.Forms.Label simulationNumLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hellpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.rootFolderTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.summayFilesDataGridView = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.rootFolderTextBox1 = new System.Windows.Forms.TextBox();
            this.simulationNumTextBox = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.settingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new Fishery_Simulation.DataSet1();
            this.fileListBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.summayFilesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.onlyOneHeader = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.addSourceFolderNumInFront = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.delimited = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.capture = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.fromLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.block = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.blockend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.randomGen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outputFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            rootFolderLabel = new System.Windows.Forms.Label();
            rootFolderLabel1 = new System.Windows.Forms.Label();
            simulationNumLabel = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.summayFilesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileListBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.summayFilesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rootFolderLabel
            // 
            rootFolderLabel.AutoSize = true;
            rootFolderLabel.Dock = System.Windows.Forms.DockStyle.Left;
            rootFolderLabel.Location = new System.Drawing.Point(23, 28);
            rootFolderLabel.Margin = new System.Windows.Forms.Padding(3);
            rootFolderLabel.Name = "rootFolderLabel";
            rootFolderLabel.Size = new System.Drawing.Size(65, 17);
            rootFolderLabel.TabIndex = 9;
            rootFolderLabel.Text = "Root Folder:";
            // 
            // rootFolderLabel1
            // 
            rootFolderLabel1.AutoSize = true;
            rootFolderLabel1.Location = new System.Drawing.Point(23, 28);
            rootFolderLabel1.Margin = new System.Windows.Forms.Padding(3);
            rootFolderLabel1.Name = "rootFolderLabel1";
            rootFolderLabel1.Size = new System.Drawing.Size(65, 13);
            rootFolderLabel1.TabIndex = 10;
            rootFolderLabel1.Text = "Root Folder:";
            // 
            // simulationNumLabel
            // 
            simulationNumLabel.AutoSize = true;
            simulationNumLabel.Location = new System.Drawing.Point(23, 50);
            simulationNumLabel.Margin = new System.Windows.Forms.Padding(3);
            simulationNumLabel.Name = "simulationNumLabel";
            simulationNumLabel.Size = new System.Drawing.Size(105, 13);
            simulationNumLabel.TabIndex = 11;
            simulationNumLabel.Text = "Create # simulations:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 405);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(819, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(110, 17);
            this.toolStripStatusLabel1.Text = "--Notification Area--";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.hellpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(819, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveSettingToolStripMenuItem,
            this.loadSettingToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveSettingToolStripMenuItem
            // 
            this.saveSettingToolStripMenuItem.Name = "saveSettingToolStripMenuItem";
            this.saveSettingToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.saveSettingToolStripMenuItem.Text = "Save Setting";
            this.saveSettingToolStripMenuItem.Click += new System.EventHandler(this.saveSettingToolStripMenuItem_Click);
            // 
            // loadSettingToolStripMenuItem
            // 
            this.loadSettingToolStripMenuItem.Name = "loadSettingToolStripMenuItem";
            this.loadSettingToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.loadSettingToolStripMenuItem.Text = "Load Setting";
            this.loadSettingToolStripMenuItem.Click += new System.EventHandler(this.loadSettingToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // hellpToolStripMenuItem
            // 
            this.hellpToolStripMenuItem.Name = "hellpToolStripMenuItem";
            this.hellpToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.hellpToolStripMenuItem.Text = "Help";
            this.hellpToolStripMenuItem.Click += new System.EventHandler(this.hellpToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(819, 381);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(811, 355);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Process Data";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(805, 349);
            this.splitContainer1.SplitterDistance = 269;
            this.splitContainer1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.Controls.Add(this.textBox3, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBox2, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button2, 3, 1);
            this.tableLayoutPanel1.Controls.Add(rootFolderLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.rootFolderTextBox, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(803, 267);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // textBox3
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textBox3, 2);
            this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.settingsBindingSource, "commandRootFolder", true));
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox3.Location = new System.Drawing.Point(143, 74);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(657, 20);
            this.textBox3.TabIndex = 40;
            // 
            // textBox2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textBox2, 2);
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.settingsBindingSource, "simulationNum", true));
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBox2.Location = new System.Drawing.Point(143, 49);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(56, 20);
            this.textBox2.TabIndex = 30;
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileName,
            this.capture,
            this.fromLine,
            this.toLine,
            this.block,
            this.blockend,
            this.randomGen,
            this.outputFileName});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView1, 2);
            this.dataGridView1.DataSource = this.fileListBindingSource1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(143, 100);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(657, 164);
            this.dataGridView1.TabIndex = 50;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellLeave);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            this.dataGridView1.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView1_DefaultValuesNeeded);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 3);
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(426, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Step 1: Prepare (process in root folder to create sub folder set)";
            // 
            // button2
            // 
            this.button2.Image = global::Fishery_Simulation.Properties.Resources.Open_Folder_Full_icon_20x20;
            this.button2.Location = new System.Drawing.Point(781, 25);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(22, 22);
            this.button2.TabIndex = 20;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // rootFolderTextBox
            // 
            this.rootFolderTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.settingsBindingSource, "rootFolder", true));
            this.rootFolderTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rootFolderTextBox.Location = new System.Drawing.Point(143, 26);
            this.rootFolderTextBox.Margin = new System.Windows.Forms.Padding(3, 1, 0, 3);
            this.rootFolderTextBox.Name = "rootFolderTextBox";
            this.rootFolderTextBox.Size = new System.Drawing.Size(638, 20);
            this.rootFolderTextBox.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(23, 51);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Create # simulations:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(23, 74);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Command:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(23, 100);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 164);
            this.label4.TabIndex = 13;
            this.label4.Text = "Copy Files to sub folder:";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoScroll = true;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 663F));
            this.tableLayoutPanel2.Controls.Add(this.textBox4, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.button1, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, -1);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(803, 75);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // textBox4
            // 
            this.textBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.settingsBindingSource, "commandSubFolder", true));
            this.textBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox4.Location = new System.Drawing.Point(143, 28);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(657, 20);
            this.textBox4.TabIndex = 60;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(725, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 21);
            this.button1.TabIndex = 70;
            this.button1.Text = "RUN";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label5, 3);
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(311, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "Step 2: Simulation (process in each sub folder)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Location = new System.Drawing.Point(23, 28);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Command:";
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.Controls.Add(this.tableLayoutPanel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(811, 355);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Output Results";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoScroll = true;
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.summayFilesDataGridView, 2, 3);
            this.tableLayoutPanel3.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.rootFolderTextBox1, 2, 1);
            this.tableLayoutPanel3.Controls.Add(rootFolderLabel1, 1, 1);
            this.tableLayoutPanel3.Controls.Add(simulationNumLabel, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.simulationNumTextBox, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.button3, 2, 4);
            this.tableLayoutPanel3.Controls.Add(this.label7, 1, 3);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(805, 349);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // summayFilesDataGridView
            // 
            this.summayFilesDataGridView.AllowUserToOrderColumns = true;
            this.summayFilesDataGridView.AutoGenerateColumns = false;
            this.summayFilesDataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.summayFilesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.summayFilesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.onlyOneHeader,
            this.addSourceFolderNumInFront,
            this.delimited});
            this.summayFilesDataGridView.DataSource = this.summayFilesBindingSource;
            this.summayFilesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.summayFilesDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.summayFilesDataGridView.Location = new System.Drawing.Point(143, 72);
            this.summayFilesDataGridView.Name = "summayFilesDataGridView";
            this.summayFilesDataGridView.Size = new System.Drawing.Size(659, 249);
            this.summayFilesDataGridView.TabIndex = 100;
            this.summayFilesDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.summayFilesDataGridView_CellEndEdit);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.label8, 3);
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(630, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "Step 3: Output (process in results from each sub folder and merge to one file in " +
    "the root folder)";
            // 
            // rootFolderTextBox1
            // 
            this.rootFolderTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.settingsBindingSource, "rootFolder", true));
            this.rootFolderTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rootFolderTextBox1.Location = new System.Drawing.Point(143, 28);
            this.rootFolderTextBox1.Name = "rootFolderTextBox1";
            this.rootFolderTextBox1.Size = new System.Drawing.Size(659, 20);
            this.rootFolderTextBox1.TabIndex = 80;
            // 
            // simulationNumTextBox
            // 
            this.simulationNumTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.settingsBindingSource, "simulationNum", true));
            this.simulationNumTextBox.Location = new System.Drawing.Point(143, 50);
            this.simulationNumTextBox.Name = "simulationNumTextBox";
            this.simulationNumTextBox.Size = new System.Drawing.Size(56, 20);
            this.simulationNumTextBox.TabIndex = 90;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(727, 327);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 19);
            this.button3.TabIndex = 13;
            this.button3.Text = "RUN";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 70);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 52);
            this.label7.TabIndex = 14;
            this.label7.Text = "Process files in each sub folder and create a summary file in the root:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Setting Files (*.xml)|*.xml|All Files (*.*)|*.*";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Setting Files (*.xml)|*.xml|All Files (*.*)|*.*";
            // 
            // settingsBindingSource
            // 
            this.settingsBindingSource.DataMember = "Settings";
            this.settingsBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.Locale = new System.Globalization.CultureInfo("");
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fileListBindingSource1
            // 
            this.fileListBindingSource1.DataMember = "FileList";
            this.fileListBindingSource1.DataSource = this.dataSet1;
            // 
            // summayFilesBindingSource
            // 
            this.summayFilesBindingSource.DataMember = "SummayFiles";
            this.summayFilesBindingSource.DataSource = this.dataSet1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "sourceFile";
            this.dataGridViewTextBoxColumn1.HeaderText = "Result File Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 103;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "fromLine";
            this.dataGridViewTextBoxColumn2.HeaderText = "From # line";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 63;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "toLine";
            this.dataGridViewTextBoxColumn3.HeaderText = "To # line";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 69;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "outoutFileOrTable";
            this.dataGridViewTextBoxColumn4.HeaderText = "Final File Name in root folder";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 108;
            // 
            // onlyOneHeader
            // 
            this.onlyOneHeader.DataPropertyName = "onlyOneHeader";
            this.onlyOneHeader.FillWeight = 80F;
            this.onlyOneHeader.HeaderText = "Only 1 header row on the top of final file";
            this.onlyOneHeader.Name = "onlyOneHeader";
            this.onlyOneHeader.Width = 80;
            // 
            // addSourceFolderNumInFront
            // 
            this.addSourceFolderNumInFront.DataPropertyName = "addSourceFolderNumInFront";
            this.addSourceFolderNumInFront.FillWeight = 80F;
            this.addSourceFolderNumInFront.HeaderText = "Add sub folder name to beginning of each row";
            this.addSourceFolderNumInFront.Name = "addSourceFolderNumInFront";
            this.addSourceFolderNumInFront.Width = 80;
            // 
            // delimited
            // 
            this.delimited.DataPropertyName = "delimited";
            this.delimited.FillWeight = 80F;
            this.delimited.HeaderText = "Delimited if add sub folder name";
            this.delimited.Name = "delimited";
            this.delimited.Width = 80;
            // 
            // FileName
            // 
            this.FileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FileName.DataPropertyName = "FileName";
            this.FileName.FillWeight = 500F;
            this.FileName.HeaderText = "File Name";
            this.FileName.MinimumWidth = 100;
            this.FileName.Name = "FileName";
            // 
            // capture
            // 
            this.capture.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.capture.DataPropertyName = "capture";
            this.capture.HeaderText = "Special";
            this.capture.Items.AddRange(new object[] {
            "None",
            "Lines",
            "Block",
            "Rand Gen"});
            this.capture.Name = "capture";
            this.capture.ToolTipText = "Special Feature: None=regular copy, Lines=only selected lines, Block=capture head" +
    "er based on text you enerted";
            this.capture.Width = 48;
            // 
            // fromLine
            // 
            this.fromLine.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.fromLine.DataPropertyName = "fromLine";
            this.fromLine.FillWeight = 30F;
            this.fromLine.HeaderText = "from Line #";
            this.fromLine.Name = "fromLine";
            this.fromLine.Width = 85;
            // 
            // toLine
            // 
            this.toLine.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.toLine.DataPropertyName = "toLine";
            this.toLine.FillWeight = 30F;
            this.toLine.HeaderText = "to Line #";
            this.toLine.Name = "toLine";
            this.toLine.Width = 74;
            // 
            // block
            // 
            this.block.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.block.DataPropertyName = "block";
            this.block.HeaderText = "Block Starting Text";
            this.block.Name = "block";
            this.block.Width = 93;
            // 
            // blockend
            // 
            this.blockend.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.blockend.DataPropertyName = "blockend";
            this.blockend.FillWeight = 50F;
            this.blockend.HeaderText = "Block End Text";
            this.blockend.Name = "blockend";
            this.blockend.Visible = false;
            this.blockend.Width = 78;
            // 
            // randomGen
            // 
            this.randomGen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.randomGen.DataPropertyName = "randomGen";
            this.randomGen.FillWeight = 500F;
            this.randomGen.HeaderText = "Random Generator";
            this.randomGen.Name = "randomGen";
            this.randomGen.ToolTipText = "\"shift\"+\"Enter\" for next line";
            this.randomGen.Width = 112;
            // 
            // outputFileName
            // 
            this.outputFileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.outputFileName.DataPropertyName = "outputFileName";
            this.outputFileName.FillWeight = 400F;
            this.outputFileName.HeaderText = "Output File Name";
            this.outputFileName.MinimumWidth = 100;
            this.outputFileName.Name = "outputFileName";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 427);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Fishery Simulation";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.summayFilesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileListBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.summayFilesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem saveSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadSettingToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.BindingSource fileListBindingSource1;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource settingsBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox rootFolderTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem hellpToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataGridView summayFilesDataGridView;
        private System.Windows.Forms.BindingSource summayFilesBindingSource;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox rootFolderTextBox1;
        private System.Windows.Forms.TextBox simulationNumTextBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn onlyOneHeader;
        private System.Windows.Forms.DataGridViewCheckBoxColumn addSourceFolderNumInFront;
        private System.Windows.Forms.DataGridViewTextBoxColumn delimited;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewComboBoxColumn capture;
        private System.Windows.Forms.DataGridViewTextBoxColumn fromLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn toLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn block;
        private System.Windows.Forms.DataGridViewTextBoxColumn blockend;
        private System.Windows.Forms.DataGridViewTextBoxColumn randomGen;
        private System.Windows.Forms.DataGridViewTextBoxColumn outputFileName;
    }
}

