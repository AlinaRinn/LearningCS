using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace DiskReader
{
    public partial class Form2 : Form
    {
        /*WINAPI constants*/
        const int WM_DEVICECHANGE = 0x219;
        const int DBT_DEVICEARRIVAL = 0x8000;
        const int DBT_DEVICEREMOVECOMPLETE = 0x8004;
        const int DBT_DEVTYP_VOLUME = 0x00000002;
        public Form2()
        {
            InitializeComponent();
            PopulateTreeView();
            this.treeView1.NodeMouseClick += new TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker2.WorkerSupportsCancellation = true;
            backgroundWorker2.WorkerReportsProgress = true;
        }
        private void fIOdllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 Form = new Form6();
            Form.ShowDialog();
        }
        private void diskInfoToolStripMenuItem_Click(object sender, EventArgs e)                                                                                    // Open DiskInfo
        {
            Form1 Form = new Form1();
            Form.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)                                                                                      // Open About
        {
            Form4 Form = new Form4();
            Form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)                                                                                                        // Close form2
        {
            this.Close();
        }

        public string sourcedir;
        public string path;
        private void PopulateTreeView()                                                                                                                            // Create Tree
        {
            TreeNode rootNode;
            DirectoryInfo info = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
            path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            if (info.Exists)
            {
                rootNode = new TreeNode(info.Name);
                rootNode.Tag = info;
                GetDirectories(info.GetDirectories(), rootNode);
                treeView1.Nodes.Add(rootNode);
            }
        }

        int i = 0;
        private void GetDirectories(DirectoryInfo[] subDirs, TreeNode nodeToAddTo)                                                                                // Fulling Tree
        {
            this.Cursor = Cursors.WaitCursor;
            TreeNode aNode;
            DirectoryInfo[] subSubDirs;
            foreach (DirectoryInfo subDir in subDirs)
            {
                aNode = new TreeNode(subDir.Name, 0, 0);
                aNode.Tag = subDir;
                aNode.ImageKey = "folder";
                try
                {
                    subSubDirs = subDir.GetDirectories();
                    if (subSubDirs.Length != 0)
                    {
                        GetDirectories(subSubDirs, aNode);
                    }
                    nodeToAddTo.Nodes.Add(aNode);
                }
                catch (System.UnauthorizedAccessException)
                {
                    MessageBox.Show("System: Access denied", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    i++;
                    label7.Text = i.ToString();
                }
            }
            this.Cursor = Cursors.Default;
        }

        void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)                                                                              // For Node's use
        {
            TreeNode newSelected = e.Node;
            listView1.Items.Clear();
            DirectoryInfo nodeDirInfo = (DirectoryInfo)newSelected.Tag;
            ListViewItem.ListViewSubItem[] subItems;
            ListViewItem item = null;
            //int i = 0;
            //List<string> listpath = new List<string>();
            foreach (DirectoryInfo dir in nodeDirInfo.GetDirectories())
            {
                item = new ListViewItem(dir.Name, 0);
                subItems = new ListViewItem.ListViewSubItem[] {new ListViewItem.ListViewSubItem(item, "Directory"), new ListViewItem.ListViewSubItem(item, dir.LastAccessTime.ToShortDateString())};
                item.SubItems.AddRange(subItems);
                listView1.Items.Add(item);
                //listpath.Add(dir.FullName.ToString());                                                                                                         // Fulling listView
                //i++;
            }
            foreach (FileInfo file in nodeDirInfo.GetFiles())
            {
                item = new ListViewItem(file.Name, 1);
                subItems = new ListViewItem.ListViewSubItem[] { new ListViewItem.ListViewSubItem(item, "File"), new ListViewItem.ListViewSubItem(item, file.LastAccessTime.ToShortDateString()) };
                item.SubItems.AddRange(subItems);
                listView1.Items.Add(item);
                //string filepath = Path.GetFullPath(item.Text);
                //MessageBox.Show(filepath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //int[] test = listView1.SelectedListView;
            }
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void button_refresh_Click(object sender, EventArgs e)                                                                                            // Refresh Tree
        {
            this.Cursor = Cursors.WaitCursor; 
            DirectoryInfo info = new DirectoryInfo(path);
            treeView1.Nodes.Clear();
            TreeNode rootNode;
            rootNode = new TreeNode(info.Name);
            rootNode.Tag = info;
            GetDirectories(info.GetDirectories(), rootNode);
            treeView1.Nodes.Add(rootNode);
            this.Cursor = Cursors.Default;
        }

        private void button_set_Click(object sender, EventArgs e)                                                                                              // Set custom path
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.ShowDialog();
            path = folder.SelectedPath.ToString();
            if (path == "")
            {
                MessageBox.Show("Set path", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            button_refresh_Click(sender, e);
        }

        public string selectedNodeText;
        private void button_rename_Click(object sender, EventArgs e)                                                                                          // Renaming
        {
            if (treeView1.SelectedNode != null)
            {
                TreeNode node = this.treeView1.SelectedNode as TreeNode;
                selectedNodeText = node.Text;
                this.treeView1.LabelEdit = true;
                node.BeginEdit();
            }
            else
            {
                MessageBox.Show("Choose folder", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void treeView1_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                sourcedir = path + @"..\" + @"..\" + treeView1.SelectedNode.FullPath.ToString();
            }
            else
            {
                MessageBox.Show("Choose folder", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }


        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            TreeNode node = this.treeView1.SelectedNode as TreeNode;
            this.treeView1.LabelEdit = false;

            if (e.Label.IndexOfAny(new char[] { '\\', '/', ':', '*', '?', '"', '<', '>', '|' }) != -1)                                                           // Check 1
            {
                MessageBox.Show("Invalid Name.\n" + "The step Name must not contain " + "following characters:\n \\ / : * ? \" < > |", "Edit Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrWhiteSpace(e.Label))                                                                                                         // Check 2
            {
                MessageBox.Show("Invalid name", "Error");
                e.CancelEdit = true;
                return;
            }
            else
            {
                //string label = (!string.IsNullOrEmpty(e.Label) ? e.Label : selectedNodeText);
                if (null != e.Label)
                {
                    try
                    {
                        //MessageBox.Show(sourcedir, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DirectoryInfo di = new DirectoryInfo(sourcedir);
                        string sous = sourcedir + @"..\" + @"..\" + @"\" + e.Label;
                        //MessageBox.Show(sous, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        di.MoveTo(sous);
                    }
                    catch (IOException er)
                    {
                        MessageBox.Show(er.Message);
                    }
                }
            }
        }

        private void button_delete_Click(object sender, EventArgs e)                                                                                           // Delete
        {
            if (treeView1.SelectedNode != null) {
                sourcedir = path + @"..\" + @"..\" + treeView1.SelectedNode.FullPath.ToString();
            }
            else
            {
                MessageBox.Show("Choose folder", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                //MessageBox.Show(path + "   " +sourcedir , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Directory.Delete(sourcedir, true);
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show("Deleting Error: Incorrect path or access denied", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            button_refresh_Click(sender, e);
        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)                                                        // Copy
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();     
            Directory.CreateDirectory(destDirName);
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(destDirName, file.Name);
                file.CopyTo(tempPath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, tempPath, copySubDirs);
                }
            }
        }

        string sourcedir2, dest;
        private void button_copy_Click(object sender, EventArgs e)                                                                                            // Copy
        {
            progressBar1.Value = 0;
            if (treeView1.SelectedNode != null)
            {
                sourcedir2 = path + @"..\" + @"..\" + treeView1.SelectedNode.FullPath.ToString();
            }
            else
            {
                MessageBox.Show("Choose folder", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FolderBrowserDialog folder = new FolderBrowserDialog();
            MessageBox.Show("Choose destination folder", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            folder.ShowDialog();
            dest = folder.SelectedPath.ToString();
            //DirectoryCopy(sourcedir2, dest, true);
            progressBar1.Value = 0;
            if (backgroundWorker2.IsBusy != true)
            {
                backgroundWorker2.RunWorkerAsync();
            }
        }

        private void button_new_Click(object sender, EventArgs e)                                                                                            // New
        {
            if (treeView1.SelectedNode != null)
            {
                sourcedir = path + @"..\" + @"..\" + treeView1.SelectedNode.FullPath.ToString() + @"\New folder";
            }
            else
            {
                MessageBox.Show("Choose folder", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {      
                DirectoryInfo di = new DirectoryInfo(sourcedir);
                di.Create();
            }
            catch (IOException er)
            {
                MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            button_refresh_Click(sender, e);
        }

        private void button_file_Click(object sender, EventArgs e)                                                                                       // Choose file
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                label3.Text = openFileDialog1.FileName;
                //DirectoryInfo info = new DirectoryInfo(openFileDialog1.FileName);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)                                                                                     // Delete file
        {
            File.Delete(label3.Text);
            label3.Text = "";
        }

        private void btn_rename_Click(object sender, EventArgs e)                                                                                    // Rename File     
        {
            string sourcePath = label3.Text;
            if (File.Exists(sourcePath))
            {
                Form3 F1 = new Form3(this);
                F1.ShowDialog();
                FileInfo fi = new FileInfo(sourcePath);
                try
                {
                    fi.MoveTo(sourcePath + @"..\" + @"..\" + F1.tmp);
                }
                catch (IOException)
                {
                    MessageBox.Show("Имя пусто или содержит недопустимые знаки", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch(System.ArgumentException)
                {
                    MessageBox.Show("Имя содержит недопустимые знаки", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("File renamed", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Choose file", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void btn_copy_Click(object sender, EventArgs e)                                                                                // Copy File
        {
            progressBar1.Value = 0;
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string sourcePath = label3.Text;
            //if (File.Exists(sourcePath))
            //{
            //    FolderBrowserDialog file = new FolderBrowserDialog();
            //    file.RootFolder = Environment.SpecialFolder.DesktopDirectory;
            //    Thread thread = new Thread(() =>
            //    {
            //        if (file.ShowDialog() == DialogResult.OK)
            //        {
            //            dest = file.SelectedPath;
            //        }
            //        try
            //        {
            //            string name = Path.GetFileName(sourcePath);
            //            File.Copy(sourcePath, dest + @"\" + name, true);
            //        }
            //        catch(IOException er)
            //        {
            //            MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    });
            //    thread.SetApartmentState(ApartmentState.STA);
            //    thread.Start();
            //    thread.Join();
            //}
            //else
            //{
            //    MessageBox.Show("Choose file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            CopyingFiles(sourcePath);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                label6.Text = "Canceled!";
            }
            else if (e.Error != null)
            {
                label6.Text = "Error: " + e.Error.Message;
            }
            else
            {
                label6.Text = "Done!";
                progressBar1.Value = 100;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            CopyingDirectoryes(sourcedir2, dest);
        }
        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                label6.Text = "Canceled!";
            }
            else if (e.Error != null)
            {
                label6.Text = "Error: " + e.Error.Message;
            }
            else
            {
                label6.Text = "Done!";
                progressBar1.Value = 100;
            }
            button_refresh_Click(sender, e);
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                backgroundWorker1.CancelAsync();
            }
        }

        private void rPSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 Form = new Form5();
            Form.ShowDialog();
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///        Environment.NewLine ///  DateTime.Now.ToString() ///////////////////////////////////////////////////

        protected override void WndProc(ref Message m)
        {
            DEV_BROADCAST_HDR pHdr;
            switch (m.Msg)
            {
                case WM_DEVICECHANGE:
                    switch ((int)m.WParam)
                    {
                        case DBT_DEVICEARRIVAL://устройство подключено

                            pHdr = (DEV_BROADCAST_HDR)Marshal.PtrToStructure(m.LParam, typeof(DEV_BROADCAST_HDR));
                            if (pHdr.dbch_devicetype == DBT_DEVTYP_VOLUME)
                            {
                                MessageBox.Show("Volume was inserted", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                            break;

                        case DBT_DEVICEREMOVECOMPLETE://устройство отключено

                            pHdr = (DEV_BROADCAST_HDR)Marshal.PtrToStructure(m.LParam, typeof(DEV_BROADCAST_HDR));
                            if (pHdr.dbch_devicetype == DBT_DEVTYP_VOLUME)
                            {
                                MessageBox.Show("Volume was removed", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                            break;
                    }
                    break;
            }

            base.WndProc(ref m);
        }
        public struct DEV_BROADCAST_HDR
        {
            public int dbch_size;
            public int dbch_devicetype;
            public int dbch_reserved;
        }


        private void CopyingFiles(string path)
        {
            progressBar1.Value = 0;
            int count = 0;
            string destPath;
            do
            {
                string dirPath = Path.GetDirectoryName(path);
                string fileName = Path.GetFileNameWithoutExtension(path) + $"({count})";
                string fileExtention = Path.GetExtension(path);
                fileName += fileExtention;
                destPath = Path.Combine(dirPath, fileName);
                count++;
            } while (File.Exists(destPath));
            FileStream fsOut = new FileStream(destPath, FileMode.Create);
            FileStream fsIn = new FileStream(path, FileMode.Open);
            byte[] bt = new byte[1048756];
            int readByte;
            while ((readByte = fsIn.Read(bt, 0, bt.Length)) > 0)
            {
                fsOut.Write(bt, 0, readByte);
                backgroundWorker1.ReportProgress((int)(fsIn.Position * 100 / fsIn.Length));
            }
            fsIn.Close();
            fsOut.Close();
        }

        private void windowsRenamerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 Form = new Form7();
            Form.ShowDialog();
        }

        private void registryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 Form = new Form8();
            Form.ShowDialog();
        }

        private void CopyingDirectoryes(string fromPath, string destPath)
        {
            DirectoryInfo[] dirs = (new DirectoryInfo(fromPath)).GetDirectories();
            foreach (var subDir in dirs)
            {
                Directory.CreateDirectory(Path.Combine(destPath, subDir.Name));
                CopyingDirectoryes(Path.Combine(fromPath, subDir.Name), Path.Combine(destPath, subDir.Name));
            }
            string[] filesPath = Directory.GetFiles(fromPath);
            int countFile = 0;
            foreach (string filePath in filesPath)
            {
                string fileName = Path.GetFileName(filePath);
                string destFile = Path.Combine(destPath, fileName);
                File.Copy(filePath, destFile, true);
                countFile += 1;
                if (countFile < 100)
                {
                    backgroundWorker2.ReportProgress(countFile);
                }
            }

        }

    }
}
