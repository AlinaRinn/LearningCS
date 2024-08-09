
namespace DiskReader {
    partial class Form2 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.button2 = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this.HeadName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LastEdit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_delete = new System.Windows.Forms.Button();
            this.button_copy = new System.Windows.Forms.Button();
            this.button_rename = new System.Windows.Forms.Button();
            this.button_set = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.button_file = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.button_new = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_rename = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_copy = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.diskInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rPSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fIOdllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsRenamerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_stop = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.registryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(743, 587);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 27);
            this.button2.TabIndex = 3;
            this.button2.Text = "Exit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(12, 97);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listView1);
            this.splitContainer1.Size = new System.Drawing.Size(810, 484);
            this.splitContainer1.SplitterDistance = 276;
            this.splitContainer1.TabIndex = 4;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(276, 484);
            this.treeView1.TabIndex = 0;
            this.treeView1.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView1_BeforeLabelEdit);
            this.treeView1.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView1_AfterLabelEdit);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder_open.png");
            this.imageList1.Images.SetKeyName(1, "Без названия.png");
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.HeadName,
            this.Type,
            this.LastEdit});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(530, 484);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // HeadName
            // 
            this.HeadName.Text = "Name";
            this.HeadName.Width = 229;
            // 
            // Type
            // 
            this.Type.Text = "Type";
            this.Type.Width = 114;
            // 
            // LastEdit
            // 
            this.LastEdit.Text = "Last Edited";
            this.LastEdit.Width = 132;
            // 
            // button_delete
            // 
            this.button_delete.Location = new System.Drawing.Point(123, 3);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(64, 23);
            this.button_delete.TabIndex = 5;
            this.button_delete.Text = "Delete";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_copy
            // 
            this.button_copy.Location = new System.Drawing.Point(55, 3);
            this.button_copy.Name = "button_copy";
            this.button_copy.Size = new System.Drawing.Size(62, 23);
            this.button_copy.TabIndex = 6;
            this.button_copy.Text = "Copy";
            this.button_copy.UseVisualStyleBackColor = true;
            this.button_copy.Click += new System.EventHandler(this.button_copy_Click);
            // 
            // button_rename
            // 
            this.button_rename.Location = new System.Drawing.Point(193, 3);
            this.button_rename.Name = "button_rename";
            this.button_rename.Size = new System.Drawing.Size(83, 23);
            this.button_rename.TabIndex = 7;
            this.button_rename.Text = "Rename";
            this.button_rename.UseVisualStyleBackColor = true;
            this.button_rename.Click += new System.EventHandler(this.button_rename_Click);
            // 
            // button_set
            // 
            this.button_set.Location = new System.Drawing.Point(205, 587);
            this.button_set.Name = "button_set";
            this.button_set.Size = new System.Drawing.Size(83, 27);
            this.button_set.TabIndex = 8;
            this.button_set.Text = ". . .";
            this.button_set.UseVisualStyleBackColor = true;
            this.button_set.Click += new System.EventHandler(this.button_set_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 594);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Manual path:";
            // 
            // btn_refresh
            // 
            this.btn_refresh.Image = ((System.Drawing.Image)(resources.GetObject("btn_refresh.Image")));
            this.btn_refresh.Location = new System.Drawing.Point(11, 585);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(32, 29);
            this.btn_refresh.TabIndex = 11;
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // button_file
            // 
            this.button_file.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button_file.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.button_file.FlatAppearance.BorderSize = 0;
            this.button_file.Location = new System.Drawing.Point(-1, 3);
            this.button_file.Margin = new System.Windows.Forms.Padding(0);
            this.button_file.Name = "button_file";
            this.button_file.Size = new System.Drawing.Size(61, 22);
            this.button_file.TabIndex = 12;
            this.button_file.Text = "Select file";
            this.button_file.UseVisualStyleBackColor = false;
            this.button_file.Click += new System.EventHandler(this.button_file_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Directory Manager";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Location = new System.Drawing.Point(12, 32);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Margin = new System.Windows.Forms.Padding(11);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.button_new);
            this.splitContainer2.Panel2.Controls.Add(this.button_copy);
            this.splitContainer2.Panel2.Controls.Add(this.button_delete);
            this.splitContainer2.Panel2.Controls.Add(this.button_rename);
            this.splitContainer2.Size = new System.Drawing.Size(276, 61);
            this.splitContainer2.SplitterDistance = 25;
            this.splitContainer2.TabIndex = 14;
            // 
            // button_new
            // 
            this.button_new.Location = new System.Drawing.Point(-1, 3);
            this.button_new.Name = "button_new";
            this.button_new.Size = new System.Drawing.Size(50, 23);
            this.button_new.TabIndex = 14;
            this.button_new.Text = "New";
            this.button_new.UseVisualStyleBackColor = true;
            this.button_new.Click += new System.EventHandler(this.button_new_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(63, 7);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(306, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = ". . .";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Location = new System.Drawing.Point(292, 32);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.splitContainer3.Panel1.Controls.Add(this.label4);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.btn_rename);
            this.splitContainer3.Panel2.Controls.Add(this.btn_delete);
            this.splitContainer3.Panel2.Controls.Add(this.label3);
            this.splitContainer3.Panel2.Controls.Add(this.btn_copy);
            this.splitContainer3.Panel2.Controls.Add(this.button_file);
            this.splitContainer3.Size = new System.Drawing.Size(530, 61);
            this.splitContainer3.SplitterDistance = 25;
            this.splitContainer3.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(241, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "File Manager";
            // 
            // btn_rename
            // 
            this.btn_rename.Location = new System.Drawing.Point(475, 2);
            this.btn_rename.Name = "btn_rename";
            this.btn_rename.Size = new System.Drawing.Size(55, 23);
            this.btn_rename.TabIndex = 21;
            this.btn_rename.Text = "Rename";
            this.btn_rename.UseVisualStyleBackColor = true;
            this.btn_rename.Click += new System.EventHandler(this.btn_rename_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(420, 2);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(49, 23);
            this.btn_delete.TabIndex = 20;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_copy
            // 
            this.btn_copy.Location = new System.Drawing.Point(375, 2);
            this.btn_copy.Name = "btn_copy";
            this.btn_copy.Size = new System.Drawing.Size(39, 23);
            this.btn_copy.TabIndex = 19;
            this.btn_copy.Text = "Copy";
            this.btn_copy.UseVisualStyleBackColor = true;
            this.btn_copy.Click += new System.EventHandler(this.btn_copy_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.diskInfoToolStripMenuItem,
            this.rPSToolStripMenuItem,
            this.fIOdllToolStripMenuItem,
            this.windowsRenamerToolStripMenuItem,
            this.registryToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(834, 24);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // diskInfoToolStripMenuItem
            // 
            this.diskInfoToolStripMenuItem.Name = "diskInfoToolStripMenuItem";
            this.diskInfoToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.diskInfoToolStripMenuItem.Text = "DiskInfo";
            this.diskInfoToolStripMenuItem.Click += new System.EventHandler(this.diskInfoToolStripMenuItem_Click);
            // 
            // rPSToolStripMenuItem
            // 
            this.rPSToolStripMenuItem.Name = "rPSToolStripMenuItem";
            this.rPSToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.rPSToolStripMenuItem.Text = "RPS";
            this.rPSToolStripMenuItem.Click += new System.EventHandler(this.rPSToolStripMenuItem_Click);
            // 
            // fIOdllToolStripMenuItem
            // 
            this.fIOdllToolStripMenuItem.Name = "fIOdllToolStripMenuItem";
            this.fIOdllToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.fIOdllToolStripMenuItem.Text = "FIO.dll";
            this.fIOdllToolStripMenuItem.Click += new System.EventHandler(this.fIOdllToolStripMenuItem_Click);
            // 
            // windowsRenamerToolStripMenuItem
            // 
            this.windowsRenamerToolStripMenuItem.Name = "windowsRenamerToolStripMenuItem";
            this.windowsRenamerToolStripMenuItem.Size = new System.Drawing.Size(121, 20);
            this.windowsRenamerToolStripMenuItem.Text = "Windows\' manager";
            this.windowsRenamerToolStripMenuItem.Click += new System.EventHandler(this.windowsRenamerToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(358, 589);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(218, 25);
            this.progressBar1.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(301, 594);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Progress:";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(675, 595);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "...";
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(582, 588);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(46, 27);
            this.btn_stop.TabIndex = 24;
            this.btn_stop.Text = "Stop";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(776, 10);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 13);
            this.label7.TabIndex = 25;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(799, 7);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 21);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker2_ProgressChanged);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // registryToolStripMenuItem
            // 
            this.registryToolStripMenuItem.Name = "registryToolStripMenuItem";
            this.registryToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.registryToolStripMenuItem.Text = "Registry";
            this.registryToolStripMenuItem.Click += new System.EventHandler(this.registryToolStripMenuItem_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 621);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.splitContainer3);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_set);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(850, 660);
            this.MinimumSize = new System.Drawing.Size(850, 660);
            this.Name = "Form2";
            this.ShowIcon = false;
            this.Text = "File Explorer";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader HeadName;
        private System.Windows.Forms.ColumnHeader Type;
        private System.Windows.Forms.ColumnHeader LastEdit;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_copy;
        private System.Windows.Forms.Button button_rename;
        private System.Windows.Forms.Button button_set;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Button button_file;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_copy;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_rename;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem diskInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button button_new;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label5;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem rPSToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.ToolStripMenuItem fIOdllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsRenamerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registryToolStripMenuItem;
    }
}